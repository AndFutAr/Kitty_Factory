using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    [SerializeField] private TextMeshPro _formalText;
    [SerializeField] private float _animDuration;

    private int _viewedCount;
    private int _actualCount;
    private Coroutine _anim;

    [SerializeField] private MoneyStorage _mStrorage;

    private void OnEnable()
    {
        _mStrorage.OnMoneyEarned += MoneyEarned;
        _mStrorage.OnMoneySpent += MoneySpent;

        ChangeText(_mStrorage.Money);
    }

    private void Update()
    {
        SetMoney(_mStrorage.Formal);
    }

    private void OnDestroy()
    {
        _mStrorage.OnMoneyEarned -= MoneyEarned;
        _mStrorage.OnMoneySpent -= MoneySpent;
    }

    private void MoneyEarned(int newValue)
    {
        if (_anim != null)
            StopCoroutine(_anim);
        
        _actualCount = newValue;
        _anim = StartCoroutine(routine: ChangingMoney());
    }

    private void MoneySpent(int newValue)
    {
        if (_anim != null)
            StopCoroutine(_anim);
        
        _actualCount = newValue;
        _anim = StartCoroutine(routine: ChangingMoney());
    }
    private IEnumerator ChangingMoney()
    {
        float targetTime = _animDuration;
        var timer = 0f;
        int prevCount = _viewedCount;
        while (_viewedCount != _actualCount && timer < targetTime)
        {
            yield return null;
            timer += Time.deltaTime;
            ChangeText(count: (int)Mathf.Lerp(a: prevCount, b: _actualCount, t: Mathf.Clamp(value: timer / targetTime, min: 0f, max: 1f)));
        }

        _anim = null;
    }

    private void ChangeText(int count)
    {
        _viewedCount = count;
        _moneyText.text = $"{count}$";
    }

    private void SetMoney(int count)
    {
        _formalText.text = $"{count}$";
    }
}