using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharHandler : MonoBehaviour
    {
        public static CharHandler instance;

        private CharacterBase anchor, jet;

        private void Awake()
        {
            instance = this;
        }

        public CharacterStats.Base GetBaseStats(string character)
        {
            CharacterBase characterName;

            switch(character)
            {
                case "anchor":
                    characterName = anchor;
                    break;
                case "jet":
                    characterName = jet;
                    break;
                // Case for each unit type
                default:
                    Debug.Log($"No unit of type {character} exists.");
                    return null;
            }

            return characterName.baseStats;
        }
    }
}

