using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Player : MonoBehaviour
    {
        public static event UnityAction Died;

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
    }
}

