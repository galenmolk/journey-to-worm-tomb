using UnityEngine;

namespace WormTomb
{
    public class Health : MonoBehaviour, IDamageable
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
            Debug.Log(gameObject.name + ": Health.Die called!");
            Player.Instance.OnDie.Invoke();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                Die();
        }
    }
}
