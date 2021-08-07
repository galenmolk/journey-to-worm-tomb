using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance
    {
        get
        {
            if (sharedInstance == null)
                sharedInstance = FindObjectOfType<Player>();

            return sharedInstance;
        }
    }

    public float RunSpeed
    {
        get
        {
            return rb.velocity.x;
        }
        set
        {
            rb.velocity = new Vector2(value, rb.velocity.y);
        }
    }

    private static Player sharedInstance;

    [SerializeField] private Rigidbody2D rb = null;
}
