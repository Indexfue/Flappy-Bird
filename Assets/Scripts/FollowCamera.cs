using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float _smoothRate;
    [SerializeField] private Vector3 _offset;
    
    private Transform _toFollow;
    private Vector3 _currentVelocity;
    
    public void Initialize(GameObject toFollow) => _toFollow = toFollow.transform;

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
