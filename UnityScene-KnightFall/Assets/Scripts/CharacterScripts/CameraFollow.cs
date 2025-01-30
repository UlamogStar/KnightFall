using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // The target to follow (usually the player's transform)
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset from the target in world space
    public float smoothing = 5f;    // The speed at which the camera follows the target

    private void FixedUpdate()
    {
        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current camera position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing * Time.deltaTime);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;
    }
}
