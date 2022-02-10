using UnityEngine;

namespace WormTomb
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public int CurrentHealth { get; private set; }

        [SerializeField, Min(1)] private int startingHealth;

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