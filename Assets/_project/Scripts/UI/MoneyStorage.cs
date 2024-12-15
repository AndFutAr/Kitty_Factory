using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyStorage : MonoBehaviour
{
    [SerializeField] private int _moneyCnt;
    private int _formalMoney = 0; 

    public int Money => _moneyCnt;
    public int Formal => _formalMoney;
    
    public Action<int> OnMoneyEarned;
    public Action<int> OnMoneySpent;

    public MoneyStorage(int moneyCnt)
    {
        _moneyCnt = moneyCnt;
    }

    public void SetupMoney(int moneyCnt)
    {
        _moneyCnt = moneyCnt;
    }

    public void AddFormal(int range)
    {
        _formalMoney += range;
    }
    public void AddMoney()
    {
        _moneyCnt += _formalMoney;
        _formalMoney = 0;
        OnMoneyEarned?.Invoke(_moneyCnt);
    }

    public void SpendMoney(int range)
    {
        _moneyCnt -= range;
        OnMoneySpent?.Invoke(_moneyCnt);
    }
}
