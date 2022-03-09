using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class CoyoteTime : MonoBehaviour
    {
        [SerializeField] private float coyoteTimeInSeconds = 0.5f;
        [SerializeField] private Jump jump;

        private Coroutine coyoteTimeCoroutine;
        private bool isCoyoteTimeActive;

        private void OnEnable()
        {
            SubscribeToEvents();
            
            PlayerClimb.OnClimbableEntered += UnsubscribeToEvents;
            PlayerClimb.OnClimbableExited += SubscribeToEvents;
        }

        private void OnDisable()
        {
            PlayerClimb.OnClimbableEntered -= UnsubscribeToEvents;
            PlayerClimb.OnClimbableExited -= SubscribeToEvents;
        }

        private void SubscribeToEvents()
        {
            GroundCheck.Instance.GroundStateChanged.AddListener(OnGroundedStateChanged);
            PlayerInput.Instance.joystickUp.AddListener(OnJump);
        }
        
        private void UnsubscribeToEvents()
        {
            GroundCheck.Instance.GroundStateChanged.RemoveListener(OnGroundedStateChanged);
            PlayerInput.Instance.joystickUp.RemoveListener(OnJump);
        }

        public void OnJump()
        {
            if (jump.IsJumping || GroundCheck.Instance.IsTouchingGround() || !isCoyoteTimeActive)
                return;

            isCoyoteTimeActive = false;
            jump.ExecuteJump();
        }

        private void OnGroundedStateChanged(bool isGrounded)
        {
            if (coyoteTimeCoroutine != null)
                StopCoroutine(coyoteTimeCoroutine);

            if (!isGrounded && !PlayerInput.Instance.IsJoystickUp)
                coyoteTimeCoroutine = StartCoroutine(StartCoyoteTime());
        }

        private IEnumerator StartCoyoteTime()
        {
            isCoyoteTimeActive = true;
            yield return YieldRegistry.WaitForSeconds(coyoteTimeInSeconds);
            isCoyoteTimeActive = false;
        }
    }
}
