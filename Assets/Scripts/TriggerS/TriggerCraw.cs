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

public class TriggerCraw : TriggerAction
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
    #endregion

    #region COROUTINES
    #endregion
    public override void OnEnter(IMediator mediator)
    {
        mediator.Craw();
    }

    public override void OnExit(IMediator mediator)
    {
        
    }
}
