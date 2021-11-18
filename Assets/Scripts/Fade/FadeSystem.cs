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

public class FadeSystem : MonoBehaviour
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    [SerializeField] private Image _fade;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _fade.color = new Color(0, 0, 0, 1);
    }
    private void OnEnable()
    {
        MessageSystem.Instance.Register(typeof(LoadSceneMessage), this.MessageHandler);
        StartCoroutine(Coroutine_FadeIn(0.5f));
    }

    private void OnDisable()
    {
        MessageSystem.Instance.UnRegister(typeof(LoadSceneMessage), this.MessageHandler);
    }
    #endregion

    #region OWN METHODS
    private bool MessageHandler(Message message)
    {
        LoadSceneMessage lSM = message as LoadSceneMessage;

        if (!System.Object.ReferenceEquals(lSM, null))
        {
            StartCoroutine(Coroutine_FadeOut(0.5f));
        }
        return false;
    }
    #endregion

    #region COROUTINES
    private IEnumerator Coroutine_FadeOut(float time)
    {
        Color startColor = _fade.color;
        Color finalColor = new Color(startColor.r, startColor.g, startColor.b, 1);
        float elapsedTime = 0;
        yield return new WaitForSeconds(time);

        while (true)
        {
            elapsedTime += Time.deltaTime;

            _fade.color = Color.Lerp(startColor, finalColor, elapsedTime);

            if(elapsedTime >= 1)
            {
                break;
            }
            yield return null;
        }
        
    }

    private IEnumerator Coroutine_FadeIn(float time)
    {
        Color startColor = _fade.color;
        Color finalColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        float elapsedTime = 0;
        yield return new WaitForSeconds(time);

        while (true)
        {
            elapsedTime += Time.deltaTime;

            _fade.color = Color.Lerp(startColor, finalColor, elapsedTime);

            if (elapsedTime >= 1)
            {
                break;
            }
            yield return null;
        }

    }
    #endregion
}
