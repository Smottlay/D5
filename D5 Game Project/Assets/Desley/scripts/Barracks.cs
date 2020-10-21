using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barracks : MonoBehaviour
{
    public GameObject cam;
    public GameObject soldier;
    public GameObject newSoldier;

    public List<GameObject> soldiers;
    public int soldierCount;

    public GameObject shop;
    public GameObject road;
    public Transform[] spawnPoints;

    public bool buySoldierPossible;
    public float maxSoldiers;

    public bool found;
    public bool roadFound;

    public int kills;
    public int creepsStopped;

    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("gameMaster");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spawnPoints = null;
        road = null;
    }

    void Update()
    {
        if(gameObject.GetComponent<Lookat>().nearestRoad != null && !found)
        {
            road = gameObject.GetComponent<Lookat>().nearestRoad;
            found = true;
        }

        if(road != null && !roadFound)
        {
            spawnPoints = road.GetComponentsInChildren<Transform>();
            roadFound = true;
        }
        
        if(road != null && soldierCount == 1)
        {
            SpawnSoldier();
        }

        if (shop.GetComponent<Shop>().canUpgradeDamage == false)
        {
            buySoldierPossible = false;
        }
        else
        {
            buySoldierPossible = true;
        }
        if (soldierCount >= maxSoldiers)
        {
            buySoldierPossible = false;
        }
    }

    public void BuySoldier()
    {
        SpawnSoldier();
    }


    void SpawnSoldier()
    {
        if(soldierCount >= 4)
        {
            return;
        }

            newSoldier = Instantiate(soldier, spawnPoints[soldierCount].transform);
            newSoldier.transform.position = spawnPoints[soldierCount].transform.position;
            soldiers.Add(newSoldier);
            newSoldier.GetComponent<Soldier>().tower = gameObject;
            soldierCount++;
    }
}
