using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMode : MonoBehaviour
{
    public GameObject spawner;
    public GameObject shop;
    public GameObject health;
    public GameObject mainMenu;

    public bool devmodeEnable;
    public void Start()
    {
        devmodeEnable = true;
        //devmodeEnable = false;
        spawner = GameObject.FindGameObjectWithTag("spawner");

    }
    public void Update()
    {
        if (devmodeEnable == true&& spawner != null)
        {
            spawner.GetComponent<Spawn>().devMode = true;
        }
        else
        {
            return;
        }
    }

    public void SpawnSpeed()
    {
        spawner.GetComponent<Spawn>().SpawnSpeed();
    }
    public void SpawnNormal()
    {
        spawner.GetComponent<Spawn>().SpawnNormal();
    }
    public void SpawnTank()
    {
        spawner.GetComponent<Spawn>().SpawnTank();
    }
    public void unlimitedResources()
    {
        shop.GetComponent<Shop>().UnlimitedResources();
    }
    public void unlimitedHealth()
    {
        health.GetComponent<PlayerHealth>().unlimitedHealth();
    }
    public void DevModeOn()
    {

    }
}
