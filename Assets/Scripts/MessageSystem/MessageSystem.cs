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

public delegate bool MessageHandlerDelegate(Message message);

public class MessageSystem : Singleton<MessageSystem>
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES 
    private Dictionary<System.Type, List<MessageHandlerDelegate>> _dictMessage = new Dictionary<System.Type, List<MessageHandlerDelegate>>();
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        if(!System.Object.ReferenceEquals(Instance,null) && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    #region OWN METHODS
    public bool Register(System.Type type, MessageHandlerDelegate message)
    {
        if (_dictMessage.ContainsKey(type))
        {
            _dictMessage[type].Add(message);
            return true;
        }
        else
        {
            List<MessageHandlerDelegate> list = new List<MessageHandlerDelegate>();

            list.Add(message);

            _dictMessage.Add(type, list);

            return true;
        }  
    }
    public bool UnRegister(System.Type type, MessageHandlerDelegate message)
    {
        if (_dictMessage.ContainsKey(type))
        {
            List<MessageHandlerDelegate> list = _dictMessage[type];
            list.Remove(message);
            return true;
        } 
        return false;
    }

    public void Notify(Message message)
    {
        if (_dictMessage.ContainsKey(message.GetType()))
        {
            foreach (var item in _dictMessage[message.GetType()])
            {
                if (item.Invoke(message)) break;
            }
        }
    }

    public void Notify(Message message, float delay)
    {
        StartCoroutine(Coroutine_NotifyDelay(message,delay));
    }
#endregion

#region COROUTINES
    private IEnumerator Coroutine_NotifyDelay(Message message, float delay)
    {
        yield return new WaitForSeconds(delay);
        Notify(message);
    }
#endregion
}

public class Message
{

} 
