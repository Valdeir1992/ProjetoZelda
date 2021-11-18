/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/

using UnityEngine;

public interface IMediator
{
    IInputs Inputs { get; }

    IPlayerData Data { get; }

    void Motion(float velocity);

    void Jump();
    void Move(Vector3 direction, float time);

    void MoveDelay(float delay, Vector3 direction, float time);
    void Craw();
    void Up();
}
