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

public class TriggerZone : MonoBehaviour
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private TriggerAction[] _triggerActions;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _triggerActions = GetComponents<TriggerAction>();
    }
    private void OnTriggerEnter(Collider other)
    { 

        if(other.TryGetComponent(out IMediator mediator))
        { 
            foreach (var item in _triggerActions)
            {
                item.OnEnter(mediator);
            }
        }
    }
    #endregion

    #region OWN METHODS
    #endregion

    #region COROUTINES
    #endregion
}
