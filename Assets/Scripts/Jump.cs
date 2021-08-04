using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private CoyoteTime coyoteTime = null;

    [SerializeField] private float jumpForce = 0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        CacheReferences();
    }

    private void CacheReferences()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnJumpInputReceived()
    { 
        if (!CanJump())
            return;

        ExecuteJump();
    }

    private bool CanJump()
    {
        return GroundCheck.IsGrounded || (coyoteTime != null && coyoteTime.IsCoyoteTimeActive);
    }

    public void ExecuteJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
