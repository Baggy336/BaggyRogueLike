using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class AttackController : MonoBehaviour
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
            InputController.OnAttackInput += SetAttackTarget;
        }

        private void Update()
        {
            HandleAttackRange();
        }

        private void HandleAttackRange()
        {
            if(attackTarget != null)
            {
                float distanceToTarget = Vector3.Distance(transform.position, attackTarget.transform.position);
                if (distanceToTarget > RuntimeStats.AttackRange && isAttacking == false)
                {
                    MoveIntoAttackRange?.Invoke(attackTarget.transform.position);
                }
                else
                {
                    StopMoving?.Invoke();
                    AttackTarget();
                }
            }
        }

        private void AttackTarget()
        {
            //TODO attack the target
            isAttacking = true;

            isAttacking = false;
        }

        private void SetAttackTarget(GameObject target)
        {
            attackTarget = target;
        }

        private void OnDestroy()
        {
            InputController.OnAttackInput -= SetAttackTarget;
        }

    }
}
