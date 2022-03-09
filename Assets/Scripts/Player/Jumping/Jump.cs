using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Jump : MonoBehaviour
    {
        public bool IsJumping { get; private set; }

        [SerializeField] private float jumpForce;

        public void ExecuteJump()
        {
            IsJumping = true;
            Player.Instance.RB.SetVerticalVelocity(jumpForce);
        }

        private void OnJump()
        {
            StartCoroutine(JumpContinuously());
        }

        private IEnumerator JumpContinuously()
        {
            while (PlayerInput.Instance.IsJoystickUp)
            {
                if (GroundCheck.Instance.IsTouchingGround())
                    ExecuteJump();

                yield return null;
            }
        }

        private void OnEnable()
        {
            PlayerInput.Instance.joystickUp.AddListener(OnJump);
            GroundCheck.Instance.GroundStateChanged.AddListener(OnGroundStateChanged);
        }

        private void OnGroundStateChanged(bool isGrounded)
        {
            if (isGrounded)
                IsJumping = false;
        }
    }
}
