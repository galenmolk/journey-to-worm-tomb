using System.Collections;
using UnityEngine;
using WormTomb.General;
using WormTomb.UI;

namespace WormTomb.Player.Jumping
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
        }

        private void SubscribeToEvents()
        {
            Player.Instance.GroundCheck.GroundStateChanged.AddListener(OnGroundedStateChanged);
            PlayerInput.Instance.joystickUp.AddListener(OnJump);
        }

        public void OnJump()
        {
            if (jump.IsJumping || Player.Instance.GroundCheck.IsTouchingGround() || !isCoyoteTimeActive)
                return;

            isCoyoteTimeActive = false;
            jump.ExecuteJump();
        }

        private void OnGroundedStateChanged(bool isGrounded)
        {
            if (coyoteTimeCoroutine != null)
                StopCoroutine(coyoteTimeCoroutine);

            if (!isGrounded)
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
