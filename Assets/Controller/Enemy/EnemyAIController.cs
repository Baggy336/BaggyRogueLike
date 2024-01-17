using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class EnemyAIController : MonoBehaviour
    {
        public static Action<Vector3> OnEnemyAIMovementInput;

        [SerializeField]
        private Transform _target;

        private HealthController _healthController;
        private EnemyRuntimeStats _runtimeStats;


        public void InitializeEnemyAI(EnemyRuntimeStats runtimeStats, HealthController healthController)
        {
            _healthController = healthController;
            _runtimeStats = runtimeStats;
        }

        private void Update()
        {
            HandleMovementTarget();
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
    }
}
