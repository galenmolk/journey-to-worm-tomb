using System.Collections;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private float attackDurationInSeconds = 0f;
    [SerializeField] private Collider2D weaponCollider = null;

    private void Awake()
    {
        weaponCollider.enabled = false;
    }

    public override void Attack()
    {
        if (isCoolDownInProgress)
            return;
        
        StartCoroutine(AttackWithCoolDown());
    }

    private IEnumerator AttackWithCoolDown()
    {
        StartCoroutine(MeleeAttackSequence());

        isCoolDownInProgress = true;
        yield return YieldRegistry.Wait(coolDownTime);
        isCoolDownInProgress = false;
    }

    private IEnumerator MeleeAttackSequence()
    {
        weaponCollider.enabled = true;
        yield return YieldRegistry.Wait(attackDurationInSeconds);
        weaponCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>()?.TakeDamage(damageAmount);
    }
}
