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

public class CrystalSystem : MonoBehaviour, ICrystalSystem,ICrystalPersistence
{
    #region PUBLIC VARIABLES
    #endregion

    #region PRIVATE VARIABLES
    private IMoneyData _data;
    private string _id;
    [SerializeField] private float _velocity;
    [SerializeField] private Object _moneyData;

    public string ID => _id;
    #endregion

    #region EVENTS
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _id = gameObject.GetInstanceID().ToString(); 
        _data = _moneyData as IMoneyData;
        GetComponent<MeshRenderer>().material = _data.Material; 
    }
    private void Start()
    {
        InvokeRepeating("RotateCrystal", 0, 0.01f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IMediator player))
        {
            gameObject.SetActive(false);
            Collect();
        }
    }
    #endregion

    #region OWN METHODS
    protected void RotateCrystal()
    {
        transform.Rotate(Vector3.up * _velocity);
    }
    public virtual void Collect()
    {
        MessageSystem.Instance.Notify(new MoneyMessage(_data.Value));
        PlayerPrefs.SetInt(_id, 1);
    }

    public bool Collected()
    {
        if (!PlayerPrefs.HasKey(_id))
        { 
            return false;
        }
        return true;
    }

    public void CheckPersistence()
    {
        if (Collected())
        {
            gameObject.SetActive(false);
        }
    }
    #endregion

    #region COROUTINES
    #endregion

}
