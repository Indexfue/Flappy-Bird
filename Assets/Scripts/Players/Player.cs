using FSM.States;
using UnityEngine;
using UnityEngine.Events;
using Obstacles;

namespace Players
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        public static event UnityAction Died;

        private void Start() => _rigidbody = GetComponent<Rigidbody2D>();

        private void OnEnable()
        {
            BeginningScreenLevelState.Entered += OnLevelBeginScreen;
            PrepareStartLevelState.Entered += OnPrepareLevel;
            StartLevelState.Entered += OnLevelStart;
            EndLevelState.Entered += OnLevelEnd;
        }

        private void OnDisable()
        {
            BeginningScreenLevelState.Entered -= OnLevelBeginScreen;
            PrepareStartLevelState.Entered -= OnPrepareLevel;
            StartLevelState.Entered -= OnLevelStart;
            EndLevelState.Entered -= OnLevelEnd;
        }

        private void Die() => Died?.Invoke();

        private void SetSimulatePhysics(bool state) => _rigidbody.simulated = state;

        private void SetCoords(float x, float y) => transform.position = new Vector3(x, y);

        private void OnLevelBeginScreen() => SetSimulatePhysics(false);
        
        private void OnPrepareLevel()
        {
            SetSimulatePhysics(false);
            SetCoords(transform.position.x, 0);
        }

        private void OnLevelStart() => SetSimulatePhysics(true);

        private void OnLevelEnd() => SetSimulatePhysics(false);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                Die();
            }
        }
    }
}

