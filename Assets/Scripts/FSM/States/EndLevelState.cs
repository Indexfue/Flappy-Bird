using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace FSM.States
{
    public class EndLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;
        
        public static event UnityAction Entered;
        public static event UnityAction Exited;

        public EndLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Entered?.Invoke();
            LevelEndUI.OnOkClicked += OnOkClick;
            Debug.Log("Enter End state");
        }

        public void Exit()
        {
            Exited?.Invoke();
            LevelEndUI.OnOkClicked -= OnOkClick;
            Debug.Log("Exit End state");
        }

        private void OnOkClick()
        {
            _levelStateMachine.EnterIn<PrepareStartLevelState>();
        }
    }
}
