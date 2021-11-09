using UnityEngine;

namespace WormTomb
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void Awake()
        {
            SetIsRunning(false);
        }

        private void OnEnable()
        {
            PlayerRigidbody.Instance.VelocityChanged.AddListener(OnVelocityChanged);
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
