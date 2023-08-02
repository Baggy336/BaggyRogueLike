using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterStats : ScriptableObject
    {
        [System.Serializable]
        public class Base
        {
            public float health, armor, attackSpeed, attackRange, attackDmg;
        }
    }
}

