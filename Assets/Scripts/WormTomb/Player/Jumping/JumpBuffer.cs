using System.Collections;
using UnityEngine;
using WormTomb.General;
using WormTomb.UI;

namespace WormTomb.Player.Jumping
{
    public class JumpBuffer : MonoBehaviour
    {
        [SerializeField] private Jump jump;
        [SerializeField] private float jumpBufferInSeconds = 0.5f;

        private Coroutine bufferCoroutine;
        private bool isWithinBuffer = false;

        private void OnEnable()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            Player.Instance.GroundCheck.GroundStateChanged.AddListener(OnGroundedStateChanged);
            PlayerInput.Instance.joystickUp.AddListener(OnJump);
        }
        
        public void OnJump()
        {
            if (bufferCoroutine != null)
                StopCoroutine(bufferCoroutine);

            if (Player.Instance.GroundCheck.IsTouchingGround())
                return;

            bufferCoroutine = StartCoroutine(StartJumpBuffer());
        }

        private void OnGroundedStateChanged(bool isGrounded)
        {
            if (!isWithinBuffer || !isGrounded)
                return;

            isWithinBuffer = false;
            jump.ExecuteJump();
        }

        private IEnumerator StartJumpBuffer()
        {
            isWithinBuffer = true;
            yield return YieldRegistry.WaitForSeconds(jumpBufferInSeconds);
            isWithinBuffer = false;
        }
    }   
}
