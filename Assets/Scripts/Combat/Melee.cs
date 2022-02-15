using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Melee : Weapon
    {
        [SerializeField] private Collider2D weaponCollider;

        public override bool CanAttack()
        {
            return !isCoolDownInProgress && !weaponCollider.enabled;
        }

        public override int DamageAmount => damageAmount;

        public override void AttackWithWeapon()
        {
            StartCoroutine(AttackWithCoolDown());
        }

        private IEnumerator AttackWithCoolDown()
        {
            isCoolDownInProgress = true;
            StartCoroutine(MeleeAttackSequence());
            yield return YieldRegistry.WaitForSeconds(cooldownDuration);
            isCoolDownInProgress = false;
        }

        private IEnumerator MeleeAttackSequence()
        {
            weaponCollider.enabled = true;
            yield return YieldRegistry.WaitForSeconds(attackDuration);
            weaponCollider.enabled = false;
        }

        // private void OnCollisionEnter2D(Collision2D col)
        // {
        //     if (col.gameObject.layer == Player.Instance.PlayerLayer)
        //         return;
        //
        //     col.gameObject.GetComponent<IDamageable>()?.TakeDamage(damageAmount);
        // }

        private void Awake()
        {
            weaponCollider.enabled = false;
        }
    }
}
