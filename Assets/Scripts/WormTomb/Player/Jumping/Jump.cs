using UnityEngine;
using WormTomb.UI;

namespace WormTomb
{
    public class Jump : MonoBehaviour
    {
        public bool IsJumping { get; private set; }

        [SerializeField] private float jumpForce;

        public void ExecuteJump()
        {
            if (PlayerClimb.IsTouchingClimbable)
                return;
            
            IsJumping = true;
            Player.Instance.RB.SetVerticalVelocity(jumpForce);
        }

        private void OnJoystickUp()
        {
            if (Player.Instance.GroundCheck.IsTouchingGround())
                ExecuteJump();
        }

        private void OnEnable()
        {
            SubscribeToJoystickEvents();
        }
        
        private void SubscribeToJoystickEvents()
        {
            PlayerInput.Instance.joystickUp.AddListener(OnJoystickUp);
            Player.Instance.GroundCheck.GroundStateChanged.AddListener(OnGroundStateChanged);
        }

        private void OnGroundStateChanged(bool isGrounded)
        {
            if (isGrounded)
                IsJumping = false;
        }
    }
}
