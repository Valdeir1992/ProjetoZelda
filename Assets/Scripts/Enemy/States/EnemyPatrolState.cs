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

public class EnemyPatrolState : EnemyState
{
    private Vector3 _currentObject;
    private int _count;
    public EnemyPatrolState(EnemyIA control):base(control) { }

    public override IEnumerator Enter()
    {
        _currentObject = _controller.Enemy.PatrolPoints[_count].position;

        float distaceSqr = (_currentObject - _controller.transform.position).sqrMagnitude;

        if (distaceSqr <= (0.1f * 0.1f))
        {
            _count++;

            if (_count >= _controller.Enemy.PatrolPoints.Length)
            {
                _count = 0;
            }

            _currentObject = _controller.Enemy.PatrolPoints[_count].position;
        }

        _controller.Enemy.Walk();

        return base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        float distaceSqr = (_currentObject - _controller.transform.position).sqrMagnitude; 

        if(distaceSqr <=(0.1f * 0.1f))
        {
            _controller.ChangeState(typeof(EnemySearchState).Name);
        }
    }
    public override void UpdatePhysic()
    {
        _controller.Enemy.Move(_currentObject);
    }
}
