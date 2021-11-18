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

public interface IMotionSystem : ISystem<MotionState>,IConfigure
{
    void Move(IInputs input);
    void MoveWithoutController(Vector3 direction, float velocity);
    void Play();
    void Stop();
}
