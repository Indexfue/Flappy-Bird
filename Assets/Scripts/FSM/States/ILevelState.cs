using UnityEngine.Events;

namespace FSM.States
{
    public interface ILevelState
    {
        void Enter();
        void Exit();
    }
}

