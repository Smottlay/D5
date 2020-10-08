using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barracks : MonoBehaviour
{
    public GameObject cam;
    public GameObject soldier;
    public GameObject newSoldier;
    public int maxSoldiers;
    public int soldierCount;

    public GameObject road;
    public Transform[] spawnPoints;
    public bool firstSpawn;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spawnPoints = null;
        road = null;
    }

    void Update()
    {
        if(gameObject.GetComponent<Lookat>().nearestRoad != null && !firstSpawn)
        {
            road = gameObject.GetComponent<Lookat>().nearestRoad;
        }

        if(road != null && !firstSpawn)
        {
            spawnPoints = road.GetComponentsInChildren<Transform>();
            newSoldier = Instantiate(soldier, spawnPoints[soldierCount].transform);
            newSoldier.transform.position = spawnPoints[soldierCount].transform.position;
            firstSpawn = true;
            soldierCount++;
        }
    }

    public void Spawn()
    {
        if (soldierCount < maxSoldiers + 1)
        {
            newSoldier = Instantiate(soldier, spawnPoints[soldierCount].transform);
            newSoldier.transform.position = spawnPoints[soldierCount].transform.position;
            soldierCount++;
        }
    }
}
