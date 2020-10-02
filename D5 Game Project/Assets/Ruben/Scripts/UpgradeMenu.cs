using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject shop;

    public GameObject rawDamageTowerMenu;
    public GameObject splashTowerMenu;
    public GameObject slowTowerMenu;
    public GameObject barracksMenu;
    public GameObject drillMenu;

    private bool rawDamageTowerUpgrade;
    private bool splashTowerUpgrade;
    private bool slowTowerUpgrade;
    private bool barracksUpgrade;
    private bool drillUpgrade;


    public void Start()
    {

    }

    public void upgradeRawDamage()
    {
        rawDamageTowerUpgrade = true;
    }
    public void upgradeSplash()
    {
        splashTowerUpgrade = true;
    }
    public void upgradeSlow()
    {
        slowTowerUpgrade = true;
    }
    public void upgradeBarracks()
    {
        barracksUpgrade = true;
    }
    public void upgradeDrill()
    {
        drillUpgrade = true;
    }

    public void Update()
    {
        shop = GameObject.FindGameObjectWithTag("shop");

        if (rawDamageTowerUpgrade == true)
        {
            rawDamageTowerMenu.SetActive(true);
        }
        if (splashTowerUpgrade == true)
        {
            splashTowerMenu.SetActive(true);
        }
        if (slowTowerUpgrade == true)
        {
            slowTowerMenu.SetActive(true);
        }
        if(barracksUpgrade == true)
        {
            barracksMenu.SetActive(true);
        }
        if (drillUpgrade == true)
        {
            drillMenu.SetActive(true);
        }
    }

    public void UpgradeRange()
    {
        
    }
    public void UpgradeDamage()
    {

    }
    public void UpgradeReloadSpeed()
    {

    }
    public void UpgradeIncome()
    {

    }

    public void Cancel()
    {
        rawDamageTowerUpgrade = false;
        splashTowerUpgrade = false;
        slowTowerUpgrade = false;
        barracksUpgrade = false;
        drillUpgrade = false;

        rawDamageTowerMenu.SetActive(false);
        splashTowerMenu.SetActive(false);
        slowTowerMenu.SetActive(false);
        barracksMenu.SetActive(false);
        drillMenu.SetActive(false);

        shop.SetActive(true);
    }
}
