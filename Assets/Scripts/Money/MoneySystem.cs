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

public class MoneySystem : MonoBehaviour
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    [SerializeField] private GameplayData _data;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    private void OnEnable()
    {
        MessageSystem.Instance.Register(typeof(MoneyMessage), this.MessageHandler);
    }
    private void Start()
    {
        MessageSystem.Instance.Notify(new HUDGameplayerMessage("Start", _data.AmountOfCrystals, 0));

    }
    private void OnDisable()
    {
        MessageSystem.Instance.UnRegister(typeof(MoneyMessage), this.MessageHandler); 
    }
    #endregion

    #region OWN METHODS
    private bool MessageHandler(Message message)
    {
        MoneyMessage mM = message as MoneyMessage;

        if (!System.Object.ReferenceEquals(mM, null))
        {
            _data.AmountOfCrystals += mM.Value;
            MessageSystem.Instance.Notify(new HUDGameplayerMessage("UpdateCrystal", _data.AmountOfCrystals, mM.Value));
        }
        return false;
    }
#endregion

#region COROUTINES
#endregion
}
