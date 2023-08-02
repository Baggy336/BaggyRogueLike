using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ability
{
    public class AbilityStats : ScriptableObject
    {
        [System.Serializable]
        public class Base
        {
            public float damage, damageType, baseCooldown;
        }
    }
}
