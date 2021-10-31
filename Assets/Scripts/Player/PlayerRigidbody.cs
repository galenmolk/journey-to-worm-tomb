using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerRigidbody : Singleton<PlayerRigidbody>
    {
        [SerializeField] private Rigidbody2D rb;

        public float VelocityX { get { return rb.velocity.x; } }

        public void SetVelocityX(float x)
        {
            rb.velocity = new Vector2(x, rb.velocity.y);
        }

        public void SetVelocityY(float y)
        {
            rb.velocity = new Vector2(rb.velocity.x, y);
        }
    }
}
