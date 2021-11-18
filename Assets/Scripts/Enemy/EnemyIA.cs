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

public class EnemyIA : MonoBehaviour, IFiniteStateMachine
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private Enemy _enemy;
    private bool _transition;
    [SerializeField] private bool _debug;
    private Dictionary<string, IState> _dicStates = new Dictionary<string, IState>();
    private IState _defaultState; 
    private IState _currentState;
    public IState CurrentState => _currentState;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    public Enemy Enemy { get => _enemy; }
    public bool Debug { get => _debug; }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
    #endregion

    #region OWN METHODS
    public void ChangeState(string newState)
    {
        StartCoroutine(Coroutine_ChangeState(newState));
    } 

    public IEnumerator Coroutine_ChangeState(string newState)
    {
        _transition = true;

        if (!System.Object.ReferenceEquals(_currentState, null))
        {
            yield return _currentState.Exit();
        }
        if (_dicStates.ContainsKey(newState))
        {
            _currentState = _dicStates[newState];
        }
        else
        {
            _currentState = _defaultState;
        }

        yield return _currentState.Enter();

        _transition = false;
    }

    public void DefaultState(IState defaultState)
    {
        _defaultState = defaultState;
        _currentState = _defaultState;
        ChangeState(defaultState.GetType().Name);
    }

    public void UpdateLogic()
    {
        if (!_transition)
        {
            _currentState.UpdateLogic();
        }
    }

    public void UpdatePhysic()
    {
        if (!_transition)
        {
            _currentState.UpdatePhysic();
        }
    } 
    public void AddBehavior(params IState[] states)
    {
        foreach (var item in states)
        {
            _dicStates.Add(item.GetType().Name, item);
        }
    }
    #endregion

    #region COROUTINES
    #endregion


}
