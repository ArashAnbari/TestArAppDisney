using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    public Vector3 editPosition;
    public Vector3 editRotation;
    public Vector3 editScale;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(editRotation);
        Debug.Log(transform.position);
    }
}
