using System.Collections;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private float attackDurationInSeconds = 0f;
    [SerializeField] private Collider2D weaponCollider = null;

    public override void Attack()
    {
        if (isCoolDownInProgress)
            return;
        Debug.Log("attacking with melee weapon");

        StartCoroutine(AttackWithCoolDown());
    }
    
    private void Awake()
    {
        weaponCollider.enabled = false;
    }

    private IEnumerator AttackWithCoolDown()
    {
        StartCoroutine(MeleeAttackSequence());

        isCoolDownInProgress = true;
        yield return YieldRegistry.WaitForSeconds(coolDownTime);
        isCoolDownInProgress = false;
    }

    private IEnumerator MeleeAttackSequence()
    {
        weaponCollider.enabled = true;
        yield return YieldRegistry.WaitForSeconds(attackDurationInSeconds);
        weaponCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>()?.TakeDamage(damageAmount);
    }
}
