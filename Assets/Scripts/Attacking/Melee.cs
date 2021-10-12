using System.Collections;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private float attackDurationInSeconds = 0f;
    [SerializeField] private Collider2D weaponCollider = null;

    private WaitForSeconds attackDuration = null;
    private WaitForSeconds AttackDuration
    {
        get
        {
            if (attackDuration == null)
                attackDuration = new WaitForSeconds(attackDurationInSeconds);

            return attackDuration;
        }
    }

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
        yield return CoolDown;
        isCoolDownInProgress = false;
    }

    private IEnumerator MeleeAttackSequence()
    {
        weaponCollider.enabled = true;
        yield return AttackDuration;
        weaponCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>()?.TakeDamage(damageAmount);
    }
}
