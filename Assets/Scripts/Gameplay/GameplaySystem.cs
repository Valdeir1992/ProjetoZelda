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

public class GameplaySystem : MonoBehaviour
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
    private void OnEnable()
    {
        MessageSystem.Instance.Register(typeof(GameplayMessage), this.MessageHandler);
    }
    private void OnDisable()
    {
        MessageSystem.Instance.UnRegister(typeof(GameplayMessage), this.MessageHandler);

    }
    #endregion

    #region OWN METHODS
    private bool MessageHandler(Message message)
    {
        GameplayMessage gM = message as GameplayMessage;

        if (!System.Object.ReferenceEquals(gM, null))
        {
            switch (gM.Actions)
            {
                case "GameOver":
                    GameOver();
                    break;
            }
        }
        return false;
    }

    private void GameOver()
    {
        MessageSystem.Instance.Notify(new PlayerMessage("Stop"));
        MessageSystem.Instance.Notify(new LoadSceneMessage(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, false),2);
    }
#endregion

#region COROUTINES
#endregion
}
