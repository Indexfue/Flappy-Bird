using UnityEngine;

namespace FSM.States
{
    public class BeginningScreenLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        public BeginningScreenLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter Beginning Start screen");
            _levelStateMachine.EnterIn<StartLevelState>();
        }

        public void Exit()
        {
            Debug.Log("Exit Beginning Start screen");
        }
    }
}
