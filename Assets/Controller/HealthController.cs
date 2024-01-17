using Core;
using Domain;
using System;
using UnityEngine;

namespace Controller
{
    public class HealthController : MonoBehaviour
    {
        public event Action OnHealthDepleted;

        public int currentHealth { get; private set; }

        private IRuntimeStats Stats;

        public void InitializeHealth(IRuntimeStats stats)
        {
            Stats = stats;
            currentHealth = stats.CurrentHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                DestroyObject();
            }
        }

        public void Heal(int healAmount)
        {
            currentHealth += healAmount;

            if (currentHealth >= Stats.MaxHealth)
            {
                currentHealth = Stats.MaxHealth;
            }
        }

        private void DestroyObject()
        {
            OnHealthDepleted?.Invoke();
        }
    }
}
