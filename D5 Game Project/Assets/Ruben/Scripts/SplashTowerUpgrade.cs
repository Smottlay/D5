using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SplashTowerUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool rawDamageUpgrade;

    public float rawDamageRefund;
    public float rangeCost;
    public float damageCost;

    private float foundationRange = 3;

    public GameObject turret;
    public GameObject upgradeMenu;
    public GameObject shop;
    public GameObject rangeCircle;
    public GameObject foundation;
    public GameObject foundation2;

    public GameObject rangeButton;
    public GameObject damageButton;

    public TMP_Text rangeGold;
    public TMP_Text damageGold;

    public void Start()
    {
        FindFoundation();
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

        if (turret.GetComponent<SplashTurret>().viewRangeUpgradePossible == false)
        {
            rangeButton.SetActive(false);
        }
        else
        {
            rangeButton.SetActive(true);
        }

        if (turret.GetComponent<SplashTurret>().damageUpgradePossible == false)
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

    public void FindFoundation()
    {
        GameObject[] foundations = GameObject.FindGameObjectsWithTag("foundation");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestFoundation = null;

        foreach (GameObject foundation in foundations)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, foundation.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestFoundation = foundation;
            }
        }
        if (nearestFoundation != null && shortestDistance <= foundationRange)
        {
            foundation = nearestFoundation;
        }
        else
        {
            foundation = null;
        }
    }

    public void OnMouseDown()
    {
        upgradeMenu.SetActive(true);
    }

    public void UpgradeRange()
    {
        turret.GetComponent<SplashTurret>().UpgradeRange();
        shop.GetComponent<Shop>().RangeUpgrade();
        gameObject.GetComponentInChildren<SplashTurret>().rangeUpgrades += 1;
        upgradeMenu.SetActive(false);
    }
    public void UpgradeDamage()
    {
        turret.GetComponent<SplashTurret>().UpgradeDamage();
        shop.GetComponent<Shop>().DamageUpgrade();
        gameObject.GetComponentInChildren<SplashTurret>().damageUpgrades += 1;
        upgradeMenu.SetActive(false);
    }


    public void RefundTower()
    {
        shop.GetComponent<Shop>().gold += rawDamageRefund;
        foundation.GetComponent<Renderer>().enabled = true;
        foundation.GetComponent<Collider>().enabled = true;
        Destroy(gameObject);
    }
    public void OnMouseEnter()
    {
        if(Time.timeScale != 0)
        {
            rangeCircle.SetActive(true);
        }
    }
    public void OnMouseExit()
    {
        rangeCircle.SetActive(false);
    }
}
