using UnityEngine;
using UnityEngine.Events;

namespace WormTomb
{
    public class Health : MonoBehaviour, IDamageable
    {
        public UnityEvent OnDie = new();
        
        public int CurrentHealth { get; set; }

        [SerializeField, Min(1)] private int startingHealth = 1;

        private bool isDead;
        
        public void TakeDamage(int amount)
        {
            if (isDead)
                return;
            
            Debug.Log($"{gameObject.name} took {amount} damage");

            if (CurrentHealth - amount > 0)
            {
                CurrentHealth -= amount;
                return;
            }
            
            CurrentHealth = 0;
            Die();
        }

        public void Die()
        {
            Debug.Log($"{gameObject} died.");
            isDead = true;
        }

        private void Awake()
        {
            CurrentHealth = startingHealth;
        }
    }
}
