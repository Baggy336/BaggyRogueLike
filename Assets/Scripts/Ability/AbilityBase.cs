using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ability
{
    // Set up the ability to make a new object of Unit type
    [CreateAssetMenu(fileName = "New Ability", menuName = "New Ability")]
    public class AbilityBase : ScriptableObject
    {
        public enum abilityKey
        {
            q,
            w,
            e,
            r
        }

        [Space(10)]
        [Header("Ability Settings")]
        [Space(5)]
        public abilityKey key;

        public string abilityName;
        public string abilityDescription;
        public string abilityQuip;

        [Space(20)]
        [Header("Ability Stats")]
        [Space(5)]
        public AbilityStats baseStats;
    }
}
