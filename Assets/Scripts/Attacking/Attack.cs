using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Weapon equippedWeaponPrefab = null;

    private Weapon equippedWeapon;

    private void Awake()
    {
        equippedWeapon = Instantiate(equippedWeaponPrefab, transform);
    }

    public void OnAttackInputReceived()
    {
        equippedWeapon.Attack();
    }
}
