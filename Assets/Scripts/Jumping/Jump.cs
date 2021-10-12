using UnityEngine;

namespace WormTomb
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpSensitivity;
    
        private void Awake()
        {
            PlayerInput.Instance.onVerticalInput.AddListener(SetJumpVelocity);
        }

        private void SetJumpVelocity(float yVelocity)
        {
            if (!GroundCheck.IsGrounded)
                return;

            if (yVelocity < jumpSensitivity)
                yVelocity = 0;
        
            rb.velocity = new Vector2(rb.velocity.x, yVelocity * jumpForce);
        }
    }
}
