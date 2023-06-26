using UnityEngine;
using FSM.States;
using UnityEngine.Serialization;

[RequireComponent(typeof(Camera))]
public class FollowXAxisCamera : MonoBehaviour
{
    [SerializeField] private Transform _toFollow;
    [SerializeField] private float _smoothRate;
    [SerializeField] private Vector3 _currentOffset;
    
    private Vector3 _currentVelocity;
    
    private readonly Vector3 _beginScreenOffset = new Vector3(3.5f, 0, -10);
    private readonly Vector3 _levelStartOffset = new Vector3(2.5f, 0, -10);

    private void OnEnable()
    {
        BeginningScreenLevelState.Entered += OnLevelBeginScreen;
        PrepareStartLevelState.Entered += OnLevelPrepareStart;
    }

    private void OnDisable()
    {
        BeginningScreenLevelState.Entered -= OnLevelBeginScreen;
        PrepareStartLevelState.Entered -= OnLevelPrepareStart;
    }

    private void LateUpdate()
    {
        Vector3 nextPosition = new Vector3(_toFollow.position.x, 0f, 0f) + _currentOffset;
        
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            nextPosition, 
            ref _currentVelocity, 
            _smoothRate
        );
    }
    
    private void OnLevelBeginScreen() => _currentOffset = _beginScreenOffset;

    private void OnLevelPrepareStart() => _currentOffset = _levelStartOffset;
}
