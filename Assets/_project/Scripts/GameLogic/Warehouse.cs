using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    public MoneyStorage _mStorage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ClewEnemy")
        {
            _mStorage.AddFormal(10);
        }
        if (collision.collider.tag == "BoxEnemy")
        {
            _mStorage.AddFormal(100);
        }
        if (collision.collider.tag == "MouseEnemy")
        {
            _mStorage.AddFormal(1000);
        }
        if (collision.collider.tag == "KittenEnemy")
        {
            _mStorage.AddFormal(10000);
        }
    }
}
