using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 400f;
    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //Rotamos el focal point
        transform.Rotate(Vector3.up, rotationSpeed *Time.deltaTime * horizontalInput);

    }
}
