using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoRun : MonoBehaviour
{
    [SerializeField] private bool autoRunEnabled = true;
    [SerializeField] [Min(0)] private float runForce = 0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        CacheReferences();
    }

    private void CacheReferences()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
