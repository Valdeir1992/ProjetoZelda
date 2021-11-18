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

public class TriggerSideCamera : TriggerAction
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private Vector2 _boundary;
    [SerializeField] private string _axis;

    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    #endregion

    #region OWN METHODS
    public override void OnEnter(IMediator mediator)
    { 
        MessageSystem.Instance.Notify(new CameraMessage(CameraState.SIDE_ATIVE, (_cameraPosition.position - transform.position), _target, _axis, _boundary));
    }

    public override void OnExit(IMediator mediator)
    {
        
    }
    #endregion

    #region COROUTINES
    #endregion
}
