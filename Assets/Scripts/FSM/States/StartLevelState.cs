using Players;
using Scores;
using UnityEngine;
using UnityEngine.Events;

namespace FSM.States
{
    public class StartLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;
        private readonly Score _score;
        
        public static event UnityAction Entered;
        public static event UnityAction Exited;

        public StartLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
            _score = new Score();
        }
        
        public void Enter()
        {
            Player.Died += OnDie;
            Entered?.Invoke();
            Debug.Log("Enter start level");
        }

        public void Exit()
        {
            Player.Died -= OnDie;
            Exited?.Invoke();
            Debug.Log("Exit start level");
        }

        private void OnDie()
        {
            _levelStateMachine.EnterIn<EndLevelState>();
        }
    }
}
