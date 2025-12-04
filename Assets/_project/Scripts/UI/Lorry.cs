using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Lorry : MonoBehaviour
{
    private int rang;
    
    private MaterialStorage material;
    private MoneyStorage money;

    private GameObject Player;
    private GameObject _cam;
    
    public void LorrySpawned(int range, MaterialStorage mat, GameObject _player, GameObject _camera)
    {
        rang = range;
        material = mat;

        Player = _player;
        _cam = _camera;
        
        StartCoroutine(Anim());
    }
    private void Update()
    {
        if(transform.position.z > 32) StopCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        while (true)
        {
            transform.DOMoveZ(180f, 25f);
            yield return new WaitForSeconds(4);
            
            material.AddMaterial(rang);
            Destroy(gameObject);
        }
    }
}
