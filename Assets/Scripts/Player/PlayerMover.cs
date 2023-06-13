using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            PlayerInput.InputHandled += Jump;
        }

        private void Update() => transform.Translate(Vector3.right * _speed * Time.deltaTime);

        private void Jump()
        {
            _rigidbody.velocity = new Vector2(0, 0);
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void OnDie()
        {
            
        }
    }
}
