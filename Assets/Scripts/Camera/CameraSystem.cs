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
using Cinemachine;
using System.Linq;

public class CameraSystem : MonoBehaviour, ICameraSystem
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private CameraState _state = CameraState.NORMAL;
    [SerializeField] private CinemachineFreeLook _cinemachineNormal;
    [SerializeField] private CinemachineVirtualCamera _cinemachineBack;
    [SerializeField] private CinemachineVirtualCamera _cinemachineSide;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES 
    public CameraState Status => _state;
    #endregion

    #region UNITY METHODS
    private void OnEnable()
    {
        MessageSystem.Instance.Register(typeof(CameraMessage), this.MessageHandler);
    }
    private void Start()
    {
        _cinemachineNormal.enabled = true;
        Transform player = ((MonoBehaviour)FindObjectsOfType<MonoBehaviour>().OfType<IMediator>().First()).transform;
        _cinemachineNormal.Follow = player;
        _cinemachineNormal.LookAt = player;

        _cinemachineBack.Follow = player;
        _cinemachineBack.LookAt = player;
    }
    private void OnDisable()
    {
        MessageSystem.Instance.UnRegister(typeof(CameraMessage), this.MessageHandler);
    } 
    #endregion

    #region OWN METHODS
    private bool MessageHandler(Message message)
    {
        CameraMessage cM = message as CameraMessage;

        if (!System.Object.ReferenceEquals(cM, null))
        {
            switch (cM.State)
            {
                case CameraState.BACK:
                    _cinemachineBack.enabled = true;
                    break;
                case CameraState.SIDE_ATIVE:
                    CameraSide(cM);
                    break;
                case CameraState.NORMAL:
                    _cinemachineSide.enabled = true;
                    break;
                case CameraState.STOP:
                    _cinemachineNormal.Follow = null;
                    break;
            }
        }
        return false;
    }

    private void CameraSide(CameraMessage cM)
    {
        _cinemachineSide.enabled = true;
        _cinemachineSide.Follow = cM.Target;
        _cinemachineSide.LookAt = ((MonoBehaviour)FindObjectsOfType<MonoBehaviour>().OfType<IMediator>().First()).transform;
        _cinemachineSide.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = cM.Position;
    }
    #endregion

    #region COROUTINES
    #endregion
}
