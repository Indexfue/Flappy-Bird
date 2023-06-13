using UnityEngine;

namespace FSM.States
{
    public class InitializeLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        public InitializeLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter initialize");
            Initialize();
            
            _levelStateMachine.EnterIn<TutorialLevelState>();
        }

        public void Exit()
        {
            Debug.Log("Exit initialize");
        }

        private void Initialize()
        {

        }
    }
}
