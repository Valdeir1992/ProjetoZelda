/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PersistenceSystem : MonoBehaviour
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
    private void Start()
    {
        IPersistenceObject[] persistence = FindObjectsOfType<MonoBehaviour>().OfType<IPersistenceObject>().ToArray();

        foreach (var item in persistence)
        {
            item.CheckPersistence();
        }
    }
    #endregion

    #region OWN METHODS
    [ContextMenu("Clean")]
    public void CleanPersistence()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion

    #region COROUTINES
    #endregion
}
