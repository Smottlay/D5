using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    //public TextMeshPro mineralsDisplay;
    public TMP_Text mineralsDisplay;
    //public GameObject mineralsCounter;

    public GameObject refund;

    public float gold;
    public float enemyAddGold;
    public float addToGold;
    public float addToGoldDrill;

    public float rawDamageTowerCost;
    public float splashTowerCost;
    public float barracksCost;
    public float mineLayerCost;
    public float drillCost;

    public float rangeCost;
    public float damageCost;

    public bool canUpgradeRange;
    public bool canUpgradeDamage;

    public bool rawDamageTower;
    public bool splashTower;
    private bool barracks;
    public bool mineLayer;
    private bool drill;

    public bool resetTowers;

    public GameObject shop;
    public GameObject spawner;

    public GameObject rawDamageInfo;
    public GameObject splashTowerInfo;
    public GameObject slowTowerInfo;
    public GameObject barracksInfo;
    public GameObject drillInfo;

    public TMP_Text damageGold;
    public TMP_Text splashGold;
    public TMP_Text slowGold;
    public TMP_Text barracksGold;
    public TMP_Text drillGold;

    public bool gameStarted;

    BuildManager buildManager;

    public void Start()
    {
        shop = GameObject.FindGameObjectWithTag("shop");
        buildManager = BuildManager.instance;
        gameObject.GetComponent<TextMeshPro>();
        spawner = null;
    }
    public void Update()
    {
        mineralsDisplay.text = gold.ToString();
        damageGold.text = rawDamageTowerCost.ToString();
        splashGold.text = splashTowerCost.ToString();
        slowGold.text = mineLayerCost.ToString();
        barracksGold.text = barracksCost.ToString();
        drillGold.text = drillCost.ToString();

        if (gameStarted)
        {
            spawner = GameObject.FindGameObjectWithTag("spawner");
        }

        if (resetTowers == true)
        {
            rawDamageTower = false;
            splashTower = false;
            mineLayer = false;
            barracks = false;
            drill = false;
        }

        if(rangeCost > gold)
        {
            canUpgradeRange = false;
        }
        else
        {
            canUpgradeRange = true;
        }

        if(damageCost > gold)
        {
            canUpgradeDamage = false;
        }
        else
        {
            canUpgradeDamage = true;
        }
    }

    public void SettingsScreen()
    {
        //settings.setActive(true);
    }

    public void PurchaserRawDamageTower()
    {
        if (gold < rawDamageTowerCost)
            return;
        if (gold >= rawDamageTowerCost)
        {
            rawDamageTower = true;
            //resetTowers = true;
            Enable();
            gold -= rawDamageTowerCost;
            buildManager.SetTurret(buildManager.rawDamageTower);
        }
        InfoDisable();
        refund.SetActive(true);
        shop.SetActive(false);

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
            splashTower = true;
            //resetTowers = true;
            Enable();
            gold -= splashTowerCost;
            buildManager.SetTurret(buildManager.splashTower);
        }
        InfoDisable();
        refund.SetActive(true);
        shop.SetActive(false);

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
            mineLayer = true;
            //resetTowers = true;
            Enable();
            gold -= mineLayerCost;
            buildManager.SetTurret(buildManager.slowTower);
        }
        InfoDisable();
        refund.SetActive(true);
        shop.SetActive(false);

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
            barracks = true;
            //resetTowers = true;
            Enable();
            gold -= barracksCost;
            buildManager.SetTurret(buildManager.bunker);
        }
        InfoDisable();
        refund.SetActive(true);
        shop.SetActive(false);

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
            drill = true;
            //resetTowers = true;
            Enable();
            gold -= drillCost;
            buildManager.SetTurret(buildManager.miningTower);
        }
        InfoDisable();
        refund.SetActive(true);
        shop.SetActive(false);

        GameObject[] foundations = GameObject.FindGameObjectsWithTag("foundation");
        foreach (GameObject foundation in foundations)
        {
            foundation.GetComponent<Foundation>().DisableFoundation();
        }
    }

    public void addGold()
    {
        int waveCount = spawner.GetComponent<Spawn>().waveCounter;
        if(waveCount <= 10)
        {
            gold += enemyAddGold;
        }
    }
    public void addGoldDrill()
    {
        gold += addToGoldDrill;
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
        shop.SetActive(true);
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
    private void Enable()
    {
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

    public void RawDamageInfo()
    {
        rawDamageInfo.SetActive(true);
    }
    public void SplashTowerInfo()
    {
        splashTowerInfo.SetActive(true);
    }
    public void SlowTowerInfo()
    {
        slowTowerInfo.SetActive(true);
    }
    public void BarracksInfo()
    {
        barracksInfo.SetActive(true);
    }
    public void DrillInfo()
    {
        drillInfo.SetActive(true);
    }

    public void InfoDisable()
    {
        rawDamageInfo.SetActive(false);
        splashTowerInfo.SetActive(false);
        slowTowerInfo.SetActive(false);
        barracksInfo.SetActive(false);
        drillInfo.SetActive(false);
    }

    public void NoRefund()
    {
        rawDamageTower = false;
        splashTower = false;
        mineLayer = false;
        barracks = false;
        drill = false;
    }

    public void UnlimitedResources()
    {
        gold = Mathf.Infinity;
    }

    public void RangeUpgrade()
    {
        if(gold >= rangeCost)
        {
            gold -= rangeCost;
        }
    }
    public void DamageUpgrade()
    {
        if(gold >= damageCost)
        {
            gold -= damageCost;
        }
    }
}
