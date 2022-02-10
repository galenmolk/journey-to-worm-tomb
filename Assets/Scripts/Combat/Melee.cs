using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Melee : Weapon
    {
        [SerializeField] private Collider2D weaponCollider;

        public override void TryAttack()
        {
            if (isCoolDownInProgress || isAttackInProgress)
                return;
        
            Debug.Log("attacking with melee weapon");
            isCoolDownInProgress = true;
            StartCoroutine(AttackWithCoolDown());
        }
    
        private void Awake()
        {
            weaponCollider.enabled = false;
        }

        private IEnumerator AttackWithCoolDown()
        {
            StartCoroutine(MeleeAttackSequence());
            yield return YieldRegistry.WaitForSeconds(cooldownDuration);
            isCoolDownInProgress = false;
        }

        private IEnumerator MeleeAttackSequence()
        {
            isAttackInProgress = true;
            weaponCollider.enabled = true;
            yield return YieldRegistry.WaitForSeconds(attackDuration);
            weaponCollider.enabled = false;
            isAttackInProgress = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == Player.Instance.PlayerLayer)
                return;
        
            collision.GetComponent<IDamageable>()?.TakeDamage(damageAmount);
        }
    }
}

