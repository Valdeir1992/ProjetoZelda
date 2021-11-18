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

public class EnemySearchState : EnemyState
{
    private float _randomTime;
    private float _elapsedTime; 
    public EnemySearchState(EnemyIA control) : base(control) { }

    public override IEnumerator Enter()
    { 

        _randomTime = Random.Range(1, 10);

        _elapsedTime = 0;

        _controller.Enemy.Idle(); 

        return base.Enter();
    }

    public override void UpdateLogic()
    {
        _elapsedTime += Time.deltaTime;

        if(_randomTime <= _elapsedTime)
        { 
            _controller.ChangeState(typeof(EnemyPatrolState).Name);
        }
        base.UpdateLogic(); 
    }
    public override void UpdatePhysic()
    {
        base.UpdatePhysic();
    }
}
