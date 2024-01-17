using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "New Enemy Level Info", menuName = "Enemy Level Up Modifiers")]
    public class EnemyLevelUpModifiers : ScriptableObject
    {
        public int MaxHealthIncrease;
        public int AttackDamageIncrease;
        public float MoveSpeedIncrease;
    }
}

