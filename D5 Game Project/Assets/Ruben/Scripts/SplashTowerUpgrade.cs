using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTowerUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool rawDamageUpgrade;

    public GameObject upgradeMenu;
    public GameObject shop;
    public GameObject rangeCircle;

    public float rangeCost;
    public void Start()
    {
        rawDamageUpgrade = false;
        //rend = GetComponent<Renderer>();
        //startColor = rend.material.color;
    }

    public void Update()
    {
        shop = GameObject.FindGameObjectWithTag("shop");
    }


    public void OnMouseDown()
    {
        //upgradeMenu.SetActive(true);
    }

    public void UpgradeRange()
    {
        if(shop.GetComponent<Shop>().gold >= rangeCost)
        {
            gameObject.GetComponent<Turret>().UpgradeRange();
            shop.GetComponent<Shop>().gold -= rangeCost;
            upgradeMenu.SetActive(false);
        }
    }
    public void UpgradeDamage()
    {

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
