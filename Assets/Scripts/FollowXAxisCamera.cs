using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowXAxisCamera : MonoBehaviour
{
    [SerializeField] private Transform _toFollow;
    [SerializeField] private float _smoothRate;
    [SerializeField] private Vector3 _offset;
    
    private Vector3 _currentVelocity;

    private void LateUpdate()
    {
        Vector3 nextPosition = new Vector3(_toFollow.position.x, 0f, 0f) + _offset;
        
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            nextPosition, 
            ref _currentVelocity, 
            _smoothRate
        );
    }
}
