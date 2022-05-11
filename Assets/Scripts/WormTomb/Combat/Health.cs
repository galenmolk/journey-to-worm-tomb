using UnityEngine;
using UnityEngine.Events;

namespace WormTomb.Combat
{
    public class Health : MonoBehaviour, IDamageable
    {
        public UnityEvent OnDie = new();
        
        public int CurrentHealth { get; private set; }

        public int StartingHealth => startingHealth;
        [SerializeField, Min(1)] private int startingHealth = 1;

        private bool isDead;
        
        public void TakeDamage(int amount)
        {
            if (isDead)
                return;
            
            Debug.Log($"{gameObject.name} took {amount} damage");

            if (CurrentHealth - amount > 0)
            {
                ModifyHealth(-amount);
                return;
            }
            
            SetHealth(0);
            Die();
        }

        public void Die()
        {
            Debug.Log($"{gameObject} died.");
            isDead = true;
            ParticleController.Instance.SpawnAttackParticle(transform.position);
            OnDie.Invoke();
        }
        
        protected void Restore()
        {
            SetHealth(startingHealth);
            isDead = false;
        }
        
        protected virtual void ModifyHealth(int delta)
        {
            CurrentHealth += delta;
        }
        
        private void SetHealth(int value)
        {
            if (value == CurrentHealth)
                return;

            if (CurrentHealth > value)
                ModifyHealth(-(CurrentHealth - value));
            else
                ModifyHealth(value - CurrentHealth);
        }
        
        private void Awake()
        {
            Restore();
        }
    }
}
