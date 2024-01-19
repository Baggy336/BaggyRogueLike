using Core;

namespace Domain
{
    [System.Serializable]
    public class EnemyRuntimeStats : IRuntimeStats
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int AttackDamage { get; set; }
        public int AttackRange { get; set; }
        public float MoveSpeed { get; set; }
        public float TurnRadius { get; set; }

        // Enemy stats
        public int AggroRange;

        // Level up modifiers
        public float MoveSpeedIncrease;
        public int AttackDamageIncrease;
        public int MaxHealthIncrease;
        public int LevelUpExpAmountIncrease;


        public EnemyRuntimeStats(EnemyStats baseStats)
        {
            // Enemy Stats
            MaxHealth = baseStats.InitialMaxHealth;
            CurrentHealth = baseStats.InitialMaxHealth;
            AttackDamage = baseStats.InitialAttackDamage;
            MoveSpeed = baseStats.InitialMoveSpeed;
            TurnRadius = baseStats.InitialTurnRadius;
            AttackRange = baseStats.InitialAttackRange;
            AggroRange = baseStats.InitialAggroRange;

            // Level Up Modifiers
            MoveSpeedIncrease = baseStats.EnemyLevelUpModifiers.MoveSpeedIncrease;
            AttackDamageIncrease = baseStats.EnemyLevelUpModifiers.AttackDamageIncrease;
            MaxHealthIncrease = baseStats.EnemyLevelUpModifiers.MaxHealthIncrease;
        }
    }
}
