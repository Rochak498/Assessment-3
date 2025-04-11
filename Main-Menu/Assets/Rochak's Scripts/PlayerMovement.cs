using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float groundDrag = 5f;
    public float airMultiplier = 0.4f;

    [Header("Jump Settings")]
    public float jumpForce = 14f;
    public float playerHeight = 2f;
    public float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;

    [Header("Ground Check")]
    public Transform groundCheck;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isGrounded;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (groundCheck == null)
        {
            // Automatically create a groundCheck if missing
            GameObject checker = new GameObject("GroundCheck");
            checker.transform.SetParent(transform);
            checker.transform.localPosition = new Vector3(0, -playerHeight / 2f, 0);
            groundCheck = checker.transform;
        }
    }

    void Update()
    {
        GroundCheck();
        GetInput();
        LimitSpeed();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Apply drag
        rb.drag = isGrounded ? groundDrag : 0;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector3.down * 0.1f, isGrounded ? Color.green : Color.red);
    }

    private void LimitSpeed()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
