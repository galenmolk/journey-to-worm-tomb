using UnityEngine;

public class GroundCheck : Singleton<GroundCheck>
{
    public readonly BoolEvent GroundStateChanged = new BoolEvent();

    private const string GROUND_LAYER = "Ground";

    private int groundLayerMask;

    [SerializeField] private Collider2D col2D;

    public bool IsTouchingGround()
    {
        return col2D.IsTouchingLayers(~groundLayerMask);
    }

    private void Awake()
    {
        groundLayerMask = LayerMask.NameToLayer(GROUND_LAYER);
    }

    private void OnDisable()
    {
        GroundStateChanged.RemoveAllListeners();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGround(collision))
            GroundStateChanged?.Invoke(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsGround(collision))
            GroundStateChanged?.Invoke(false);
    }

    private bool IsGround(Collision2D collision)
    {
        return collision.gameObject.layer == LayerMask.NameToLayer(GROUND_LAYER);
    }
}
