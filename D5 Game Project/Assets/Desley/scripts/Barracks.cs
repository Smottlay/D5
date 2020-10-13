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

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spawnPoints = null;
        road = null;
    }

    void Update()
    {
        if(gameObject.GetComponent<Lookat>().nearestRoad != null)
        {
            road = gameObject.GetComponent<Lookat>().nearestRoad;
        }

        if(road != null)
        {
            spawnPoints = road.GetComponentsInChildren<Transform>();
            newSoldier = Instantiate(soldier, spawnPoints[soldierCount].transform);
            newSoldier.transform.position = spawnPoints[soldierCount].transform.position;
            soldierCount++;
        }
        if(soldierCount == 3)
        {
            soldierCount = 0;
            road = null;
        }
    }
}
