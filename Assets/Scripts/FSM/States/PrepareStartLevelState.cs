using Players;
using UnityEngine;
using UnityEngine.Events;

namespace FSM.States
{
    public class PrepareStartLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;
        
        public static event UnityAction Entered;
        public static event UnityAction Exited;

        public PrepareStartLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter Prepare");
            PlayerInput.InputHandled += OnInputHandle;
            Entered?.Invoke();
        }

        public void Exit()
        {
            Debug.Log("Exit Tutorial");
            PlayerInput.InputHandled -= OnInputHandle;
            Exited?.Invoke();
        }

        private void OnInputHandle()
        {
            _levelStateMachine.EnterIn<StartLevelState>();
        }
    }
}
