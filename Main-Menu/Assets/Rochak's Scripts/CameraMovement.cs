using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerBody;              // The player object to follow and rotate
    public Vector3 offset = new Vector3(0, 2, -4);  // Camera position offset
    public float smoothSpeed = 10f;           // Camera follow smoothness
    public float mouseSensitivity = 100f;     // Mouse look sensitivity

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Lock cursor in the center
    }

    void LateUpdate()
    {
        if (playerBody == null) return;

        // Get raw mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate player horizontally
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate camera vertically (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Calculate final rotation for the camera
        Quaternion camRotation = Quaternion.Euler(xRotation, playerBody.eulerAngles.y, 0);
        transform.rotation = camRotation;

        // Smooth follow the player
        Vector3 targetPosition = playerBody.position + camRotation * offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
