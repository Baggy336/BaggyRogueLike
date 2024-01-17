using Core;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Domain;

namespace Controller
{
    public class ExpController
    {
        private CharacterRuntimeStats _runtimeStats;

        public ExpController(CharacterRuntimeStats runtimeStats)
        {
            _runtimeStats = runtimeStats;
        }

        public void GainExperience(int xpAmount)
        {
            _runtimeStats.Exp += xpAmount;

            if(_runtimeStats.Exp >= _runtimeStats.LevelUpExpAmount)
            {
                LevelUpCharacter();
            }
        }

        private void LevelUpCharacter()
        {
            _runtimeStats.CharacterLevel++;

            _runtimeStats.MaxHealth += _runtimeStats.MaxHealthIncrease;
            _runtimeStats.CurrentHealth += _runtimeStats.MaxHealthIncrease;
            _runtimeStats.AttackDamage += _runtimeStats.AttackDamageIncrease;
            _runtimeStats.LevelUpExpAmount += _runtimeStats.LevelUpExpAmountIncrease;

            _runtimeStats.Exp = 0;
        }
    }
}

