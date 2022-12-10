using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatingCube : MonoBehaviour
{
    //public Vector3 editPosition;
    //public Vector3 editRotation;
    //public Vector3 editScale;
    public Keyboard keyboard;
   


    // Start is called before the first frame update
    void Start()
    {
        keyboard = Keyboard.current;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (keyboard == null)
        {
            Debug.Log("No keyboard");
            return;
        }

        if (keyboard.wKey.isPressed)
        {
            transform.position = transform.position + new Vector3(0, 0, 0.01f);
            Debug.Log("Update");
            //transform.Rotate(editRotation * Time.deltaTime);
            //Debug.Log("Update");
        }

        if (keyboard.sKey.isPressed)
        {
            transform.position = transform.position + new Vector3(0, 0, -0.01f);
            Debug.Log("Update");
            //transform.Rotate(editRotation * Time.deltaTime);
            //Debug.Log("Update");
        }

        if (keyboard.aKey.isPressed)
        {
            transform.position = transform.position + new Vector3(0.01f, 0, 0);
            Debug.Log("Update");
        }


        if (keyboard.dKey.isPressed)
        {
            transform.position = transform.position + new Vector3(-0.01f, 0, 0);
            Debug.Log("Update");
        }

        //transform.position = transform.position + new Vector3(keyboard.wKey * 5 * Time.deltaTime, verticalInput * 5 * Time.deltaTime, 0);
    }

}
