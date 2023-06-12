using System;
using System.Collections;
using System.Collections.Generic;
using FSM.States;
using UnityEngine;

public class LevelInstance : MonoBehaviour
{
    private LevelStateMachine _levelStateMachine;

    private void Awake()
    {
        _levelStateMachine = new LevelStateMachine();
        
        _levelStateMachine.EnterIn<InitializeLevelState>();
    }
}