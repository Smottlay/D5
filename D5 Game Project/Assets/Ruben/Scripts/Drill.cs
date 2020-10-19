using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public float goldTimer;
    public float goldTimerReduceUpgrade;

    public float incomeUpgrades;
    public float maxIncomeUpgrades;

    private float goldCountdown;
    public float goldAmount;

    public bool incomeUpgradePossible;

    public GameObject shop;
    public ParticleSystem drill;

    public int goldProduced;

    public void Start()
    {
        incomeUpgradePossible = true;
        shop = GameObject.FindGameObjectWithTag("gameMaster");
    }

    public void UpgradeIncome()
    {
        if (incomeUpgradePossible == true)
        {
            goldTimer -= goldTimerReduceUpgrade;
        }
    }

    void Update()
    {
        if (shop.GetComponent<Shop>().canUpgradeDamage == false)
        {
            incomeUpgradePossible = false;
        }
        else
        {
            incomeUpgradePossible = true;
        }
        if (incomeUpgrades >= maxIncomeUpgrades)
        {
            incomeUpgradePossible = false;
        }


        goldCountdown -= Time.deltaTime;
        if(goldCountdown <= 0)
        {
            drill.Play();

            shop.GetComponent<Shop>().addGoldDrill();
            goldProduced += 1;
            goldCountdown = goldTimer;
        }
    }
}
