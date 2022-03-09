using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Weapon equippedWeaponPrefab;
    [SerializeField] private Transform weaponParent;
    
    private Weapon equippedWeapon;
    
    public void TryAttack()
    {
        if (equippedWeapon.CanAttack())
            equippedWeapon.AttackWithWeapon();
    }
    
    private void Awake()
    {
        equippedWeapon = Instantiate(equippedWeaponPrefab, weaponParent);
    }
}
