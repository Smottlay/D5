﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RawDamageTowerUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool rawDamageUpgrade;

    public float rawDamageRefund;
    public float rangeCost;
    public float damageCost;

    public GameObject turret;
    public GameObject upgradeMenu;
    public GameObject shop;
    public GameObject rangeCircle;
    public GameObject foundation;

    public GameObject rangeButton;
    public GameObject damageButton;

    public TMP_Text rangeGold;
    public TMP_Text damageGold;

    public void Start()
    {
        rawDamageUpgrade = false;
        shop = GameObject.FindGameObjectWithTag("gameMaster");
        rangeCost = shop.GetComponent<Shop>().rangeCost;
        damageCost = shop.GetComponent<Shop>().damageCost;
    }

    public void Update()
    {
        rangeGold.text = rangeCost.ToString();
        damageGold.text = damageCost.ToString();

        shop = GameObject.FindGameObjectWithTag("gameMaster");

        if(turret.GetComponent<Turret>().viewRangeUpgradePossible == false)
        {
            rangeButton.SetActive(false);
        }
        else
        {
            rangeButton.SetActive(true);
        }

        if(turret.GetComponent<Turret>().damageUpgradePossible == false)
        {
            damageButton.SetActive(false);
        }
        else
        {
            damageButton.SetActive(true);
        }


    }


    public void OnMouseDown()
    {
        upgradeMenu.SetActive(true);
    }

    public void UpgradeRange()
    {
        turret.GetComponent<Turret>().UpgradeRange();
        shop.GetComponent<Shop>().RangeUpgrade();
        upgradeMenu.SetActive(false);
    }
    public void UpgradeDamage()
    {
        turret.GetComponent<Turret>().UpgradeDamage();
        shop.GetComponent<Shop>().DamageUpgrade();
        upgradeMenu.SetActive(false);
    }


    public void RefundTower()
    {
        shop.GetComponent<Shop>().gold += rawDamageRefund;
        Instantiate(foundation, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
    public void OnMouseEnter()
    {
        rangeCircle.SetActive(true);
    }
    public void OnMouseExit()
    {
        rangeCircle.SetActive(false);
    }
}
