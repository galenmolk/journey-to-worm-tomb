using System.Collections;
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

    private void InitiateAttack()
    {
        StartCoroutine(AttackContinuously());
    }

    private IEnumerator AttackContinuously()
    {
        while (PlayerInput.Instance.IsAttackButtonPressed)
        {
            equippedWeapon.TryAttack();
            yield return null;
        }
    }

    private void OnEnable()
    {
        PlayerInput.Instance.Attack.AddListener(InitiateAttack);
    }
}
