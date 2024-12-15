using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buyer : MonoBehaviour
{
    public MaterialStorage _MaterialStorage;
    public MoneyStorage _MoneyStorage;

    [SerializeField] private int range;
    [SerializeField] private TextMeshPro _price;

    private void Update()
    {
        _price.text = range.ToString() + " материала - " + range * 5 + "$";
    }

    public void GetMat()
    {
        if (_MoneyStorage.Money >= range * 5 && Upgrader._isFabric == true)
        {
            _MoneyStorage.SpendMoney(range * 5);
            _MaterialStorage.AddMaterial(range);
        }
    }
}
