using UnityEngine;

namespace Obstacles
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObstacleDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
