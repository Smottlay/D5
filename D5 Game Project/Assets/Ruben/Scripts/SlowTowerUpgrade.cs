using System.Collections;
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

    private float foundationRange = 2f;

    public GameObject damageButton;
    public TMP_Text damageGold;

    public void Start()
    {
        FindFoundation();
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
        foundation.GetComponent<Renderer>().enabled = true;
        foundation.GetComponent<Collider>().enabled = true; 
        Destroy(gameObject);
    }
}
