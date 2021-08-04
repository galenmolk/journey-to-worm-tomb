using UnityEngine;

public class AutoRun : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;

    [SerializeField] private bool autoRunEnabled = true;
    [SerializeField] [Min(0)] private float runForce = 0f;

    private void FixedUpdate()
    {
        if (!autoRunEnabled)
            return;

        Run();
    }

    private void Run()
    {
        rb.velocity = new Vector2(runForce, rb.velocity.y);
    }
}
