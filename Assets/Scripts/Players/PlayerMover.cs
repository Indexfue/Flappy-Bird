using System.Collections;
using FSM.States;
using UnityEngine;
using UnityEngine.Events;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private Rigidbody2D _rigidbody;
        private bool _isFlyRoutineStarted;
        private Coroutine _flyRoutine;

        public static event UnityAction Jumped;
        
        public float Speed { get => _speed; }
        public float JumpForce { get => _jumpForce; }

        private void Start() => _rigidbody = GetComponent<Rigidbody2D>();

        private void OnEnable()
        {
            PlayerInput.InputHandled += Jump;
            StartLevelState.Entered += Fly;
            EndLevelState.Entered += Stop;
        }

        private void OnDisable()
        {
            PlayerInput.InputHandled -= Jump;
            StartLevelState.Entered -= Fly;
            EndLevelState.Entered -= Stop;
        }

        private void Jump()
        {
            _rigidbody.velocity = new Vector2(0, 0);
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            Jumped?.Invoke();
        }
        
        private void Fly() => _flyRoutine = StartCoroutine(FlyRoutine());

        private void Stop()
        {
            if (_isFlyRoutineStarted)
            {
                StopCoroutine(_flyRoutine);
                _isFlyRoutineStarted = false;
            }
        }

        private IEnumerator FlyRoutine()
        {
            _isFlyRoutineStarted = true;
            
            while (true)
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
