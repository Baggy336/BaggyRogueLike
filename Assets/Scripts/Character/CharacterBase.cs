using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    // Set up the ability to make a new object of Unit type
    [CreateAssetMenu(fileName = "New Character", menuName = "New Character")]
    public class CharacterBase : ScriptableObject
    {

        public enum Character
        {
            Anchor,
            Jet
        }

        [Space(10)]
        [Header("Character Settings")]
        [Space(5)]
        public Character character;

        public string characterName;

        public GameObject characterPrefab;

        [Space(20)]
        [Header("Character Stats")]
        [Space(5)]
        public CharacterStats.Base baseStats;


    }
}

