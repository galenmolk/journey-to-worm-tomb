using System.Collections.Generic;
using UnityEngine;

namespace WormTomb
{
    public class Enemy : MonoBehaviour
    {
        private List<IDamager> damagers = new();
        
        private const string ENEMY_LAYER_NAME = "Enemy";

        private int EnemyLayer { get; set; }

        private int CurrentHealth { get; set; }

        [SerializeField, Min(1)] private int startingHealth;

        private bool isDead;
        
        private void TakeDamage(int amount)
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

        private void Die()
        {
            Debug.Log($"{gameObject} died.");
            isDead = true;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log("OnTriggerStay2D");
            
            if (other.gameObject.layer == EnemyLayer)
                return;

            if (!other.gameObject.TryGetComponent(out IDamager damageSource))
                return;
            
            if (damagers.Contains(damageSource))
                return;
            
            damagers.Add(damageSource);
            TakeDamage(damageSource.DamageAmount);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("OnTriggerExit2D");
            
            if (other.gameObject.layer == EnemyLayer)
                return;

            if (!other.gameObject.TryGetComponent(out IDamager damageSource))
                return;

            if (damagers.Contains(damageSource))
                damagers.Remove(damageSource);
        }

        private void Awake()
        {
            CurrentHealth = startingHealth;
            EnemyLayer = LayerMask.NameToLayer(ENEMY_LAYER_NAME);
        }
    }
}