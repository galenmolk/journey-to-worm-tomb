using System;
using System.Collections;
using UnityEngine;

namespace WormTomb
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
            GroundCheck.Instance.GroundStateChanged.AddListener(OnGroundedStateChanged);
            PlayerInput.Instance.joystickUp.AddListener(OnJump);
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
