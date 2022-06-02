using System;
using UnityEngine;
using WormTomb.General;
using WormTomb.Utils;

namespace WormTomb
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyController : MonoBehaviour
    {
        public event Action<float> OnHorizontalVelocityChanged;
        public Vector2Event OnVelocityChanged = new();

        public float VelocityX => RB.velocity.x;

        public Vector2 Position => RB.position;

        public Rigidbody2D RB { get; private set; }

        public void SetHorizontalVelocity(float x)
        {
            SetVelocity(new Vector2(x, RB.velocity.y));
            OnHorizontalVelocityChanged?.Invoke(x);
        }

        public void SetVerticalVelocity(float y)
        {
            SetVelocity(new Vector2(RB.velocity.x, y));
        }

        public void MoveTo(Vector2 position)
        {
            RB.MovePosition(position);
        }

        public void SetIsObeyingGravity(bool isObeying)
        {
            RB.gravityScale = isObeying ? GameConsts.DefaultGravityScale : GameConsts.ZeroGravityScale;
        }

        private void SetVelocity(Vector2 velocity)
        {
            RB.velocity = velocity;
            // OnVelocityChanged.Invoke(velocity);
        }

        private void Awake()
        {
            RB = GetComponent<Rigidbody2D>();
        }

        private void OnDisable()
        {
            OnVelocityChanged.RemoveAllListeners();
            OnHorizontalVelocityChanged = null;
        }
    }
}
