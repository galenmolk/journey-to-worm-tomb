using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;

    [SerializeField] private float jumpForce = 0f;

    public void OnJumpInputReceived()
    { 
        if (!GroundCheck.IsGrounded)
            return;

        Execute();
    }

    public void Execute()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
