using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AR;

public class Rotate : MonoBehaviour
{
    Slider rotateSlider;
    public static float rotationDegrees;

    private void Start()
    {
        rotateSlider = GetComponent<Slider>();
    }

    public void RotateEvent()
    {
        rotationDegrees = rotateSlider.value;
        TapToPlace.spawnedObject.transform.rotation = Quaternion.Euler(0, rotationDegrees, 0);
    }
    
}
