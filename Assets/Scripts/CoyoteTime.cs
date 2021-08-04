using System.Collections;
using UnityEngine;

public class CoyoteTime : MonoBehaviour
{
    [SerializeField] private float coyoteTimeInSeconds = 0.5f;

    public bool IsCoyoteTimeActive { get { return isCoyoteTimeActive; } }

    private bool isCoyoteTimeActive;
    private Coroutine coyoteTimeCoroutine;
    private WaitForSeconds waitForCoyoteTime;

    private void Awake()
    {
        waitForCoyoteTime = new WaitForSeconds(coyoteTimeInSeconds);
        GroundCheck.onDidBecomeGrounded.AddListener(GroundedStateChanged);
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
        Debug.Log("Starting coyote time");

        isCoyoteTimeActive = true;

        yield return waitForCoyoteTime;

        isCoyoteTimeActive = false;
    }
}
