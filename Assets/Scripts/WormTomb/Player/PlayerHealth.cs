using UnityEngine;
using WormTomb.Combat;

namespace WormTomb
{
    public class PlayerHealth : Health
    {
        public delegate void DelegatePlayerHealthChanged(int health);

        public static event DelegatePlayerHealthChanged OnPlayerHealthChanged;

        [ContextMenu("Damage")]
        public void Damage()
        {
            TakeDamage(1);
        }
        
        protected override void ModifyHealth(int delta)
        {
            base.ModifyHealth(delta);
            OnPlayerHealthChanged?.Invoke(CurrentHealth);
        }

        private void OnEnable()
        {
            Respawn.OnRespawn += Restore;
        }

        private void OnDisable()
        {
            Respawn.OnRespawn -= Restore;
        }
    }
}
