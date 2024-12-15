using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryLogic : MonoBehaviour
{
    private GameObject _prefab;
    private int _matPrice;
    private Transform _parent;
    private Vector3 position;

    private MaterialStorage _mStorage;

    public FactoryLogic(GameObject prefab, int material, MaterialStorage materialStorage, Transform parent, Vector3 _position) 
    {
        _prefab = prefab;
        _matPrice = material;
        _mStorage = materialStorage;
        _parent = parent;
        position = _position;
    }
    public void Spawn()
    {
        if (_mStorage.Material >= _matPrice)
        {
            _mStorage.SpendMaterial(_matPrice);
            
            var product = GameObject.Instantiate(_prefab, position, _prefab.transform.rotation);
            product.transform.SetParent(_parent);
        }
    }
}