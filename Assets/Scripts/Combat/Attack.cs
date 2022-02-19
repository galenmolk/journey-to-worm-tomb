using UnityEngine;
using WormTomb;

public class Attack : MonoBehaviour
{
    [SerializeField] private Weapon equippedWeaponPrefab;
    [SerializeField] private Transform weaponParent;
    
    private Weapon equippedWeapon;

    private void Awake()
    {
        equippedWeapon = Instantiate(equippedWeaponPrefab, weaponParent);
    }

    private void TryAttack()
    {
        if (equippedWeapon.CanAttack())
            equippedWeapon.AttackWithWeapon();
    }

    private void OnEnable()
    {
        PlayerInput.Instance.Attack.AddListener(TryAttack);
    }
}
