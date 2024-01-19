using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "New Character Stats", menuName = "Character Stats")]
    public class CharacterStats : ScriptableObject
    {
        public string CharacterName;
        public int InitialMaxHealth;
        public int InitialAttackDamage;
        public float InitialMoveSpeed;
        public int InitialLevelUpExpAmount;
        public float InitialTurnRadius;
        public int InitialAttackRange;

        [SerializeField]
        public CharacterLevelUpModifiers CharacterLevelUpModifiers;
    }
}    
