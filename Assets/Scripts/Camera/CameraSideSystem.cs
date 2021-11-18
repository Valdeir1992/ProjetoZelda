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
using System.Linq;

public class CameraSideSystem : MonoBehaviour
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private CameraState _status;
    private IMediator _mediator;
    private bool _ative;
    private string _axis;
    private Transform _player;
    private Transform _target;
    private Vector2 _boundary;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES 
    public CameraState Status => _status;
    #endregion

    #region UNITY METHODS
    private void OnEnable()
    {
        MessageSystem.Instance.Register(typeof(CameraMessage), this.MessageHandler);
    }
    private void Update()
    {
        if (_ative)
        {
            Move(_axis);
        }
    } 

    private void OnDisable()
    {
        MessageSystem.Instance.UnRegister(typeof(CameraMessage), this.MessageHandler);
    }
    #endregion

    #region OWN METHODS 
    private void Move(string axis)
    {
        if (axis == "x")
        {
            float x = Mathf.Clamp(_player.position.x, _boundary.x, _boundary.y);

            _target.position = new Vector3(x, _target.position.y, _target.position.z);
        }
        else if (axis == "z")
        {
            float z = Mathf.Clamp(_player.position.z, _boundary.x, _boundary.y);

            _target.position = new Vector3(_target.position.x, _target.position.y, z);
        }
    }
    private bool MessageHandler(Message message)
    {
        CameraMessage cM = message as CameraMessage;

        if (!System.Object.ReferenceEquals(cM, null))
        {
            if (cM.State == CameraState.SIDE_ATIVE)
            {
                _ative = true;
                _player = ((MonoBehaviour)FindObjectsOfType<MonoBehaviour>().OfType<IMediator>().First()).transform;
                _axis = cM.Axis;
                _target = cM.Target;
                _boundary = cM.Boundary;
            }
            else if (cM.State == CameraState.SIDE_DISATIVE)
            {
                _ative = false;
            }
        }
        return false;
    }
    #endregion

    #region COROUTINES
    #endregion 

    public void Configure(IMediator mediator)
    {
        _mediator = mediator;
    }
}
