using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jump))]
public class JumpBuffer : MonoBehaviour
{
    [SerializeField] private float jumpBufferInSeconds = 0.5f;

    private Jump jump;
    private WaitForSeconds waitForJumpBufferSeconds;
    private bool isWithinBuffer = false;
    private Coroutine bufferCoroutine;

    private void Awake()
    {
        jump = GetComponent<Jump>();
        waitForJumpBufferSeconds = new WaitForSeconds(jumpBufferInSeconds);
        GroundCheck.onDidBecomeGrounded.AddListener(GroundedStateChanged);
    }

    public void JumpInputReceived()
    {
        if (bufferCoroutine != null)
            StopCoroutine(bufferCoroutine);

        if (GroundCheck.IsGrounded)
            return;

        bufferCoroutine = StartCoroutine(StartJumpBuffer());
    }

    private IEnumerator StartJumpBuffer()
    {
        isWithinBuffer = true;

        yield return waitForJumpBufferSeconds;

        isWithinBuffer = false;
    }

    private void GroundedStateChanged(bool isGrounded)
    {
        if (isGrounded && isWithinBuffer)
            jump.ExecuteJump();
    }
}
