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

[CreateAssetMenu(menuName ="Prototipo/Data/Enemy")]
public class EnemyData : ScriptableObject, IEnemyData
{
    [SerializeField] private float _runVelocity;
    [SerializeField] private float _walkVelocity;
    [SerializeField] private float _fieldOfVision;

    public float RunVelocity { get => _runVelocity;}
    public float WalkVelocity { get => _walkVelocity;}
    public float FieldOfVision { get => _fieldOfVision;}
}
