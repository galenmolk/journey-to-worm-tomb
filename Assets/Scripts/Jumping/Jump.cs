using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private float jumpForce;

        public void ExecuteJump()
        {
            PlayerRigidbody.Instance.SetVelocityY(jumpForce);
        }

        private void OnJump()
        {
            StartCoroutine(JumpContinuously());
        }

        private IEnumerator JumpContinuously()
        {
            while (PlayerInput.Instance.IsJumpButtonPressed)
            {
                if (GroundCheck.Instance.IsTouchingGround())
                    ExecuteJump();

                yield return null;
            }
        }

        private void OnEnable()
        {
            PlayerInput.Instance.Jump.AddListener(OnJump);
        }
    }
}
