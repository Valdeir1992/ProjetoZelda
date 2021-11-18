/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using UnityEngine;

[CreateAssetMenu(menuName ="Prototipo/Data/Player")]
public sealed class PlayerData : ScriptableObject, IPlayerData
{
    [SerializeField] private float _walkVelocity;
    [SerializeField] private float _runVelocity;
    [SerializeField] private float _pushVelocity;
    [SerializeField] private float _jumpHeight;
    public float WalkVelocity => _walkVelocity;

    public float RunVelocity => _runVelocity;

    public float PushVelocity => _pushVelocity;

    public float JumpHeight => _jumpHeight;
}
