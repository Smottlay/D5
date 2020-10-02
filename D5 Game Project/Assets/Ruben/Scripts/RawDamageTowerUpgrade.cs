using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawDamageTowerUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool rawDamageUpgrade;

    public GameObject upgradeMenu;
    public GameObject shop;
    public void Start()
    {
        rawDamageUpgrade = false;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void Update()
    {
        upgradeMenu = GameObject.FindGameObjectWithTag("upgradeMenu");
        shop = GameObject.FindGameObjectWithTag("shop");
    }


    public void OnMouseDown()
    {
        shop.SetActive(false);
        upgradeMenu.GetComponent<UpgradeMenu>().upgradeRawDamage();
    }

    public void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    public void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
