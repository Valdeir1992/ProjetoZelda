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
using UnityEngine.SceneManagement;

public class SceneLoadSystem : MonoBehaviour
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
    private void OnDisable()
    {
        MessageSystem.Instance.UnRegister(typeof(LoadSceneMessage), this.MessageHandler);
    }

    private void OnEnable()
    {
        MessageSystem.Instance.Register(typeof(LoadSceneMessage), this.MessageHandler);
    }
    #endregion

    #region OWN METHODS
    private bool MessageHandler(Message message)
    {
        LoadSceneMessage lSM = message as LoadSceneMessage;

        if (!System.Object.ReferenceEquals(lSM, null))
        {
            if(!lSM.LoadAsync)
            {
                StartCoroutine(Coroutine_Load(lSM.Delay, lSM.NewScene));
            }
        }
        return false;
    }
    #endregion

    #region COROUTINES
    private IEnumerator Coroutine_Load(float delay, string name)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(name,LoadSceneMode.Single);
    }
    #endregion
}
