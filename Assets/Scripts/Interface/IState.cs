/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using System.Collections;
using UnityEngine;

public interface IState
{
    IEnumerator Enter();

    void UpdateLogic();

    void UpdatePhysic();

    IEnumerator Exit();
}
