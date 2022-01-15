using UnityEngine;
using WormTomb;

public class Attack : MonoBehaviour
{
    [SerializeField] private Weapon equippedWeaponPrefab = null;

    private Weapon equippedWeapon;

    private void Awake()
    {
        equippedWeapon = Instantiate(equippedWeaponPrefab, transform);
        PlayerInput.Instance.Attack.AddListener(InitiateAttack);
    }

    private void InitiateAttack()
    {
        equippedWeapon.Attack();

    }
}
