using System;
using FSM.States;
using UnityEngine;
using UnityEngine.Events;
using Obstacles;

namespace Players
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Player : MonoBehaviour
    {
        public static event UnityAction Died;

        private void OnEnable()
        {
            BeginningScreenLevelState.Entered += OnLevelBeginScreen;
            StartLevelState.Entered += OnLevelStart;
        }

        private void OnDisable()
        {
            BeginningScreenLevelState.Entered -= OnLevelBeginScreen;
            StartLevelState.Entered -= OnLevelStart;
        }

        private void Die()
        {
            gameObject.SetActive(false);
            Died?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                Die();
            }
        }

        private void OnLevelBeginScreen()
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }

        private void OnLevelStart()
        {
            GetComponent<Rigidbody2D>().simulated = true;
        }
    }
}

