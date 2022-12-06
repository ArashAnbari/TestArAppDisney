using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace martinsMagicalMath
{

    public class HaversineEquation
    {
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
    }
}
