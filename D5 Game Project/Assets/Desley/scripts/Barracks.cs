using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barracks : MonoBehaviour
{
    public GameObject cam;
    public GameObject soldier;
    public GameObject newSoldier;

    public int soldierCount;

    public GameObject road;
    public Transform[] spawnPoints;

    public bool found;
    public bool roadFound;

    void Start()
    {
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
        
        if(road != null && soldierCount >= 1)
        {
            SpawnSoldier();
        }
    }

    void SpawnSoldier()
    {
        if(soldierCount >= 4)
        {
            return;
        }

            newSoldier = Instantiate(soldier, spawnPoints[soldierCount].transform);
            newSoldier.transform.position = spawnPoints[soldierCount].transform.position;
            soldierCount++;
        
    }
}
