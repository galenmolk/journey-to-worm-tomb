using UnityEngine;

namespace WormTomb.General
{
    public class SetFacing : MonoBehaviour
    {
        private readonly Vector3 leftScale = new(-1, 1, 1);
        private readonly Vector3 rightScale = Vector3.one;

        private Transform _transform;

        public void SetFacingToLeft()
        {
            _transform.localScale = leftScale;
        }

        public void SetFacingToRight()
        {
            _transform.localScale = rightScale;
        }

        public void SetFacingFromVelocity(Vector2 velocity)
        {
            if (velocity.x == 0f)
                return;

            _transform.localScale = velocity.x > 0f ? rightScale : leftScale;
        }

        public void SetFacingFromTarget(Vector2 targetPos)
        {
            _transform.localScale = targetPos.x > _transform.position.x ? rightScale : leftScale;
        }

        private void Awake()
        {
            _transform = transform;
        }
    }
}
