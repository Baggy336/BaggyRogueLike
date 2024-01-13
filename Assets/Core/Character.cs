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

        private void Start()
        {
            _movement.moveSpeed = Stats.MoveSpeed;
        }

        private void Update()
        {

        }
    }
}
