using Controller;
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
        private MovementController _movement;

        [SerializeField]
        private AbilityController _abilityController;

        [SerializeField]
        private InputController _inputController;

        private void Start()
        {
            
        }

        private void Update()
        {

        }

        private void MoveCharacter(Vector3 destination)
        {
            _movement.MoveTo(destination, Stats.MoveSpeed);
        } 
    }
}
