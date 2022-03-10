using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace WormTomb
{
    public class Melee : Weapon
    {
        private IDamageable activeTarget;
        
        public override bool CanAttack()
        {
            return !isCoolDownInProgress;
        }

        public override int DamageAmount => damageAmount;

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
            if (other.gameObject.layer == Player.Instance.PlayerLayer)
                return;
            
            if (!other.TryGetComponent(out IDamageable damageable))
                return;

            Debug.Log("Setting Active Target: " + other.gameObject.name);
            activeTarget = damageable;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == Player.Instance.PlayerLayer)
                return;
            
            if (!other.TryGetComponent(out IDamageable damageable))
                return;

            if (damageable != activeTarget)
                return;
            
            Debug.Log("Clearing active target");
            activeTarget = null;
        }
    }
}
