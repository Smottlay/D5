using System.Collections;
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

    public float rangeCost;
    public float damageCost;

    public GameObject turret;
    public GameObject upgradeMenu;
    public GameObject shop;

    public TMP_Text rangeGold;
    public TMP_Text damageGold;

    public void Start()
    {
        rawDamageUpgrade = false;
        //rend = GetComponent<Renderer>();
        //startColor = rend.material.color;
        rangeCost = shop.GetComponent<Shop>().rangeCost;
        damageCost = shop.GetComponent<Shop>().damageCost;
    }

    public void Update()
    {
        rangeGold.text = rangeCost.ToString();
        damageGold.text = rangeCost.ToString();

        shop = GameObject.FindGameObjectWithTag("gameMaster");
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

    }

    public void OnMouseEnter()
    {

    }
    public void OnMouseExit()
    {
        
    }
}
