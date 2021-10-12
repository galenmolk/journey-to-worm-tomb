using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class CoyoteTime : MonoBehaviour
    {
        [SerializeField] private float coyoteTimeInSeconds = 0.5f;
        [SerializeField] private Jump jump = null;

        private WaitForSeconds waitForCoyoteTime;
        private Coroutine coyoteTimeCoroutine;
        private bool isCoyoteTimeActive;

        private void Awake()
        {
            waitForCoyoteTime = new WaitForSeconds(coyoteTimeInSeconds);
            GroundCheck.onDidBecomeGrounded.AddListener(GroundedStateChanged);
        }

        public void OnJumpInputReceived()
        {
            if (!isCoyoteTimeActive)
                return;

            isCoyoteTimeActive = false;
            // jump.Execute();
        }

        private void GroundedStateChanged(bool isGrounded)
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
