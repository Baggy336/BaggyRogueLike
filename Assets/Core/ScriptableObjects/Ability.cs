using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

namespace Core
{
    public enum AbilityKey
    {
        Q,
        W,
        E,
        R
    }

    [CreateAssetMenu(fileName = "New Ability", menuName = "Abilities")]
    public class Ability : ScriptableObject
    {
        public AbilityKey CastKey;
        public KeyCode CastKeyCode;
        public string AbilityName;
        public string AbilityDescription;
        public int Cooldown;
        public int Damage;
        private float lastUsed;

        public void Initialize()
        {
            CastKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), CastKey.ToString());
            lastUsed = -Mathf.Infinity;
        }

        public bool IsOffCooldown()
        {
            return Time.time >= lastUsed + Cooldown;
        }

        public void Use()
        {
            lastUsed = Time.time;
        }
    }
}
