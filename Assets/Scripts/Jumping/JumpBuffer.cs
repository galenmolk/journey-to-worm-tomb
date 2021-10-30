using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class JumpBuffer : MonoBehaviour
    {
        [SerializeField] private readonly Jump jump;
        [SerializeField] private float jumpBufferInSeconds = 0.5f;

        private WaitForSeconds waitForJumpBufferSeconds;
        private Coroutine bufferCoroutine;
        private bool isWithinBuffer = false;

        private void Awake()
        {
            waitForJumpBufferSeconds = new WaitForSeconds(jumpBufferInSeconds);
        }

        private void OnEnable()
        {
            GroundCheck.GroundStateChanged.AddListener(OnGroundedStateChanged);
            PlayerInput.Instance.Jump.AddListener(OnJump);
        }

        public void OnJump()
        {
            if (bufferCoroutine != null)
                StopCoroutine(bufferCoroutine);

            if (GroundCheck.Instance.IsTouchingGround())
                return;

            bufferCoroutine = StartCoroutine(StartJumpBuffer());
        }

        private void OnGroundedStateChanged(bool isGrounded)
        {
            if (isWithinBuffer && isGrounded)
                jump.ExecuteJump();
        }

        private IEnumerator StartJumpBuffer()
        {
            isWithinBuffer = true;
            yield return waitForJumpBufferSeconds;
            isWithinBuffer = false;
        }
    }   
}
