using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DrillUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool drillUpgrade;

    public float drillRefund;
    public float damageCost;

    public float foundationRange = 3;

    public GameObject upgradeMenu;
    public GameObject shop;
    public GameObject foundation;

    public GameObject incomeButton;
    public TMP_Text incomeGold;

    public void Start()
    {
        FindFoundation();
        drillUpgrade = false;
        shop = GameObject.FindGameObjectWithTag("gameMaster");
        damageCost = shop.GetComponent<Shop>().damageCost;
    }

    public void Update()
    {

        incomeGold.text = damageCost.ToString();

        shop = GameObject.FindGameObjectWithTag("gameMaster");

        if (gameObject.GetComponent<Drill>().incomeUpgradePossible == false)
        {
            incomeButton.SetActive(false);
        }
        else
        {
            incomeButton.SetActive(true);
        }

        if (Time.timeScale == 0)
        {
            upgradeMenu.SetActive(false);
        }

    }

    public void FindFoundation()
    {
        GameObject[] foundations = GameObject.FindGameObjectsWithTag("minerals");
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
        if (nearestFoundation != null)
        {
            foundation = nearestFoundation;
        }
        else
        {
            foundation = null;
        }
    }

    public void IncomeUpgrade()
    {
        gameObject.GetComponent<Drill>().UpgradeIncome();
        shop.GetComponent<Shop>().DamageUpgrade();
        gameObject.GetComponentInChildren<Drill>().incomeUpgrades += 1;
        upgradeMenu.SetActive(false);
    }

    public void OnMouseDown()
    {
        upgradeMenu.SetActive(true);
    }

    public void RefundTower()
    {
        shop.GetComponent<Shop>().gold += drillRefund;
        foundation.GetComponent<Resource>().mineralUsed = false;
        Destroy(gameObject);
    }
}
