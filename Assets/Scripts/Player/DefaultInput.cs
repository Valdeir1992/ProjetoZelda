/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using UnityEngine;

public class DefaultInput : IInputs
{
    public Vector3 Motion => new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

    public bool Jump => Input.GetKeyDown(KeyCode.Space);
}