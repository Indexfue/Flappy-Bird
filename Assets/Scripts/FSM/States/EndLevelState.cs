using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.States
{
    public class EndLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        public EndLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter End state");
        }

        public void Exit()
        {
            Debug.Log("Exit End state");
        }
    }
}
