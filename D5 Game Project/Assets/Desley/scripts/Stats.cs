using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public GameObject tower;
    public GameObject statsPanel;
    public GameObject[] statsTexts;
    public string clear;

    public int kills;
    public int rangeUpgrade;
    public int damageUpgrade;
    public int creepsSlowed;
    public int creepsStopped;
    public int goldProduced;

    public void Start()
    {
        tower = gameObject;
        statsPanel = GameObject.FindGameObjectWithTag("statsPanel");
        statsTexts = GameObject.FindGameObjectsWithTag("statsText");
        statsPanel.SetActive(false);
    }

    public void Update()
    {
        if (tower.tag == "rawDamage")
        {
            kills = tower.GetComponentInChildren<Turret>().kills;
            rangeUpgrade = tower.GetComponentInChildren<Turret>().rangeUpgrades;
            damageUpgrade = tower.GetComponentInChildren<Turret>().damageUpgrades;
        }
        else if (tower.tag == "splashTower")
        {
            kills = tower.GetComponentInChildren<SplashTurret>().kills;
            rangeUpgrade = tower.GetComponentInChildren<SplashTurret>().rangeUpgrades;
            damageUpgrade = tower.GetComponentInChildren<SplashTurret>().damageUpgrades;
        }
        else if (tower.tag == "slowTower")
        {
            kills = gameObject.GetComponentInChildren<MineLayer>().kills;
            creepsSlowed = gameObject.GetComponentInChildren<MineLayer>().creepsSlowed;
        }
        else if (tower.tag == "barrack")
        {
            kills = gameObject.GetComponent<Barracks>().kills;
            creepsStopped = gameObject.GetComponent<Barracks>().creepsStopped;
        }
        else if (tower.tag == "drillTower")
        {
            goldProduced = gameObject.GetComponent<Drill>().goldProduced;
        }
    }

    public void OnMouseEnter()
    {
        statsPanel.SetActive(true);
        if (tower.tag == "rawDamage")
        {
            statsTexts[0].GetComponent<TextMeshProUGUI>().text = "Kills: " + kills.ToString();
            statsTexts[1].GetComponent<TextMeshProUGUI>().text = "Range Upgrades: " + rangeUpgrade.ToString();
            statsTexts[2].GetComponent<TextMeshProUGUI>().text = "Damage Upgrades: " + damageUpgrade.ToString();
        }
        else if (tower.tag == "splashTower")
        {
            statsTexts[0].GetComponent<TextMeshProUGUI>().text = "Kills: " + kills.ToString();
            statsTexts[1].GetComponent<TextMeshProUGUI>().text = "Range Upgrades: " + rangeUpgrade.ToString();
            statsTexts[2].GetComponent<TextMeshProUGUI>().text = "Damage Upgrades: " + damageUpgrade.ToString();
        }
        else if (tower.tag == "slowTower")
        {
            statsTexts[0].GetComponent<TextMeshProUGUI>().text = "Kills: " + kills.ToString();
            statsTexts[1].GetComponent<TextMeshProUGUI>().text = "Creeps Slowed: " + creepsSlowed.ToString();
        }
        else if (tower.tag == "barrack")
        {
            statsTexts[0].GetComponent<TextMeshProUGUI>().text = "Kills: " + kills.ToString();
            statsTexts[1].GetComponent<TextMeshProUGUI>().text = "Creeps Stopped: " + creepsStopped.ToString();
        }
        else if (tower.tag == "drillTower")
        {
            statsTexts[0].GetComponent<TextMeshProUGUI>().text = "Gold Produced: " + goldProduced.ToString();
        }
    }

    public void OnMouseExit()
    {
        foreach(GameObject text in statsTexts)
        {
            text.GetComponent<TextMeshProUGUI>().text = clear;
        }
        statsPanel.SetActive(false);
    }
}
