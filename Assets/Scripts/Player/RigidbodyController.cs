using UnityEngine;
using Utils;

namespace WormTomb
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyController : MonoBehaviour
    {
        public readonly Vector2Event velocityChanged = new();

        public float VelocityX { get { return rb.velocity.x; } }

        public Vector2 Position { get { return rb.position; } }

        [SerializeField] private Rigidbody2D rb;

        public void SetHorizontalVelocity(float x)
        {
            SetVelocity(new Vector2(x, rb.velocity.y));
        }

        public void SetVerticalVelocity(float y)
        {
            SetVelocity(new Vector2(rb.velocity.x, y));
        }

        public void MoveTo(Vector2 position)
        {
            rb.MovePosition(position);
        }

        public void SetIsObeyingGravity(bool isObeying)
        {
            rb.gravityScale = isObeying ? GameConsts.DefaultPlayerGravityScale : GameConsts.ZeroPlayerGravityScale;
        }

        private void SetVelocity(Vector2 velocity)
        {
            rb.velocity = velocity;
            velocityChanged.Invoke(velocity);
        }

        private void OnDisable()
        {
            velocityChanged.RemoveAllListeners();
        }
    }
}
