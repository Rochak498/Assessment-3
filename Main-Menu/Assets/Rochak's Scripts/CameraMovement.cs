using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerBody;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float smoothSpeed = 10f;
    public float mouseSensitivity = 100f;

    private float xRotation = 0f;
    private bool cursorLocked = true;

    void Start()
    {
        LockCursor(true);
    }

    void Update()
    {
        // Press ESC to toggle cursor lock
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            LockCursor(cursorLocked);
        }
    }

    void LateUpdate()
    {
        if (!cursorLocked || playerBody == null)
            return;

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        Quaternion camRotation = Quaternion.Euler(xRotation, playerBody.eulerAngles.y, 0);
        transform.rotation = camRotation;

        Vector3 targetPosition = playerBody.position + camRotation * offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }

    void LockCursor(bool isLocked)
    {
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isLocked;
    }
}
