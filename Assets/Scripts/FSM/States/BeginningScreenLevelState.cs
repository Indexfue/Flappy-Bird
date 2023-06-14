using UnityEngine;
using UnityEngine.Events;
using UI;

namespace FSM.States
{
    public class BeginningScreenLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;
        
        public static event UnityAction Entered;
        public static event UnityAction Exited;

        public BeginningScreenLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter Beginning Start screen");
            LevelBeginningUI.OnPlayClicked += OnPlayClick;
            Entered?.Invoke();
        }

        public void Exit()
        {
            Debug.Log("Exit Beginning Start screen");
            LevelBeginningUI.OnPlayClicked -= OnPlayClick;
            Exited?.Invoke();
        }

        private void OnPlayClick()
        {
            _levelStateMachine.EnterIn<PrepareStartLevelState>();
        }
    }
}
