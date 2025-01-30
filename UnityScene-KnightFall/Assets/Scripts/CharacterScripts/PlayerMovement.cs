using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public float jumpForce = 12f;
    public float groundCheckDistance = 0.2f; // Distance for checking ground
    public LayerMask groundLayer;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumps;
    }

    void Update()
    {
        // Get movement input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Ground Check using Player's Position
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (isGrounded)
        {
            jumpCount = maxJumps; // Reset jumps
        }

        // Jump logic
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount > 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
        }

        // Variable jump height
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    void FixedUpdate()
    {
        // Smooth acceleration and deceleration
        float targetSpeed = moveInput * moveSpeed;
        float speedDiff = targetSpeed - rb.linearVelocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
        float movement = speedDiff * accelRate * Time.fixedDeltaTime;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x + movement, rb.linearVelocity.y);

        // Debugging: Draw Ground Check Ray
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, isGrounded ? Color.green : Color.red);
    }
}
