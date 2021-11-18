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

public interface IEnemyData
{ 
    float RunVelocity { get; } 
    float WalkVelocity { get; }
    float FieldOfVision { get; }
}
