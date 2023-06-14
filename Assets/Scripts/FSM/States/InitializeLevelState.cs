using UnityEngine;
using UnityEngine.Events;
using FSM.States;
using UI;

namespace FSM.States
{
    public class InitializeLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;
        
        public static event UnityAction Entered;
        public static event UnityAction Exited;

        public InitializeLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter initialize");
            Initialize();
            
            _levelStateMachine.EnterIn<BeginningScreenLevelState>();
        }

        public void Exit()
        {
            Debug.Log("Exit initialize");
        }

        private void Initialize()
        {
            //Object UI = Resources.Load(GameConstants.UI_ELEMENTS_PATH);
            //Object.Instantiate(UI);
            GameObject.FindObjectOfType<UIEventHandler>().Initialize();
        }
    }
}
