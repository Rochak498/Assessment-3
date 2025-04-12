using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;              // Player's body
    public Vector3 offset;                // Offset from the player
    public float smoothSpeed = 0.125f;    // Smooth camera movement
    public float mouseSensitivity = 100f; // Sensitivity of the mouse

    float xRotation = 0f;                 // Vertical rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the mouse cursor
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical look (clamped to avoid flipping)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Apply rotation to camera (up/down)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player horizontally (left/right)
        target.Rotate(Vector3.up * mouseX);

        // Smooth follow the player with offset
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
