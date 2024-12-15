using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MaterialStorage : MonoBehaviour
{
    private int _materialCnt;

    public int Material => _materialCnt;

    public Action<int> OnMaterialEarned;
    public Action<int> OnMaterialSpent;
    
    public MaterialStorage(int materialCnt)
    {
        _materialCnt = materialCnt;
    }

    public void SetupMaterial(int materialCnt)
    {
        _materialCnt = materialCnt;
    }
    
    public void AddMaterial(int range)
    { 
        _materialCnt += range;
        OnMaterialEarned?.Invoke(_materialCnt);
    }

    public void SpendMaterial(int range)
    {
        _materialCnt -= range;
        OnMaterialSpent?.Invoke(_materialCnt);
    }
}
