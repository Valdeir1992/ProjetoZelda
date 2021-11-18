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

public class HUDGameplayerMessage : Message
{
    public readonly string Action;
    public readonly int CrystalTotal;
    public readonly int AddCrystal;

    public HUDGameplayerMessage(string action, int crystalValue, int addCrystal)
    {
        Action = action;
        CrystalTotal = crystalValue;
        AddCrystal = addCrystal;
    }
}
