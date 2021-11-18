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
using TMPro;
using System;

public class HUDGameplayerSystem : MonoBehaviour
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private Queue<int> _queueValue = new Queue<int>();
    private int _currentValue;
    private IEnumerator _coroutine; 
    [SerializeField] private TextMeshProUGUI _crystalsText;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    private void OnEnable()
    {
        MessageSystem.Instance.Register(typeof(HUDGameplayerMessage), this.MessageHandler);
    }
    private void Start()
    {
        InvokeRepeating("TriggerQueue", 0, 0.01f); 
    }
    private void OnDisable()
    {
        MessageSystem.Instance.UnRegister(typeof(HUDGameplayerMessage), this.MessageHandler);
    }
    #endregion

    #region OWN METHODS
    private bool MessageHandler(Message message)
    {
        HUDGameplayerMessage hGM = message as HUDGameplayerMessage;

        if (!System.Object.ReferenceEquals(hGM, null))
        {
            switch (hGM.Action)
            {
                case "UpdateCrystal":
                    UpdateCrystals(hGM.AddCrystal);
                    break;
                case "Start":
                    _currentValue = hGM.CrystalTotal;
                    UpdateText();
                    break;
            }
        }
        return false;
    } 

    private void UpdateCrystals(int crystalValue)
    {
        _queueValue.Enqueue(crystalValue);
    }

    private void TriggerQueue()
    {
        if(_queueValue.Count > 0 && System.Object.ReferenceEquals(_coroutine, null))
        {
            _coroutine = Coroutine_UpdateCrystal(_queueValue.Dequeue());
            StartCoroutine(_coroutine);
        }
    }
    #endregion

    #region COROUTINES
    private IEnumerator Coroutine_UpdateCrystal(int value)
    {
        while(value > 0)
        {
            value--;
            _currentValue++;
            UpdateText();
            yield return new WaitForSeconds(0.1f);
        }
        _coroutine = null;
        yield break;
    }

    private void UpdateText()
    {
        _crystalsText.text = $"x {_currentValue:00}";
    }
    #endregion
}
