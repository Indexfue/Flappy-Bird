using UnityEngine;
using FSM.States;

[RequireComponent(typeof(Camera))]
public class FollowXAxisCamera : MonoBehaviour
{
    [SerializeField] private Transform _toFollow;
    [SerializeField] private float _smoothRate;
    [SerializeField] private Vector3 _offset;
    
    private Vector3 _currentVelocity;
    
    private readonly Vector3 _beginScreenOffset = new Vector3(7, 0, -10);
    private readonly Vector3 _levelStartOffset = new Vector3(3, 0, -10);

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
        Vector3 nextPosition = new Vector3(_toFollow.position.x, 0f, 0f) + _offset;
        
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            nextPosition, 
            ref _currentVelocity, 
            _smoothRate
        );
    }
    
    private void OnLevelBeginScreen()
    {
        _offset = _beginScreenOffset;
    }

    private void OnLevelPrepareStart()
    {
        _offset = _levelStartOffset;
    }
}
