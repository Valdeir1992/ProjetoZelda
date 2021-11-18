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

public class AnimationSystem : MonoBehaviour, IAnimationSystem
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private AnimationState _state;
    private IMediator _mediator;
    private bool _can = true;
    private Animator _anim;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES 
    public AnimationState Status => _state;

    public bool Can { get => _can; set => _can = value; }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float value = _anim.GetFloat("Velocity");

        if(value < _mediator.Data.WalkVelocity)
        {
            _state = AnimationState.IDLE;
        }
        else if(value < _mediator.Data.RunVelocity)
        {
            _state = AnimationState.WALK;
        }
        else if(value >= _mediator.Data.RunVelocity)
        {
            _state = AnimationState.RUN;
        }
    }
    #endregion

    #region OWN METHODS
    public void Configure(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void SetAnimationMoviment(float velocity)
    {  
        if(velocity > 0)
        {
            _anim.SetBool("Moving", true);
        }
        if (_can)
        {

            _anim.SetFloat("Velocity", velocity);
        }else
        {
            _anim.SetFloat("Velocity", 0);
        }
    }
    public void Craw()
    {
        _anim.SetBool("Craw", true);
    }

    public void Up()
    {
        _anim.SetBool("Craw", false);
    }
    #endregion

    #region COROUTINES
    #endregion

}
