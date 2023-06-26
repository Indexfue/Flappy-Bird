using Players;
using UnityEngine;
using UnityEngine.Events;

namespace Scores
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public class ScoreTrigger : MonoBehaviour
    {
        public static event UnityAction Triggered;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                Triggered?.Invoke();
            }
        }
    }
}

