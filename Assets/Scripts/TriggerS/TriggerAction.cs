/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TriggerZone))]
public abstract class TriggerAction : MonoBehaviour
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    #endregion

    #region OWN METHODS 
    public abstract void OnEnter(IMediator mediator);

    public abstract void OnExit(IMediator mediator);
    #endregion

    #region COROUTINES
    #endregion
}
