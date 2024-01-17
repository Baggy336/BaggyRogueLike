using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "New Character Level Info", menuName = "Level Up Modifiers")]
    public class CharacterLevelUpModifiers : ScriptableObject
    {
        public int MaxHealthIncrease;
        public int AttackDamageIncrease;
        public int LevelUpExpAmountIncrease;
        public float MoveSpeedIncrease;
    }
}
