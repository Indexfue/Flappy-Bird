using UnityEngine;

namespace FSM.States
{
    public class TutorialLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        public TutorialLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter Tutorial");
            _levelStateMachine.EnterIn<StartLevelState>();
        }

        public void Exit()
        {
            Debug.Log("Exit Tutorial");
        }
    }
}
