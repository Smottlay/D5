using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BarracksUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool slowTowerUpgrade;

    public float barracksRefund;
    public float upgradeCost;

    private float foundationRange = 3;

    public GameObject upgradeMenu;
    public GameObject shop;
    public GameObject foundation;
    public GameObject foundation2;

    public GameObject upgradeButton;
    public TMP_Text damageGold;

    public void Start()
    {
        FindFoundation();
        slowTowerUpgrade = false;
        shop = GameObject.FindGameObjectWithTag("gameMaster");
        upgradeCost = shop.GetComponent<Shop>().damageCost;
    }

    public void Update()
    {
        damageGold.text = upgradeCost.ToString();

        shop = GameObject.FindGameObjectWithTag("gameMaster");

        if (gameObject.GetComponent<Barracks>().buySoldierPossible == false)
        {
            upgradeButton.SetActive(false);
        }
        else
        {
            upgradeButton.SetActive(true);
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

    public void BuySoldierUpgrade()
    {
        gameObject.GetComponent<Barracks>().BuySoldier();
        shop.GetComponent<Shop>().DamageUpgrade();
        upgradeMenu.SetActive(false);
    }

    public void OnMouseDown()
    {
        upgradeMenu.SetActive(true);
    }

    public void RefundTower()
    {
        shop.GetComponent<Shop>().gold += barracksRefund;
        foundation.GetComponent<Renderer>().enabled = true;
        foundation.GetComponent<Collider>().enabled = true;
        foreach(GameObject soldier in gameObject.GetComponent<Barracks>().soldiers)
        {
            Destroy(soldier);
        }
        Destroy(gameObject);
    }
}
