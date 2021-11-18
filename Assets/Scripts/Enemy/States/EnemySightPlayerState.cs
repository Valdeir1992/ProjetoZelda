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

public class EnemySightPlayerState : EnemyState
{  
    private IMediator _player;
    private Transform _playerTransform;
    public EnemySightPlayerState(EnemyIA control) : base(control) { }

    public override IEnumerator Enter()
    {
        _player = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<IMediator>().First();

        if (!System.Object.ReferenceEquals(_player, null))
        {
            _playerTransform = ((MonoBehaviour)_player).transform;
            _controller.Enemy.Idle();
        }
        MessageSystem.Instance.Notify(new GameplayMessage("GameOver"));
        return base.Enter();
    }

    public override void UpdateLogic()
    {
        _controller.transform.LookAt(_playerTransform, Vector3.up);
    }
    public override void UpdatePhysic()
    {
         
    }
}
