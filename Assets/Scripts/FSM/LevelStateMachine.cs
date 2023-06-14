using System;
using System.Collections.Generic;
using FSM.States;

public class LevelStateMachine
{
    private Dictionary<Type, ILevelState> _states;
    private ILevelState _currentState;

    public LevelStateMachine()
    {
        _states = new Dictionary<Type, ILevelState>()
        {
            [typeof(InitializeLevelState)] = new InitializeLevelState(this),
            [typeof(PrepareStartLevelState)] = new PrepareStartLevelState(this),
            [typeof(BeginningScreenLevelState)] = new BeginningScreenLevelState(this),
            [typeof(StartLevelState)] = new StartLevelState(this),
            [typeof(EndLevelState)] = new EndLevelState(this)
        };
    }

    public void EnterIn<TState>() where TState : ILevelState
    {
        if (_states.TryGetValue(typeof(TState), out ILevelState state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
