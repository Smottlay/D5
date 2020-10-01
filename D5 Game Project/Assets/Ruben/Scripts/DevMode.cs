using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMode : MonoBehaviour
{
    public GameObject spawner;
    public GameObject shop;
    public GameObject health;

    public void SpawnSpeed()
    {
        //spawner.GetComponent<Spawn>().SpawnSpeed();
    }
    public void SpawnNormal()
    {
        //spawner.GetComponent<Spawn>().SpawnNormal();
    }
    public void SpawnTank()
    {
        //spawner.GetComponent<Spawn>().SpawnTank();
    }
    public void unlimitedResources()
    {
        shop.GetComponent<Shop>().unlimitedResources();
    }
    public void unlimitedHealth()
    {
        health.GetComponent<PlayerHealth>().unlimitedHealth();
    }
}
