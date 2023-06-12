using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    //private void Update() => transform.Translate(Vector3.right * _speed * Time.deltaTime);

    private void Jump() => _rigidbody.AddForce(Vector2.up, ForceMode2D.Impulse);
}
