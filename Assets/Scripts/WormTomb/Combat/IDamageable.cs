namespace WormTomb.Combat
{
    public interface IDamageable
    {
        int CurrentHealth { get; }
        void TakeDamage(int amount);
        void Die();
    }
}
