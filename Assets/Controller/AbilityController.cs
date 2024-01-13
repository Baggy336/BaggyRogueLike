using Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controller
{
    public class AbilityController : MonoBehaviour
    {
        [SerializeField]
        public List<Ability> Abilities;

        [SerializeField]
        private InputController _inputController;

        private void Start()
        {
            foreach(Ability ability in Abilities)
            {
                ability.Initialize();
                _inputController.RegisterKeyCode(ability.CastKeyCode);
            }

            InputController.OnAbilityInput += CheckAbilityUsed;
        }

        private void CheckAbilityUsed(KeyCode input)
        {
            Ability ability = Abilities.Where(x => x.CastKeyCode == input).FirstOrDefault();

            if(ability != null)
            {
                if(ability.IsOffCooldown())
                {
                    UseAbility(ability);   
                }
                else
                {
                    Debug.Log(ability.AbilityName + " Is On Cooldown");
                }
            }
        }

        private void UseAbility(Ability ability)
        {
            ability.Use();
            Debug.Log("Used :" + ability.AbilityName);
        }

        private void OnDestroy()
        {
            InputController.OnAbilityInput -= CheckAbilityUsed;
        }
    }  
}
