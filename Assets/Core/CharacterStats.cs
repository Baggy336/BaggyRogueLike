using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "New Character Stats", menuName = "Character Stats")]
    public class CharacterStats : ScriptableObject
    {
        public string CharacterName;
        public int Health;
        public int AttackDamage;
        public float MoveSpeed;
    }
}    
