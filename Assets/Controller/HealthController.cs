using Core;
using Domain;
using System;
using UnityEngine;

namespace Controller
{
    public class HealthController : MonoBehaviour
    {
        public event Action OnHealthDepleted;

        private IRuntimeStats Stats;

        public void InitializeHealth(IRuntimeStats stats)
        {
            Stats = stats;
        }

        public void TakeDamage(int damageAmount)
        {
            Stats.CurrentHealth -= damageAmount;
            if (Stats.CurrentHealth <= 0)
            {
                Stats.CurrentHealth = 0;
                DestroyObject();
            }
        }

        public void Heal(int healAmount)
        {
            Stats.CurrentHealth += healAmount;

            if (Stats.CurrentHealth >= Stats.MaxHealth)
            {
                Stats.CurrentHealth = Stats.MaxHealth;
            }
        }

        private void DestroyObject()
        {
            OnHealthDepleted?.Invoke();
        }
    }
}

