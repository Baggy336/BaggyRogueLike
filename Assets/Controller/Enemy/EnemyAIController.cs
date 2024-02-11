using Domain;
using System;
using UnityEngine;

namespace Controller
{
    public class EnemyAIController : MonoBehaviour
    {
        public static Action<Vector3> OnEnemyAIMovementInput;

        public static Action<GameObject> EnemyAttackTarget;

        [SerializeField]
        private GameObject _target;

        private HealthController _healthController;

        private EnemyAttackController _enemyAttackController;

        private EnemyRuntimeStats _runtimeStats;


        public void InitializeEnemyAI(EnemyRuntimeStats runtimeStats, HealthController healthController, EnemyAttackController enemyAttackController)
        {
            _healthController = healthController;
            _runtimeStats = runtimeStats;
            _enemyAttackController = enemyAttackController;
        }

        private void Update()
        {
            HandleMovementTarget();
            HandleAttack();
        }

        private void HandleMovementTarget()
        {
            if(_target != null)
            {
                MovementInput(CalculateMovementTargetBasedOnAttackRange());
            }
        }

        private Vector3 CalculateMovementTargetBasedOnAttackRange()
        {
            Vector3 directionToTarget = (_target.transform.position - transform.position).normalized;

            Vector3 movementPoint = _target.transform.position - (directionToTarget * _runtimeStats.AttackRange);

            return movementPoint;
        }

        private void MovementInput(Vector3 location)
        {
            OnEnemyAIMovementInput?.Invoke(location);
        }

        private void HandleAttack()
        {
            if(_target != null && _enemyAttackController.IsInAttackRange(_runtimeStats, _target))
            {
                EnemyAttackTarget?.Invoke(_target);
            }
        }
    }
}
