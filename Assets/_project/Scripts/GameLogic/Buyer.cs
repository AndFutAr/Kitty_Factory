using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buyer : MonoBehaviour
{
    public MaterialStorage _MaterialStorage;
    public MoneyStorage _MoneyStorage;

    [SerializeField] private int mat;
    [SerializeField] private int money;
    [SerializeField] private TextMeshPro _price;

    [SerializeField] private GameObject lorryPrefab;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Camera;

    private void Update()
    {
        _price.text = mat.ToString() + " материала - " + money + "$";
    }

    public void GetMat()
    {
        if (_MoneyStorage.Money >= money && Upgrader._isFabric == true)
        {
            _MoneyStorage.SpendMoney(money);
            
            GameObject lorry;
            Lorry lor;
            Vector3 lorrySpawn = new Vector3(6f, 3.85f, -30f);
            lorry = Instantiate(lorryPrefab, lorrySpawn, lorryPrefab.transform.rotation);
            lor = lorry.GetComponent<Lorry>();
            lor.LorrySpawned(mat, _MaterialStorage, Player, Camera);
        }
    }
}
