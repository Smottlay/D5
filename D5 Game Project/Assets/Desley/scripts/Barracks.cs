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

    //public GameObject canvas;
    //public GameObject upgradeButton;
    //public Text upgradeText;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        //upgradeButton.SetActive(false);
        road = null;
        firstSpawn = false;
        click = true;
        upgrade = false;
        maxSoldiers = 3;
        soldierCount = 1;
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

        if(countdown <= 0f)
        {
            countdown = 2f;
            click = true;
        }
        if(countdown <= 1.5f)
        {
            countdown -= Time.deltaTime;
        }
    }

    public void Spawn()
    {
        if (soldierCount < maxSoldiers +1)
        {
            Instantiate(soldier, spawnPoints[soldierCount].transform);
            soldierCount++;
        }
        else if (click)
        {
            click = false;
            //upgradeButton.SetActive(true);
            //upgradeText.text = ("Max Reached");
            //upgradeText.color = Color.red;
            countdown = 1.5f;

        }
    }
}
