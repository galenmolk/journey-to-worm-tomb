using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private float jumpForce;

        public void ExecuteJump()
        {
            Debug.Log("Jump.ExecuteJump");
            PlayerRigidbody.Instance.SetVelocityY(jumpForce);
        }

        private void OnJump()
        {
            Debug.Log("On Jump");
            StartCoroutine(JumpContinuously());
        }

        private IEnumerator JumpContinuously()
        {
            Debug.Log("JumpContinuously");
            Debug.Log(PlayerInput.Instance.IsJumpButtonPressed);
            while (PlayerInput.Instance.IsJumpButtonPressed)
            {
                Debug.Log("IsJumpButtonPressed");

                if (GroundCheck.Instance.IsTouchingGround())
                {
                    Debug.Log("IsTouchingGround");

                    ExecuteJump();
                }

                yield return null;
            }
        }

        private void OnEnable()
        {
            PlayerInput.Instance.Jump.AddListener(OnJump);
        }
    }
}
