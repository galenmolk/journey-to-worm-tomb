using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public static bool IsGrounded { get { return isGrounded; } }

    public static BoolEvent onDidBecomeGrounded = new BoolEvent();

    private static bool isGrounded = false;

    private const string GROUND_LAYER = "Ground";

    private void Awake()
    {
        onDidBecomeGrounded.AddListener((grounded) => { isGrounded = grounded; });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(GROUND_LAYER))
            onDidBecomeGrounded?.Invoke(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(GROUND_LAYER))
            onDidBecomeGrounded?.Invoke(false);
    }
}
