using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerRigidbody : Singleton<PlayerRigidbody>
    {
        public Vector2Event VelocityChanged = new Vector2Event();

        public float VelocityX { get { return rb.velocity.x; } }

        [SerializeField] private Rigidbody2D rb;

        public void AddHorizontalForce(float x)
        {
            SetVelocity(new Vector2(x, rb.velocity.y));
        }

        public void SetVerticalVelocity(float y)
        {
            SetVelocity(new Vector2(rb.velocity.x, y));
        }

        private void SetVelocity(Vector2 velocity)
        {
            rb.velocity = velocity;
            VelocityChanged.Invoke(velocity);
        }

        private void OnDisable()
        {
            VelocityChanged.RemoveAllListeners();
        }
    }
}
