using UnityEngine;
using UnityEngine.Events;
using WormTomb.Combat;

public class Attack : MonoBehaviour
{
    public UnityEvent OnAttack = new();

    public Weapon EquippedWeapon => equippedWeapon;
    
    [SerializeField] private Weapon equippedWeaponPrefab;
    [SerializeField] private Transform weaponParent;
    [SerializeField] private LayerMask ignoreLayers;
    
    private Weapon equippedWeapon;
    
    public void TryAttack()
    {
        Debug.Log("TryAttack");
        if (!equippedWeapon.CanAttack()) 
            return;

        Debug.Log("AttackWithWeapon");
        OnAttack.Invoke();
        equippedWeapon.AttackWithWeapon();
    }

    private void EquipWeapon()
    {
        equippedWeapon = Instantiate(equippedWeaponPrefab, weaponParent);
        equippedWeapon.Initialize(new WeaponParams(ignoreLayers));
    }
    
    private void Awake()
    {
        EquipWeapon();
    }
}
