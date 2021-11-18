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

public interface IAnimationSystem : ISystem<AnimationState>, IConfigure
{
    bool Can { get; set; }

    void Craw();
    void SetAnimationMoviment(float velocity);
    void Up();
}
