using UnityEngine;
using WormTomb.Combat;
using WormTomb.General;
using WormTomb.Utils;

namespace WormTomb.Enemies
{
    [RequireComponent(typeof(Attack))]
    public class AttackContinuously : MonoBehaviour, IUpdatable
    {
        public bool AlwaysUpdate => false;
        
        [SerializeField] private float attackFrequency = 0.2f;
        [SerializeField] private DistanceToPlayer distanceToPlayer;
        
        private Attack _attack;

        private bool isAttacking;
        private float timeSinceLastAttack;
        
        private void StartAttacking()
        {
            isAttacking = true;
            timeSinceLastAttack = Time.time;
        }

        public void StopAttacking()
        {
            isAttacking = false;
        }

        public void ExecuteUpdate()
        {
            CheckAttackDistance();

            if (isAttacking)
                TryAttack();
        }

        public void StartTryAttacking()
        {
            UpdateManager.AddUpdatable(this);
        }
        
        public void StopTryAttacking()
        {
            UpdateManager.RemoveUpdatable(this);
        }

        private void CheckAttackDistance()
        {
            var isWithinRange = distanceToPlayer.Distance <= _attack.EquippedWeapon.Range;

            switch (isWithinRange)
            {
                case true when !isAttacking:
                    StartAttacking();
                    break;
                case false when isAttacking:
                    StopAttacking();
                    break;
            }
        }

        private void TryAttack()
        {
            if (!(Time.time - timeSinceLastAttack >= attackFrequency)) 
                return;
            
            _attack.TryAttack();
            timeSinceLastAttack = Time.time;
        }
        
        private void Awake()
        {
            _attack = GetComponent<Attack>();
        }
    }
}
