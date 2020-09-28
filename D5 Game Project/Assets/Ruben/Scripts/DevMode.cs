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

    }
    public void SpawnNormal()
    {

    }
    public void SpawnTank()
    {

    }
    public void unlimitedResources()
    {
        shop.GetComponent<Shop>().unlimitedResources();
    }
    public void unlimitedHealth()
    {

    }
}
