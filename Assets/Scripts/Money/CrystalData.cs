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

[CreateAssetMenu(menuName ="Prototipo/Data/Money")]
public class CrystalData : ScriptableObject, IMoneyData
{
    [SerializeField] private int _value;
    [SerializeField] private Material _material;
    public int Value => _value;

    public Material Material => _material;
}
