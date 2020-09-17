using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text mineralsDisplay;
    //public GameObject mineralsCounter;

    public GameObject refund;

    public float gold;
    public float addToGold;

    public float rawDamageTowerCost;
    public float splashTowerCost;
    public float barracksCost;
    public float mineLayerCost;
    public float drillCost;

    private bool rawDamageTower;
    private bool splashTower;
    private bool barracks;
    private bool mineLayer;
    private bool drill;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void Update()
    {
        mineralsDisplay.text = gold.ToString();
    }

    public void PurchaserRawDamageTower()
    {
        if (gold < rawDamageTowerCost)
            return;
        if (gold >= rawDamageTowerCost)
        {
            gold -= rawDamageTowerCost;
            buildManager.SetTurret(buildManager.rawDamageTower);
        }
        refund.SetActive(true);
        gameObject.SetActive(false);
        rawDamageTower = true;

        GameObject[] minerals = GameObject.FindGameObjectsWithTag("minerals");
        foreach (GameObject mineral in minerals)
        {
            mineral.GetComponent<Resource>().DisableMineral();
        }
    }
    public void PurchaseSplashTower()
    {
        if (gold < splashTowerCost)
            return;
        if (gold >= splashTowerCost)
        {
            gold -= splashTowerCost;
            buildManager.SetTurret(buildManager.splashTower);
        }
        refund.SetActive(true);
        gameObject.SetActive(false);
        splashTower = true;

        GameObject[] minerals = GameObject.FindGameObjectsWithTag("minerals");
        foreach (GameObject mineral in minerals)
        {
            mineral.GetComponent<Resource>().DisableMineral();
        }
    }
    public void PurchaseSlowTower()
    {
        if (gold < mineLayerCost)
            return;
        if (gold >= mineLayerCost)
        {
            gold -= mineLayerCost;
            buildManager.SetTurret(buildManager.slowTower);
        }
        refund.SetActive(true);
        gameObject.SetActive(false);
        mineLayer = true;

        GameObject[] minerals = GameObject.FindGameObjectsWithTag("minerals");
        foreach (GameObject mineral in minerals)
        {
            mineral.GetComponent<Resource>().DisableMineral();
        }
    }
    public void PurchaseBunker()
    {
        if (gold < barracksCost)
            return;
        if (gold >= barracksCost)
        {
            gold -= barracksCost;
            buildManager.SetTurret(buildManager.bunker);
        }
        refund.SetActive(true);
        gameObject.SetActive(false);
        barracks = true;

        GameObject[] minerals = GameObject.FindGameObjectsWithTag("minerals");
        foreach (GameObject mineral in minerals)
        {
            mineral.GetComponent<Resource>().DisableMineral();
        }
    }
    public void PurchaseMiningTower()
    {
        if (gold < drillCost)
            return;
        if (gold >= drillCost)
        {
            gold -= drillCost;
            buildManager.SetTurret(buildManager.miningTower);
        }
        refund.SetActive(true);
        gameObject.SetActive(false);
        drill = true;

        GameObject[] foundations = GameObject.FindGameObjectsWithTag("foundation");
        foreach (GameObject foundation in foundations)
        {
            foundation.GetComponent<Foundation>().DisableFoundation();
        }
    }

    public void addGold()
    {
        gold += addToGold;
    }

    public void refundTower()
    {
        if(rawDamageTower == true)
        {
            gold += rawDamageTowerCost;
            rawDamageTower = false;
        }
        if(mineLayer == true)
        {
            gold += mineLayerCost;
            mineLayer = false;
        }
        if(barracks == true)
        {
            gold += barracksCost;
            barracks = false;
        }
        if(splashTower == true)
        {
            gold += splashTowerCost;
            splashTower = false;
        }
        if (drill == true)
        {
            gold += drillCost;
            drill = false;
        }

        refund.SetActive(false);
        gameObject.SetActive(true);
        buildManager.NoTurretToBuild();

        GameObject[] minerals = GameObject.FindGameObjectsWithTag("minerals");
        foreach (GameObject mineral in minerals)
        {
            mineral.GetComponent<Resource>().EnableMineral();
        }

        GameObject[] foundations = GameObject.FindGameObjectsWithTag("foundation");
        foreach (GameObject foundation in foundations)
        {
            foundation.GetComponent<Foundation>().EnableFoundation();
        }
    }
}
