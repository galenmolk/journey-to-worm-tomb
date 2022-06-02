using UnityEngine;
using UnityEngine.Events;

namespace WormTomb.Combat
{
    public class Attack : MonoBehaviour
    {
        public UnityEvent onAttack = new();

        public Weapon EquippedWeapon { get; private set; }

        [SerializeField] private Weapon equippedWeaponPrefab;
        [SerializeField] private Transform weaponParent;
        [SerializeField] private LayerMask ignoreLayers;

        public void TryAttack()
        {
            if (!EquippedWeapon.CanAttack()) 
                return;

            onAttack.Invoke();
            EquippedWeapon.AttackWithWeapon();
        }

        private void EquipWeapon()
        {
            EquippedWeapon = Instantiate(equippedWeaponPrefab, weaponParent);
            EquippedWeapon.Initialize(new WeaponParams(ignoreLayers));
        }
    
        private void Awake()
        {
            EquipWeapon();
        }
    }
}
