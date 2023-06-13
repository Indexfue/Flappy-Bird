using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public static UnityAction InputHandled;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InputHandled?.Invoke();
            }
        }
    }
}
