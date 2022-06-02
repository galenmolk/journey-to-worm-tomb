using UnityEngine;
using WormTomb.Animation;

namespace WormTomb.Enemies
{
    public class EnemyAnimationNew : SpriteAnimator
    {
        [SerializeField] private SpriteState walk;
        [SerializeField] private SpriteState punch;
        [SerializeField] private RigidbodyController rigidbodyController;

        private void Awake()
        {
            rigidbodyController.OnHorizontalVelocityChanged += HandleHorizontalVelocityChanged;
        }

        private void OnDestroy()
        {
            rigidbodyController.OnHorizontalVelocityChanged -= HandleHorizontalVelocityChanged;
        }

        public void HandleHorizontalVelocityChanged(float x)
        {
            bool isRunning = Mathf.Abs(x) > 0f;
            if (isRunning)
            {
                Play(walk);
            }
            else
            {
                if (ActiveState != null && ActiveState.Id == walk.Id && ActiveState.IsPlaying)
                {
                    Pause();
                }
            }
        }

        public void Attack()
        {
            Play(punch);
        }
    }
}
