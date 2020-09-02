using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaserRawDamageTower()
    {
        buildManager.SetTurret(buildManager.rawDamageTower);
    }
    public void PurchaseSplashTower()
    {
        buildManager.SetTurret(buildManager.splashTower);
    }
    public void PurchaseSlowTower()
    {
        buildManager.SetTurret(buildManager.slowTower);
    }
    public void PurchaseBunker()
    {
        buildManager.SetTurret(buildManager.bunker);
    }
    public void PurchaseMiningTower()
    {
        buildManager.SetTurret(buildManager.miningTower);
    }
}
