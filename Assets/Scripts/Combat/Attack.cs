using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    public UnityEvent OnAttack = new UnityEvent();
    
    [SerializeField] private Weapon equippedWeaponPrefab;
    [SerializeField] private Transform weaponParent;
    
    private Weapon equippedWeapon;
    
    public void TryAttack()
    {
        if (!equippedWeapon.CanAttack()) 
            return;

        OnAttack.Invoke();
        equippedWeapon.AttackWithWeapon();
    }
    
    private void Awake()
    {
        equippedWeapon = Instantiate(equippedWeaponPrefab, weaponParent);
    }
}
