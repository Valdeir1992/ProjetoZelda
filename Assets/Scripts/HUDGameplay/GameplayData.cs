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

[CreateAssetMenu(menuName ="Prototipo/Data/Gameplay")]
public class GameplayData : ScriptableObject,IGameplayData
{
    private int _amountOfCrystals;

    public int AmountOfCrystals { get => _amountOfCrystals; set => _amountOfCrystals = value;}

    private void OnEnable()
    {
        if (Application.isEditor)
        {
            _amountOfCrystals = 0;
        }
    }
}
