using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProductLogic : MonoBehaviour
{
    [SerializeField] private GameObject _warehouse;
    [SerializeField] private int speed;

    void Start()
    {
        speed = -3;
        _warehouse = GameObject.FindGameObjectWithTag("Warehouse");
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Warehouse")
        {
            Destroy(gameObject);
        }      
    }
}
