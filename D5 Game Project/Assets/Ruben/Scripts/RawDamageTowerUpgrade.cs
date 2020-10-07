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

    public GameObject upgradeMenu;
    public GameObject shop;

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
        print("blyat");
        upgradeMenu.SetActive(true);
    }

    public void UpgradeRange()
    {
        gameObject.GetComponent<Turret>().upgradeRange();
        shop.GetComponent<Shop>().gold -= rangeCost;
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
