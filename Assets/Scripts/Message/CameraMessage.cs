/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/

using UnityEngine;

public sealed class CameraMessage : Message
{
    public readonly CameraState State;
    public readonly Vector3 Position;
    public readonly Transform Target;
    public readonly string Axis;
    public readonly Vector2 Boundary;
    public CameraMessage(CameraState state)
    {
        State = state;
    }

    public CameraMessage(CameraState state, Vector3 position, Transform target, string axis, Vector2 boundary)
    {
        State = state;
        Position = position;
        Target = target;
        Axis = axis;
        Boundary = boundary;
    }
}
