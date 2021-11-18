/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFiniteStateMachine
{ 
    IState CurrentState { get; }

    void ChangeState(string newState);

    void DefaultState(IState defaultState);

    void UpdateLogic();

    void UpdatePhysic();

    void AddBehavior(params IState[] states);
}
