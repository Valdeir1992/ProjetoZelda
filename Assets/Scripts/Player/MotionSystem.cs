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

public class MotionSystem : MonoBehaviour, IMotionSystem
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private MotionState _state;
    private IMediator _mediator;
    private bool _canMove = true; 
    private float _playerVelocityY;
    [SerializeField] private bool _isGrounded;
    private bool _jump;
    private LayerMask _layer;
    private CharacterController _controller;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES 
    public MotionState Status => _state;
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _layer = LayerMask.GetMask("Ground");
    }
    private void Update()
    {
        ApplyGravity();

        _jump = _mediator.Inputs.Jump;

        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _controller.skinWidth, _layer);

        
    }
    private void FixedUpdate()
    {
        Move(_mediator.Inputs);
    }
    #endregion

    #region OWN METHODS 
    public void Configure(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Move(IInputs input)
    {
        Vector3 finalDirection = Camera.main.transform.TransformDirection(input.Motion);
        finalDirection.y = 0;
        finalDirection = finalDirection.normalized;

        if (_canMove)
        {
            ApplyRotation(finalDirection);

            float value = Mathf.Abs(input.Motion.magnitude);
            float velocity = 0;
            if(value <= 0.5f)
            {
                velocity = _mediator.Data.WalkVelocity;
            }
            else
            {
                velocity = _mediator.Data.RunVelocity;
            }
            ApplyMotion(finalDirection,velocity);

            if (_isGrounded)
            {
                value = _controller.velocity.magnitude;

                if (value < _mediator.Data.WalkVelocity)
                {
                    _state = MotionState.IDLE;
                }
                else if (value < _mediator.Data.RunVelocity)
                {
                    _state = MotionState.WALK;
                }
                else if (value >= _mediator.Data.RunVelocity)
                {
                    _state = MotionState.RUN;
                }
            }
        }
    }

    public void Stop()
    {
        _canMove = false; 
    }

    public void Play()
    {
        _canMove = true; 
    }

    private void ApplyMotion(Vector3 direction, float velocity)
    {   
        _controller.Move(direction * (Time.deltaTime * velocity)); 
        _mediator.Motion(_controller.velocity.magnitude * velocity);
    }

    public void MoveWithoutController(Vector3 direction, float velocity)
    { 
        ApplyMotion(direction, velocity);
    }

    private void ApplyRotation(Vector3 direction)
    {
        if (direction.sqrMagnitude == 0) return;
        transform.forward = direction;
    }

    private void ApplyGravity()
    {
        if (_isGrounded)
        {  
            if (_jump)
            {
                _playerVelocityY = Mathf.Sqrt(-2 * Physics.gravity.y * _mediator.Data.JumpHeight);

                _mediator.Jump();
            }
            else
            { 
                _playerVelocityY = 0; 
            }
        }
        else
        { 
            _playerVelocityY += Physics.gravity.y * Time.deltaTime;
        }

        _controller.Move(new Vector3(0, _playerVelocityY, 0) * Time.deltaTime);
    }
    #endregion

    #region COROUTINES
    #endregion
} 