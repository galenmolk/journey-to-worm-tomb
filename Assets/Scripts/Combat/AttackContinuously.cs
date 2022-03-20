using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(Attack))]
    public class AttackContinuously : MonoBehaviour
    {
        [SerializeField] private float updateFrequency = 0.2f;
        
        private Attack _attack;

        private bool isAttacking;
        
        public void StartAttacking()
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

        private void Awake()
        {
            _attack = GetComponent<Attack>();
        }
    }
}
