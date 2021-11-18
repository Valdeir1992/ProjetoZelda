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

public class TriggerMoviment : TriggerAction
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
    public override void OnEnter(IMediator mediator)
    {
        mediator.MoveDelay(1,Vector3.right,3);
    }

    public override void OnExit(IMediator mediator)
    {
         
    }
    #endregion

    #region COROUTINES
    #endregion

}
