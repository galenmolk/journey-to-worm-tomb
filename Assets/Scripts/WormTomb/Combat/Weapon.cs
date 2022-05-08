using UnityEngine;

public abstract class Weapon : MonoBehaviour, IDamager
{
    public float Range => weaponRangeInWorldUnits;
    
    [SerializeField] protected float weaponRangeInWorldUnits;
    [SerializeField] protected float cooldownDuration;
    [SerializeField] protected float attackDuration;

    [SerializeField] protected int damageAmount;

    protected bool isCoolDownInProgress;

    public abstract void AttackWithWeapon();

    public abstract bool CanAttack();
    public abstract int DamageAmount { get; }
}
