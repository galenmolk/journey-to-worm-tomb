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
            Vector2 force = new Vector2(x * Time.deltaTime, 0f);
            AddForce(force);
        }

        public void AddVerticalForce(float y)
        {
            Vector2 force = new Vector2(0f, y * Time.deltaTime);

            AddForce(new Vector2(rb.velocity.x, y));
        }

        private void AddForce(Vector2 velocity)
        {
            rb.AddForce(velocity);
            VelocityChanged.Invoke(velocity);
        }

        private void OnDisable()
        {
            VelocityChanged.RemoveAllListeners();
        }
    }
}
