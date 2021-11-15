using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int startingHealth = 0;

    public UnityEvent onDie = new UnityEvent();

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
        onDie?.Invoke();
    }

    private void OnDisable()
    {
        onDie.RemoveAllListeners();
    }
}
