using UnityEngine;

public class WallJump : MonoBehaviour
{
    public float wallSlideSpeed = 2f; // Speed when sliding down a wall
    public float wallJumpForce = 12f; // Jump force when jumping off a wall
    public float wallJumpPush = 8f; // Horizontal push when wall jumping
    public float wallCheckDistance = 0.3f; // Distance to check for walls
    public LayerMask wallLayer; // Layer mask for walls
    public int maxWallJumps = 1; // How many wall jumps the player gets per wall collision

    private Rigidbody2D rb;
    private bool isTouchingWall;
    private bool isWallSliding;
    private int wallJumpCount;
    private int lastWallDir = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for wall collision
        RaycastHit2D wallHitLeft = Physics2D.Raycast(transform.position, Vector2.left, wallCheckDistance, wallLayer);
        RaycastHit2D wallHitRight = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, wallLayer);

        isTouchingWall = wallHitLeft.collider != null || wallHitRight.collider != null;

        // Store last wall direction for jumping
        if (wallHitLeft.collider != null) lastWallDir = 1; // Push player to the right
        if (wallHitRight.collider != null) lastWallDir = -1; // Push player to the left

        // Wall Sliding Logic
        isWallSliding = isTouchingWall && rb.linearVelocity.y < 0;
        if (isWallSliding)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed);
        }

        // Reset wall jumps when touching a new wall
        if (isTouchingWall && wallJumpCount < maxWallJumps)
        {
            wallJumpCount = maxWallJumps;
            Debug.Log("Wall Touch - Reset Wall Jumps: " + wallJumpCount);
        }

        // Debugging
        Debug.DrawRay(transform.position, Vector2.left * wallCheckDistance, isTouchingWall ? Color.green : Color.red);
        Debug.DrawRay(transform.position, Vector2.right * wallCheckDistance, isTouchingWall ? Color.green : Color.red);

        // Wall Jump Input
        if (Input.GetButtonDown("Jump") && wallJumpCount > 0)
        {
            rb.linearVelocity = new Vector2(lastWallDir * wallJumpPush, wallJumpForce);
            wallJumpCount--;
            Debug.Log("Wall Jump! Remaining: " + wallJumpCount);
        }
    }
}
