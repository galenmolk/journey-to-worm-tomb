using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    public UnityEvent OnAttack = new();

    public Weapon EquippedWeapon => equippedWeapon;
    
    [SerializeField] private Weapon equippedWeaponPrefab;
    [SerializeField] private Transform weaponParent;
    
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
    
    private void Awake()
    {
        equippedWeapon = Instantiate(equippedWeaponPrefab, weaponParent);
    }
}
