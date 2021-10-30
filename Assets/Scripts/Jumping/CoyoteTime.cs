using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class CoyoteTime : MonoBehaviour
    {
        [SerializeField] private float coyoteTimeInSeconds = 0.5f;
        [SerializeField] private Jump jump;

        private WaitForSeconds waitForCoyoteTime;
        private Coroutine coyoteTimeCoroutine;
        private bool isCoyoteTimeActive;

        private void Awake()
        {
            waitForCoyoteTime = new WaitForSeconds(coyoteTimeInSeconds);
        }

        private void OnEnable()
        {
            GroundCheck.Instance.GroundStateChanged.AddListener(OnGroundedStateChanged);
            PlayerInput.Instance.Jump.AddListener(OnJump);
        }

        public void OnJump()
        {
            if (GroundCheck.Instance.IsTouchingGround() || !isCoyoteTimeActive)
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
            yield return waitForCoyoteTime;
            isCoyoteTimeActive = false;
        }
    }
}
