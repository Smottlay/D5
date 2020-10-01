using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barracks : MonoBehaviour
{
    public GameObject cam;
    public GameObject soldier;
    public int maxSoldiers;
    public int soldierCount;

    public float countdown;

    public bool upgrade;
    public bool click;

    public GameObject road;
    public Transform[] spawnPoints;
    public bool firstSpawn;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        road = null;
        firstSpawn = false;
        click = true;
        upgrade = false;
        maxSoldiers = 3;
        countdown = 2f;
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
            Instantiate(soldier, spawnPoints[soldierCount].transform);
            soldierCount++;
            firstSpawn = true;
        }
    }

    public void Spawn()
    {
        if (soldierCount < maxSoldiers +1)
        {
            Instantiate(soldier, spawnPoints[soldierCount].transform);
            soldierCount++;
        }
    }
}
