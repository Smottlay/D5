﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public float goldTimer;
    private float goldCountdown;
    public float goldAmount;

    public GameObject shop;
    public void Start()
    {
        shop = GameObject.FindGameObjectWithTag("shop");
    }

    void Update()
    {
        goldCountdown -= Time.deltaTime;
        if(goldCountdown <= 0)
        {
            shop.gameObject.GetComponent<Shop>().addGold();
            goldCountdown = goldTimer;
        }
    }
}