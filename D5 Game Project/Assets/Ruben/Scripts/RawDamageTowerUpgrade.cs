using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RawDamageTowerUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool rawDamageUpgrade;

    public GameObject turret;
    public GameObject upgradeMenu;
    public GameObject shop;

    public void Start()
    {
        rawDamageUpgrade = false;
        //rend = GetComponent<Renderer>();
        //startColor = rend.material.color;
    }

    public void Update()
    {
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
