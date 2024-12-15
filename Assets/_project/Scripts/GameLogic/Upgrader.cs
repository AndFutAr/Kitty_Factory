using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrader : MonoBehaviour
{
    [SerializeField] private GameObject GettingObject;
    [SerializeField] private GameObject DeletingObject;
    [SerializeField] private GameObject _nextUpgrader;
    
    
    [SerializeField] private int _objectPrice;
    [SerializeField] private TextMeshPro _priceText;
    
    public MoneyStorage _mStorage;
    public MaterialStorage _matStorage;
    public static bool _isFabric = false;
    
    private void Start()
    {
        if(GettingObject != null) GettingObject.SetActive(false);    
        if(DeletingObject != null) DeletingObject.SetActive(true);
    }

    private void Update()
    {
        _priceText.text = _objectPrice.ToString() + "$";
    }

    public void UpgradeLevel()
    {
        if ((_mStorage.Money == _objectPrice && _matStorage.Material > 0) || _mStorage.Money > _objectPrice)
        {
            _mStorage.SpendMoney(_objectPrice);
            if (GettingObject != null) GettingObject.SetActive(true);
            if (DeletingObject != null) DeletingObject.SetActive(false);
            if (_nextUpgrader != null) _nextUpgrader.SetActive(true);
            this.gameObject.SetActive(false);
            _isFabric = true;
        }
    }
}
