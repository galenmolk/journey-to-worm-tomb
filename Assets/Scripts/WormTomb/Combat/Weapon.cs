using UnityEngine;
using WormTomb.Utils;

namespace WormTomb.Combat
{
    public abstract class Weapon : MonoBehaviour, IDamager
    {
        public float Range => weaponRangeInWorldUnits;
    
        [SerializeField] protected float weaponRangeInWorldUnits;
        [SerializeField] protected float cooldownDuration;
        [SerializeField] protected float attackDuration;

        [SerializeField] protected int damageAmount;

        protected bool isCoolDownInProgress;
        protected WeaponParams weaponParams;
    
        public abstract void AttackWithWeapon();

        public abstract bool CanAttack();
        public abstract int DamageAmount { get; }

        public abstract void Initialize(WeaponParams WeaponParams);

        protected bool IsTargetValid(GameObject target)
        {
            return !weaponParams.IgnoreLayers.ContainsLayer(target.layer);
        }
    }
}
