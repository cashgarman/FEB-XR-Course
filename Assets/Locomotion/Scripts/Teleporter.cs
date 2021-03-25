using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public string thumbstickInputName;
    public float thumbstickThreshold = -0.5f;
    public LineRenderer beam;
    public float range;
    public Color validColour;
    public Color invalidColour;
    public GameObject teleportIndicator;
    public Transform player;

    private bool hasValidTeleportTarget;

    void Start()
    {
        // Hide the beam intially
        SetBeamVisible(false);
    }

    void Update()
    {
        // If the thumbstick is pressed forward
        if(Input.GetAxis(thumbstickInputName) < thumbstickThreshold)
        {
            // Show the teleport beam
            SetBeamVisible(true);

            // Extend the beam out to its maximum range
            SetBeamEndPoint(transform.position + transform.forward * range);

            // Check if the beam hit something
            if(Physics.Raycast(transform.position, transform.forward, out var hit, range))
            {
                // Update the beam's endpoint to the point in space it hit
                SetBeamEndPoint(hit.point);

                // If the object we hit is a valid teleport target
                if(IsValidTeleportTarget(hit.collider.gameObject))
                {
                    // Set the beam to be valid
                    SetTeleportValid(true);

                    // Set the position of the teleport indicator
                    teleportIndicator.transform.position = hit.point + Vector3.up * 0.001f;
                }
                // If the object we hit is an invalid teleport target
                else
                {
                    // Set the beam to be invalid
                    SetTeleportValid(false);
                }
            }
            // If we didn't hit anything
            else
            {
                // Set the beam to be invalid
                SetTeleportValid(false);
            }
        }
        // If the thumbstick has been released
        else
        {
            // Hide the teleport beam
            SetBeamVisible(false);

            // Do we have a valid teleport target
            if(hasValidTeleportTarget)
            {
                // Teleport the player there
                player.position = teleportIndicator.transform.position;

                // Reset the teleport
                SetTeleportValid(false);
            }
        }
    }

    private void SetTeleportValid(bool valid)
    {
        // Set the appropriate colour of the beam
        beam.material.color = valid ? validColour : invalidColour;

        // Show or hide the teleport indicator as appropriate
        teleportIndicator.SetActive(valid);

        // Remember whether or not we have a valid target
        hasValidTeleportTarget = valid;
    }

    private bool IsValidTeleportTarget(GameObject target)
    {
        return true;
    }

    private void SetBeamEndPoint(Vector3 endPoint)
    {
        // Set the start and end positions of the beam
        beam.SetPosition(0, transform.position);
        beam.SetPosition(1, endPoint);
    }

    private void SetBeamVisible(bool visible)
    {
        // Show or hide the beam as appropriate
        beam.enabled = visible;
    }
}
