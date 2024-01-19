using Controller;
using UnityEngine;
using Domain;
using Core;

namespace Controller
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        public CharacterStats Stats;

        [SerializeField]
        private CharacterMovementController _characterMovement;

        [SerializeField]
        private HealthController _healthController;

        [SerializeField]
        private AttackController _attackController;

        private CharacterRuntimeStats _runtimeStats;

        private ExpController _expController;

        private void Start()
        {
            _runtimeStats = new CharacterRuntimeStats(Stats);
            _expController = new ExpController(_runtimeStats);
            _characterMovement.moveSpeed = _runtimeStats.MoveSpeed;
            _characterMovement.rotationSpeed = _runtimeStats.TurnRadius;
            _healthController.InitializeHealth(_runtimeStats);
            _attackController.InitializeAttackController(_runtimeStats);

            _healthController.OnHealthDepleted += HandleDeath;
        }

        private void HandleDeath()
        {
            Destroy(gameObject);
        }
    }
}
