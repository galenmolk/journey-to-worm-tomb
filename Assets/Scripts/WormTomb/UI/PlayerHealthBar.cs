using System;
using UnityEngine;
using WormTomb.Player;

namespace WormTomb.UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Material healthBarMaterial;

        private int maxHealth;
        private static readonly int Health = Shader.PropertyToID("_Health");

        private void Awake()
        {
            maxHealth = Player.Player.Instance.StartingHealth;
        }

        private void OnEnable()
        {
            PlayerHealth.OnPlayerHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            PlayerHealth.OnPlayerHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int amount)
        {
            float fillPercent = amount / (float)maxHealth;
            healthBarMaterial.SetFloat(Health, fillPercent);
        }
    }
}
