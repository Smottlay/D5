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

    public float countdown;

    public bool upgrade;
    public bool click;

    public GameObject road;
    public Transform[] spawnPoints;
    public bool firstSpawn;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spawnPoints = null;
        road = null;
        firstSpawn = false;
        click = true;
        upgrade = false;
        soldierCount = 1;
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
            newSoldier = Instantiate(soldier, spawnPoints[soldierCount].transform);
            newSoldier.transform.position = spawnPoints[soldierCount].transform.position;
            firstSpawn = true;
            soldierCount++;
        }

        if (Input.GetKeyDown("e"))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (soldierCount < maxSoldiers +1)
        {
            newSoldier = Instantiate(soldier, spawnPoints[soldierCount].transform);
            newSoldier.transform.position = spawnPoints[soldierCount].transform.position;
            soldierCount++;
        }
    }
}
