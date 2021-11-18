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

public class LoadSceneMessage : Message
{
    public readonly string NewScene;
    public readonly bool LoadAsync;
    public readonly float Delay;

    public LoadSceneMessage(string newScene, bool loadAsync)
    {
        NewScene = newScene;
        LoadAsync = loadAsync;
    }

    public LoadSceneMessage(string newScene, bool loadAsync, float delay)
    {
        NewScene = newScene;
        LoadAsync = loadAsync;
        Delay = delay; 
    }
}
