using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;
using martinsMagicalMath;

public class GPSlocation : MonoBehaviour
{
    [SerializeField] private TMP_Text longitude;
    [SerializeField] private TMP_Text latitude;
    [SerializeField] private TMP_Text status;

    // 59.345050349907005, 18.024239849697135

    [SerializeField] private float targetLong;
    [SerializeField] private float targetLat;

    private Vector2 targetPos;
    private float distance;
    [SerializeField] private float maxDistance = 9f;


    private void Start()
    {
        StartCoroutine(StartGPS());
        targetPos = new Vector2(targetLat, targetLong);
    }

    public void GPSstartButton()
    {
        StartGPS();
    }



    IEnumerator StartGPS()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;

        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            maxWait--;
            yield return new WaitForSeconds(1);
        }

        if(maxWait < 1)
        {
            status.text = "Conncection timed out, bitch";
            yield break;
        }

        if ( Input.location.status == LocationServiceStatus.Failed)
        {
            status.text = "Failed to initialize, bitch";

            yield break;
        }
        else
        {
            //Här börjar tracking av GPS
            status.text = "Tracking started, bitch";
            InvokeRepeating("UpdateGPSdata", 1f, 1f);
        }
    }

    public float measure(float lat1, float lon1, float lat2, float lon2)
    {  // generally used geo measurement function
        float R = 6378.137f; // Radius of earth in KM
        float dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        float dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
        Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
        Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        float d = R * c;
        return d * 1000f; // meters
    }

    /* public float Haversine()
     {

         const float R = 6371e3f; // metres
         float lat1 = Input.location.lastData.latitude;
         float lat2 = targetLat;
         float long1 = Input.location.lastData.longitude;
         float long2 = targetLong;
         float φ1 = lat1 * Mathf.PI / 180; // φ, λ in radians
         float φ2 = lat2 * Mathf.PI / 180;
         float Δφ = (lat2 - lat1) * Mathf.PI / 180;
         float Δλ = (long2 - long1) * Mathf.PI / 180;

         float a = Mathf.Sin(Δφ / 2) * Mathf.Sin(Δφ / 2) +
                   Mathf.Cos(φ1) * Mathf.Cos(φ2) *
                   Mathf.Sin(Δλ / 2) * Mathf.Sin(Δλ / 2);
         float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

         float d = R * c; // in metres

         return d;
     }

     */

    private void UpdateGPSdata()
    {
        if(Input.location.status == LocationServiceStatus.Running)
        {
            //Värden från GPS
            latitude.text = "Latitude " + Input.location.lastData.latitude.ToString();
            longitude.text = "Longitude " + Input.location.lastData.longitude.ToString();

            Vector2 position = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
            distance = measure(targetLat, targetLong, Input.location.lastData.latitude, Input.location.lastData.longitude);
            status.text = distance.ToString();
        }
        else
        {
            Input.location.Stop();
        }
    }
    
}
