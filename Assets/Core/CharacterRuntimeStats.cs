using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalConfigs;

namespace Core
{
    [System.Serializable]
    public class CharacterRuntimeStats
    {
        // Character stats
        public int MaxHealth;
        public int CurrentHealth;
        public int AttackDamage;
        public float MoveSpeed;
        public int Exp;
        public int CharacterLevel;
        public int LevelUpExpAmount;

        // Level up modifiers
        public float MoveSpeedIncrease;
        public int AttackDamageIncrease;
        public int MaxHealthIncrease;
        public int LevelUpExpAmountIncrease;


        public CharacterRuntimeStats(CharacterStats baseStats)
        {
            // Character Stats
            MaxHealth = baseStats.InitialMaxHealth;
            CurrentHealth = baseStats.InitialMaxHealth;
            AttackDamage = baseStats.InitialAttackDamage;
            MoveSpeed = baseStats.InitialMoveSpeed;
            LevelUpExpAmount = CharacterLevelConfig.InitialLevelUpExpAmount;
            Exp = 0;
            CharacterLevel = 1;

            // Level Up Modifiers
            MoveSpeedIncrease = baseStats.LevelUpModifiers.MoveSpeedIncrease;
            AttackDamageIncrease = baseStats.LevelUpModifiers.AttackDamageIncrease;
            MaxHealthIncrease = baseStats.LevelUpModifiers.MaxHealthIncrease;
            LevelUpExpAmountIncrease = baseStats.LevelUpModifiers.LevelUpExpAmountIncrease;

        }
    }
}
