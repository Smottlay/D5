using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMode : MonoBehaviour
{
    public GameObject spawner;
    public GameObject shop;
    public GameObject health;
    public GameObject mainMenu;
    public GameObject transition;

    public bool devmodeEnable;
    public void Start()
    {
        devmodeEnable = true;
        //devmodeEnable = false;
        transition = null;
    }
    public void Update()
    {
        if(transition == null)
        {
            transition = GameObject.FindGameObjectWithTag("levelloader");
            transition.GetComponent<Transition>().devMode = true;
        }
        if(spawner == null)
        {
            spawner = GameObject.FindGameObjectWithTag("spawner");
        }
        if (devmodeEnable == true && spawner != null)
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
        spawner.GetComponent<Spawn>().DevModeSpeed();
    }
    public void SpawnNormal()
    {
        spawner.GetComponent<Spawn>().DevModeNormal();
    }
    public void SpawnTank()
    {
        spawner.GetComponent<Spawn>().DevModeTank();
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
