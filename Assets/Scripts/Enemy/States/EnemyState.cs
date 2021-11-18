/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyState : IState
{
    protected EnemyIA _controller;
    private IMediator _player;
    private Transform _playerTransform;
    public EnemyState(EnemyIA controller)
    {
        _controller = controller;
        _player = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<IMediator>().First();

        if (!System.Object.ReferenceEquals(_player, null))
        {
            _playerTransform = ((MonoBehaviour)_player).transform;
        }
    }

    public virtual IEnumerator Enter()
    {
        if (_controller.Debug)
        {
            Debug.Log($"Entrou no comportamento {GetType().Name}");
        }
        yield break;
    }

    public IEnumerator Exit()
    {
        if (_controller.Debug)
        {
            Debug.Log($"Saiu o comportamento {GetType().Name}");
        }
        yield break;
    }

    public virtual void UpdateLogic()
    {
        Vector3 playerDirection = _playerTransform.position - _controller.transform.position;

        float distanceSqr = Vector3.SqrMagnitude(playerDirection);

        if(distanceSqr <= (_controller.Enemy.Data.FieldOfVision * _controller.Enemy.Data.FieldOfVision))
        {
            float angle = Vector3.Angle(_controller.transform.forward, playerDirection);

            if(angle < 90)
            {
                if (!Physics.Linecast(_controller.transform.position, _playerTransform.position))
                {
                    _controller.ChangeState(typeof(EnemySightPlayerState).Name);
                }
            }
        }
    }

    public virtual void UpdatePhysic()
    {
        
    }
}
