using Core;
using GlobalConfigs;

namespace Domain
{
    [System.Serializable]
    public class CharacterRuntimeStats : IRuntimeStats
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int AttackDamage { get; set; }
        public int AttackRange { get; set; }
        public float MoveSpeed { get; set; }
        public float TurnRadius { get; set; }

        // Character stats
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
            AttackRange = baseStats.InitialAttackRange;
            MoveSpeed = baseStats.InitialMoveSpeed;
            TurnRadius = baseStats.InitialTurnRadius;
            LevelUpExpAmount = CharacterLevelConfig.InitialLevelUpExpAmount;
            Exp = 0;
            CharacterLevel = 1;

            // Level Up Modifiers
            MoveSpeedIncrease = baseStats.CharacterLevelUpModifiers.MoveSpeedIncrease;
            AttackDamageIncrease = baseStats.CharacterLevelUpModifiers.AttackDamageIncrease;
            MaxHealthIncrease = baseStats.CharacterLevelUpModifiers.MaxHealthIncrease;
            LevelUpExpAmountIncrease = baseStats.CharacterLevelUpModifiers.LevelUpExpAmountIncrease;

        }
    }
}
