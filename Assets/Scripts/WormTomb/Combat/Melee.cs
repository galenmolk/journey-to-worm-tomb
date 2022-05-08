using System.Collections;
using UnityEngine;
using WormTomb.Utils;

namespace WormTomb
{
    public class Melee : Weapon
    {
        [SerializeField] private LayerMask ignoreLayers;
        
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
            Debug.Log("TryDealDamage. Target: " + activeTarget);
            if (activeTarget == null)
                return;
            
            ParticleController.Instance.SpawnAttackParticle(transform.position);
            activeTarget.TakeDamage(damageAmount);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("layer: " + other.gameObject.layer);

            if (ignoreLayers.ContainsLayer(other.gameObject.layer))
            {
                Debug.Log("layer is ignored");
                return;
            }
            
            if (!other.TryGetComponent(out IDamageable damageable))
            {
                Debug.Log("No Damageable Component on GameObject: "+ other.name);
                return;
            }

            Debug.Log("Setting Active Target: " + other.gameObject.name);
            activeTarget = damageable;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (ignoreLayers.ContainsLayer(other.gameObject.layer))
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
