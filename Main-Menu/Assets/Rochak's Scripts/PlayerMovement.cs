using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Speed of the player's movement
    public float turnSpeed = 10f;           // Speed of player rotation
    public float jumpForce = 10f;           // Force for the jump (increased height)
    public Transform playerCamera;          // Reference to the camera
    public LayerMask groundLayer;           // Ground detection layer
    public float groundCheckDistance = 0.3f; // Distance for ground detection

    private Rigidbody rb;
    private bool isGrounded;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Prevent the Rigidbody from rotating
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Handle player movement
        MovePlayer();

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void MovePlayer()
    {
        // Get input for horizontal and vertical movement (WASD or Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right
        float moveZ = Input.GetAxisRaw("Vertical");    // W/S or Up/Down

        // Direction to move based on input
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Move the player using Rigidbody (ignores physics like gravity)
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

        // Rotate the player based on movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        // Apply upward force to make the player jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
