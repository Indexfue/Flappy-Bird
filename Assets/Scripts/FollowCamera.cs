using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _toFollow;
    [SerializeField] private float _smoothRate;
    [SerializeField] private Vector3 _offset;
    
    private Vector3 _currentVelocity;

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            _toFollow.position + _offset, 
            ref _currentVelocity, 
            _smoothRate
        );
    }
}
