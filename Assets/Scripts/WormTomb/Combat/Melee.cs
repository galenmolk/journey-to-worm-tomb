using System.Collections;
using UnityEngine;
using WormTomb.General;

namespace WormTomb.Combat
{
    public class Melee : Weapon
    {
        public override int DamageAmount => damageAmount;
        
        private IDamageable activeTarget;
        
        public override bool CanAttack()
        {
            return !isCoolDownInProgress;
        }

        public override void Initialize(WeaponParams WeaponParams)
        {
            weaponParams = WeaponParams;
        }

        public override void AttackWithWeapon()
        {
            StartCoroutine(AttackWithCoolDown());
        }

        private IEnumerator AttackWithCoolDown()
        {
            isCoolDownInProgress = true;
            TryDealDamage();
            yield return YieldRegistry.WaitForSeconds(cooldownDuration);
            isCoolDownInProgress = false;
        }

        private void TryDealDamage()
        {
            if (activeTarget == null)
                return;
            
            ParticleController.Instance.SpawnAttackParticle(transform.position);
            activeTarget.TakeDamage(damageAmount);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsTargetValid(other.gameObject))
                return;
            
            if (!other.TryGetComponent(out IDamageable damageable))
                return;

            activeTarget = damageable;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!IsTargetValid(other.gameObject))
                return;
            
            if (!other.TryGetComponent(out IDamageable damageable))
                return;

            if (damageable != activeTarget)
                return;
            
            activeTarget = null;
        }
    }
}
