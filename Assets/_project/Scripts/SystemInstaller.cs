using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemInstaller : MonoBehaviour
{
    [SerializeField] private GameObject _clewPrefab;
    [SerializeField] private int _matClew;
    [SerializeField] private GameObject _boxPrefab;
    [SerializeField] private int _matBox;
    [SerializeField] private GameObject _mousePrefab;
    [SerializeField] private int _matMouse;
    [SerializeField] private GameObject _kitPrefab;
    [SerializeField] private int _matKitten;
    
    public MaterialStorage _mStorage;
    public MoneyStorage _MoneyStorage;

    private Dictionary<Type, FactoryLogic> _productFactories;


    private void Awake()
    {
        _mStorage.AddMaterial(10);
        _productFactories = new Dictionary<Type, FactoryLogic>()
        {
           /* {typeof(ClewFactory), new ClewFactory(_clewPrefab, _matClew)},
            {typeof(BoxFactory), new BoxFactory(_boxPrefab, _matBox)},
            {typeof(MouseFactory), new MouseFactory(_mousePrefab, _matMouse)},
            {typeof(KittenFactory), new KittenFactory(_kitPrefab, _matKitten)},*/
        };
    }
    public void BuyMaterial(int mat, int money)
    {
        if (_MoneyStorage.Money >= money)
        {
            _mStorage.AddMaterial(mat);
            _MoneyStorage.SpendMoney(money);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Upgrader")
        {
            Upgrader hitUpgrader = collision.transform.GetComponent<Upgrader>();
            hitUpgrader.UpgradeLevel();
        }
        if (collision.transform.tag == "Getter")
        {
            _MoneyStorage.AddMoney();
        }
        if (collision.transform.tag == "Buyer")
        {
            Buyer hitBuyer = collision.transform.GetComponent<Buyer>();
            hitBuyer.GetMat();
        }
    }
}
