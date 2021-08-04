using System.Collections;
using UnityEngine;

public class JumpBuffer : MonoBehaviour
{
    [SerializeField] private Jump jump = null;
    [SerializeField] private float jumpBufferInSeconds = 0.5f;

    private WaitForSeconds waitForJumpBufferSeconds;
    private Coroutine bufferCoroutine;
    private bool isWithinBuffer = false;

    private void Awake()
    {
        waitForJumpBufferSeconds = new WaitForSeconds(jumpBufferInSeconds);
        GroundCheck.onDidBecomeGrounded.AddListener(GroundedStateChanged);
    }

    public void OnJumpInputReceived()
    {
        if (bufferCoroutine != null)
            StopCoroutine(bufferCoroutine);

        if (GroundCheck.IsGrounded)
            return;

        bufferCoroutine = StartCoroutine(StartJumpBuffer());
    }

    private void GroundedStateChanged(bool isGrounded)
    {
        if (isGrounded && isWithinBuffer)
            jump.Execute();
    }

    private IEnumerator StartJumpBuffer()
    {
        isWithinBuffer = true;
        yield return waitForJumpBufferSeconds;
        isWithinBuffer = false;
    }
}
