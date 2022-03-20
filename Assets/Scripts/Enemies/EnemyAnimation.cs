using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimation : MonoBehaviour
    {
        private int isMovingId = Animator.StringToHash("isMoving");
        private int attackId = Animator.StringToHash("Attack");
        
        private Animator _animator;

        public void VelocityChanged(Vector2 velocity)
        {
            _animator.SetBool(isMovingId, Mathf.Abs(velocity.x) > 0f);
        }

        public void Attack()
        {
            _animator.SetTrigger(attackId);
        }
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}
