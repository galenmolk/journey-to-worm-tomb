using UnityEngine;

namespace WormTomb
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void Start()
        {
            SetIsRunning(false);
        }

        private void OnEnable()
        {
            Player.Instance.RB.velocityChanged.AddListener(OnVelocityChanged);
        }

        private void SetIsRunning(bool isRunning)
        {
            animator.speed = isRunning ? 1f : 0f;
        }

        private void OnVelocityChanged(Vector2 velocity)
        {
            SetIsRunning(Mathf.Abs(velocity.x) > 0f);
        }
    }
}
