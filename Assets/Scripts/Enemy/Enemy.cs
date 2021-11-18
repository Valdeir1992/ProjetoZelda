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

public class Enemy : MonoBehaviour
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private Animator _anin;
    private int _currentLife;
    protected IFiniteStateMachine _fSM;
    private IEnemyData _interfaceData;
    [SerializeField] protected Object _enemyData;
    [SerializeField] private Transform[] _patrolPoints;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    public Transform[] PatrolPoints { get => _patrolPoints; }

    public IEnemyData Data { get => _interfaceData; }
    #endregion

    #region UNITY METHODS
    public virtual void Awake()
    {
        _anin = GetComponent<Animator>();

        _interfaceData = _enemyData as IEnemyData;

        _fSM = GetComponent<IFiniteStateMachine>();

        _fSM.DefaultState(new EnemyPatrolState((EnemyIA)_fSM));

        _fSM.AddBehavior(new EnemyPatrolState((EnemyIA)_fSM), new EnemySearchState((EnemyIA)_fSM), new EnemySightPlayerState((EnemyIA)_fSM));
    }
    private void Update()
    {
        _fSM.UpdateLogic();
    }
    private void FixedUpdate()
    {
        _fSM.UpdatePhysic();
    }
    private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.DrawWireSphere(transform.position, _interfaceData.FieldOfVision);
        }
    }
    #endregion

    #region OWN METHODS  
    public void Move(Vector3 point,bool run = false)
    { 

        Vector3 direction = (point - transform.position).normalized;
        direction.y = 0;

        transform.forward = direction;

        float value = (run) ? _interfaceData.RunVelocity : _interfaceData.WalkVelocity;

        transform.position = transform.position + (direction) * Time.deltaTime * value;
    } 
    public void Idle()
    {
        _anin.SetBool("Move", false);
    }

    public void Walk()
    {
        _anin.SetBool("Move", true);
    }
    #endregion

    #region COROUTINES
    #endregion
}
