using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float coolDownTime = 0.5f;

    [SerializeField] protected int damageAmount = 0;

    protected bool isCoolDownInProgress = false;

    public abstract void Attack();
}
