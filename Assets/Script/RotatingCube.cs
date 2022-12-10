using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatingCube : MonoBehaviour
{
    public Vector3 editPosition;
    public Vector3 editRotation;
    public Vector3 editScale;
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
            transform.Rotate(editRotation * Time.deltaTime);
            Debug.Log("Update");
        }
    }
}
