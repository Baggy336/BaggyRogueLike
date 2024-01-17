using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Domain
{
    public interface IRuntimeStats
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int AttackDamage { get; set; }
        public float MoveSpeed { get; set; }
        public float TurnRadius { get; set; }
    }
}
