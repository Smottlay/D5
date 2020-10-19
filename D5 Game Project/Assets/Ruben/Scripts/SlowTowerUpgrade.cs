﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SlowTowerUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool slowTowerUpgrade;

    public float slowTowerRefund;
    public float damageCost;

    public GameObject upgradeMenu;
    public GameObject shop;
    public GameObject foundation;
    public GameObject foundation2;

    public GameObject damageButton;
    public TMP_Text damageGold;

    public void Start()
    {
        slowTowerUpgrade = false;
        shop = GameObject.FindGameObjectWithTag("gameMaster");
        damageCost = shop.GetComponent<Shop>().damageCost;
    }

    public void Update()
    {
        damageGold.text = damageCost.ToString();

        shop = GameObject.FindGameObjectWithTag("gameMaster");

        if (gameObject.GetComponent<MineLayer>().damageUpgradePossible == false)
        {
            damageButton.SetActive(false);
        }
        else
        {
            damageButton.SetActive(true);
        }

        if (Time.timeScale == 0)
        {
            upgradeMenu.SetActive(false);
        }

    }

    public void MineDamageUpgrade()
    {
        gameObject.GetComponent<MineLayer>().UpgradeDamage();
        shop.GetComponent<Shop>().DamageUpgrade();
        gameObject.GetComponentInChildren<MineLayer>().damageUpgrades += 1;
        upgradeMenu.SetActive(false);
    }

    public void OnMouseDown()
    {
        upgradeMenu.SetActive(true);
    }

    public void RefundTower()
    {
        shop.GetComponent<Shop>().gold += slowTowerRefund;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Instantiate(foundation, gameObject.transform.position, gameObject.transform.rotation);
        }
        else
        {
            Instantiate(foundation2, gameObject.transform.position, gameObject.transform.rotation);
        }
        GameObject.FindGameObjectWithTag("canvas").GetComponent<Warning>().statsPanel.SetActive(true);
        Destroy(gameObject);
    }
}
