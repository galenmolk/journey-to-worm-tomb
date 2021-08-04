using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private Collider2D weaponCollider = null;

    private void Awake()
    {
        weaponCollider.enabled = false;
    }

    public override void Attack()
    {
        weaponCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
