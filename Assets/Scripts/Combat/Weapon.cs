using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float cooldownDuration;
    [SerializeField] protected float attackDuration;

    [SerializeField] protected int damageAmount;

    protected bool isCoolDownInProgress;
    protected bool isAttackInProgress;

    public abstract void TryAttack();
}
