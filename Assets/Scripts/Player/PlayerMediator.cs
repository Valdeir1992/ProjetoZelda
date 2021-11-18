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

public class PlayerMediator : MonoBehaviour, IMediator
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private IPlayerData _interfaceData;
    private IInputs _inputs = new DefaultInput();
    private IMotionSystem _motionSystem;
    private IAnimationSystem _animationSystem;
    [SerializeField] private Object _data;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES 
    public IInputs Inputs => _inputs;

    public IPlayerData Data => _interfaceData;
     
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _interfaceData = _data as IPlayerData;

        _motionSystem = GetComponent<IMotionSystem>();
        _motionSystem.Configure(this);

        _animationSystem = GetComponent<IAnimationSystem>();
        _animationSystem.Configure(this);
    }
    private void OnEnable()
    {
        MessageSystem.Instance.Register(typeof(PlayerMessage), this.MessageHandler);

    }

    private void OnDisable()
    {
        MessageSystem.Instance.UnRegister(typeof(PlayerMessage), this.MessageHandler);
    }
    #endregion

    #region OWN METHODS
    private void Stop()
    {
        _animationSystem.Can = false;
        _motionSystem.Stop();
    }
    private void Play()
    {
        _animationSystem.Can = true;
        _motionSystem.Play();
    }
    public void Jump()
    {
        
    }
    public void Craw()
    {
        _animationSystem.Craw();
    }

    public void Up()
    {
        _animationSystem.Up();
    } 

    public void Motion(float velocity)
    {
        _animationSystem.SetAnimationMoviment(velocity);
    }

    public void Move(Vector3 direction, float time)
    {
        StartCoroutine(Coroutine_Move(direction,time));
    }


    public void MoveDelay(float delay, Vector3 direction, float time)
    {
        StartCoroutine(Coroutine_Delay(delay, Coroutine_Move(direction, time)));
    }

    private bool MessageHandler(Message message)
    {
        PlayerMessage pM = message as PlayerMessage;

        if (!System.Object.ReferenceEquals(pM, null))
        {
            switch (pM.Actions)
            {
                case "Stop":
                    Stop();
                    break;
            }
        }
        return false;
    }
    #endregion

    #region COROUTINES
    private IEnumerator Coroutine_Move(Vector3 direction, float time)
    {
        Stop();

        float elapsedTime = 0; 
        MessageSystem.Instance.Notify(new CameraMessage(CameraState.STOP));
        while (true)
        {
            elapsedTime += Time.deltaTime;

            _motionSystem.MoveWithoutController(direction, _interfaceData.WalkVelocity);

            if (elapsedTime/time >= 1)
            {
                break;
            }
            yield return null;
        }
        Play();
    }

    private IEnumerator Coroutine_Delay(float time, IEnumerator coroutine)
    {
        Stop();

        yield return new WaitForSeconds(time);

        yield return coroutine;
    } 
    #endregion
}
