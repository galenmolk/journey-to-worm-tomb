using UnityEngine;
using WormTomb.Combat;

namespace WormTomb.Environment
{
    public class BreakableWall : MonoBehaviour, IDamageable
    {
        [SerializeField] private int startingHealth = 0;

        public int CurrentHealth { get; private set; }

        private void Awake()
        {
            CurrentHealth = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            if (CurrentHealth <= 0)
                return;

            CurrentHealth -= amount;

            if (CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
