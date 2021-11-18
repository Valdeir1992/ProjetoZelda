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

public class TriggerLoadScene : TriggerAction
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    [SerializeField] private string _newScene;
    [SerializeField] private float _time;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    #endregion

    #region OWN METHODS
    #endregion

    #region COROUTINES
    #endregion
    public override void OnEnter(IMediator mediator)
    {
        MessageSystem.Instance.Notify(new LoadSceneMessage(_newScene,false,_time));
    }

    public override void OnExit(IMediator mediator)
    {
        
    }
}
