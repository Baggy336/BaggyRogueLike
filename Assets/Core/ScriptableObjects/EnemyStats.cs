using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Enemy Stats")]
    public class EnemyStats : ScriptableObject
    {
        public string EnemyName;
        public int InitialMaxHealth;
        public int InitialAttackDamage;
        public float InitialMoveSpeed;
        public int InitialAggroRange;
        public int InitialAttackRange;
        public float InitialTurnRadius;

        [SerializeField]
        public EnemyLevelUpModifiers EnemyLevelUpModifiers;
    }
}
