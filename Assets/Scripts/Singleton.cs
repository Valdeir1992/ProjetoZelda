/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using UnityEngine;

public class Singleton<T>:MonoBehaviour where T: Component
{
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindOrCreateInstance();
            }
            return _instance;
        }
    }
    private static T _instance;

    private static T FindOrCreateInstance()
    {
        var instance = FindObjectOfType<T>();

        if (System.Object.ReferenceEquals(instance, null))
        {
            instance = new GameObject(typeof(T).Name).AddComponent<T>();
        }
        return instance;
    }
}
