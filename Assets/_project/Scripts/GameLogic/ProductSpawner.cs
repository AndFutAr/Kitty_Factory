using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _mat;
    [SerializeField] private float productSpeed;
    [SerializeField] private Vector3 _position;

    private FactoryLogic _pFactory;
    public MaterialStorage mStorage;
    
    private void Awake()
    {
        _pFactory = new FactoryLogic(_prefab, _mat, mStorage, this.transform, _position);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        var waiter = new WaitForSeconds(1f / productSpeed);

        while (true)
        {
            yield return waiter;
            _pFactory.Spawn();
        }
    }
}
