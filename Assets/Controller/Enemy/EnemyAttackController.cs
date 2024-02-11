using Domain;
using System;
using UnityEngine;

namespace Controller
{
    public class EnemyAttackController : MonoBehaviour
    {
        private GameObject attackTarget;

        private IRuntimeStats RuntimeStats;

        public static Action<Vector3> MoveIntoAttackRange;

        public static Action StopMoving;

        public bool isAttacking = false;

        public void InitializeAttackController(IRuntimeStats stats)
        {
            RuntimeStats = stats;
        }

        private void Start()
        {
            EnemyAIController.EnemyAttackTarget += SetAttackTarget;
        }

        private void Update()
        {
            HandleAttack();
        }

        public bool IsInAttackRange(EnemyRuntimeStats runtimeStats, GameObject target)
        {
            if(runtimeStats.AttackRange >= Vector3.Distance(transform.position, target.transform.position))
            {
                return false;
            }

            return true;
        }

        private void HandleAttack()
        {
            if (attackTarget != null)
            {
                StopMoving?.Invoke();
                AttackTarget();
            }
        }

        private void AttackTarget()
        {
            //TODO attack the target
            isAttacking = true;
            Debug.Log("Enemy Is Attacking");
            isAttacking = false;
        }

        private void SetAttackTarget(GameObject target)
        {
            attackTarget = target;
        }

        private void OnDestroy()
        {
            EnemyAIController.EnemyAttackTarget -= SetAttackTarget;
        }
    }
}
