using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _materialText;
    [SerializeField] private float _animDuration;

    private int _viewedCount;
    private int _actualCount;
    private Coroutine _anim;

    [SerializeField] private MaterialStorage _mStrorage;

    private void OnEnable()
    {
        _mStrorage.OnMaterialEarned += MaterialEarned;
        _mStrorage.OnMaterialSpent += MaterialSpent;

        ChangeText(_mStrorage.Material);
    }

    private void OnDestroy()
    {
        _mStrorage.OnMaterialEarned -= MaterialEarned;
        _mStrorage.OnMaterialSpent -= MaterialSpent;
    }

    private void MaterialEarned(int newValue)
    {
        if (_anim != null)
            StopCoroutine(_anim);
        
        _actualCount = newValue;
        _anim = StartCoroutine(routine: ChangingMaterial());
    }

    private void MaterialSpent(int newValue)
    {
        if (_anim != null)
            StopCoroutine(_anim);

        _actualCount = newValue;
        _anim = StartCoroutine(routine: ChangingMaterial());
    }
    private IEnumerator ChangingMaterial()
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
        _materialText.text = $"{count}";
    }
}