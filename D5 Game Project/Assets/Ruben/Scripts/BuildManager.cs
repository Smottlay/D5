using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretBuild;
    public GameObject rawDamageTower;
    public GameObject splashTower;
    public GameObject slowTower;
    public GameObject bunker;
    public GameObject miningTower;

    public GameObject shop;

    public void SetTurret(GameObject turret)
    {
        turretBuild = turret;
    }
    public GameObject GetTurretToBuild()
    {
        return turretBuild;
    }
    public void NoTurretToBuild()
    {
        turretBuild = null;
    }
    private void Awake()
    {
        instance = this;
    }
}
