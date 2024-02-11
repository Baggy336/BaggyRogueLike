using Core;
using Domain;
using UnityEngine;

namespace Controller
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        public EnemyStats Stats;

        [SerializeField]
        private EnemyMovementController _enemyMovement;

        [SerializeField]
        private HealthController _healthController;

        [SerializeField]
        private EnemyAIController _enemyAIController;

        [SerializeField]
        private EnemyAttackController _enemyAttackController;

        private EnemyRuntimeStats _runtimeStats;

        private void Start()
        {
            _runtimeStats = new EnemyRuntimeStats(Stats);
            _enemyMovement.moveSpeed = _runtimeStats.MoveSpeed;
            _enemyMovement.rotationSpeed = _runtimeStats.TurnRadius;
            _healthController.InitializeHealth(_runtimeStats);
            _enemyAIController.InitializeEnemyAI(_runtimeStats, _healthController, _enemyAttackController);
            _healthController.OnHealthDepleted += HandleDeath;
        }

        private void HandleDeath()
        {
            Destroy(gameObject);
        }
    }
}
