using System.Collections;
using UnityEngine;
using WormTomb.General;
using WormTomb.Utils;

namespace WormTomb.Combat
{
    [RequireComponent(typeof(Attack))]
    public class AttackContinuously : MonoBehaviour
    {
        [SerializeField] private float updateFrequency = 0.2f;
        
        private Attack _attack;

        private bool isAttacking;

        private void StartAttacking()
        {
            isAttacking = true;
            StartCoroutine(AttackCoroutine());
        }

        public void StopAttacking()
        {
            isAttacking = false;
        }

        private IEnumerator AttackCoroutine()
        {
            while (isAttacking)
            {
                _attack.TryAttack();
                yield return YieldRegistry.WaitForSeconds(updateFrequency);
            }
        }

        private void Update()
        {
            var isWithinRange = transform.position.WithinRangeOfPlayer(_attack.EquippedWeapon.Range);
            if (isWithinRange)
                StartAttacking();
            else
                StopAttacking();
        }

        private void Awake()
        {
            _attack = GetComponent<Attack>();
        }
    }
}
