using UnityEngine;

namespace FSM.States
{
    public class StartLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        public StartLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter start level");
        }

        public void Exit()
        {
            Debug.Log("Exit start level");
        }
    }
}
