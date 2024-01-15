using Controller;
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
        private HealthController _healthController;

        private CharacterRuntimeStats _runtimeStats;

        private ExpController _expController;

        private void Start()
        {
            _runtimeStats = new CharacterRuntimeStats(Stats);
            _expController = new ExpController(_runtimeStats);
            _movement.moveSpeed = _runtimeStats.MoveSpeed;
            _healthController.InitializeHealth(_runtimeStats);

            _healthController.OnHealthDepleted += HandleDeath;
        }

        private void HandleDeath()
        {
            Destroy(gameObject);
        }
    }
}
