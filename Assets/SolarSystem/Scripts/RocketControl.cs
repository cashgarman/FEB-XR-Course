using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    public float turningForce;
    public float engineForce;
    public GameObject engineLight;

    private Rigidbody rigidBody;
    private bool engineOn;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get our mouse controls
        float yaw = Input.GetAxis("Mouse X");
        float pitch = -Input.GetAxis("Mouse Y");

        // Rotate the rocket using the mouse controls
        rigidBody.AddRelativeTorque(
            pitch * turningForce * Time.deltaTime,  // Pitch
            yaw * turningForce * Time.deltaTime,    // Yaw
            0f);                                    // Roll

        // Turn on the rocket engine when W is pressed
        if(Input.GetKeyDown(KeyCode.W))
        {
            engineOn = true;
            engineLight.SetActive(true);
        }

        // Turn off the rocket engine when W is released
        if (Input.GetKeyUp(KeyCode.W))
        {
            engineOn = false;
            engineLight.SetActive(false);
        }

        // Quit when you hit escape
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // If the engine is on
        if(engineOn)
        {
            // Apply a engine force
            Debug.Log(transform.forward * engineForce * Time.deltaTime);
            rigidBody.AddForce(transform.forward * engineForce * Time.deltaTime);
        }
    }
}
