using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        public CharacterStats Stats;

        [SerializeField]
        public List<Ability> Abilities;

        private void Start()
        {
            //Debug.Log("Character Name: " + Stats.CharacterName);
            //Debug.Log("Health: " + Stats.Health);
            //Debug.Log("Attack Damage: " + Stats.AttackDamage);
            //Debug.Log("Move Speed: " + Stats.MoveSpeed);

            //foreach(Ability ability in Abilities)
            //{
            //    Debug.Log("Ability Name: " + ability.AbilityName);
            //    Debug.Log("Ability Description: " + ability.AbilityDescription);
            //    Debug.Log("Cooldown: " + ability.Cooldown);
            //    Debug.Log("Damage: " + ability.Damage);
            //}

            foreach(Ability ability in Abilities)
            {
                ability.Initialize();
            }
        }

        private void Update()
        {
            foreach (Ability ability in Abilities)
            {
                if(Input.GetKeyDown(ability.CastKeyCode))
                {
                    if(ability.IsOffCooldown())
                    {
                        ability.Use();
                        Debug.Log("Used :" + ability.AbilityName);
                    }
                    else
                    {
                        Debug.Log(ability.AbilityName + " On Cooldown");
                    }
                }
            }
        }
    }
}
