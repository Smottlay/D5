using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLayer : MonoBehaviour
{
    public float cooldown;
    private float cooldownTimer;

    public float mineForce;
    public GameObject mineSpawner;

    public float mines;
    public float maxMines;

    public bool firstSpawn;
    public Vector3 targetPos;
    public float mineAmount;

    public Transform[] mineSpawnPoints;
    public Transform roadTransform;
    public GameObject road;
    public GameObject mine;
    
    void Start()
    {
        road = GameObject.FindGameObjectWithTag("road");
        roadTransform = road.GetComponent<Transform>();
    }

    void Update()
    {
        if (gameObject.GetComponent<Lookat>().nearestRoad != null && !firstSpawn)
        {
            road = gameObject.GetComponent<Lookat>().nearestRoad;
        }

        if (road != null && !firstSpawn)
        {
            mineSpawnPoints = road.GetComponentsInChildren<Transform>();
            firstSpawn = true;
            foreach (Transform mineSpawnPoint in mineSpawnPoints)
            {
                if (mineSpawnPoint.tag == "mineSpawnPoint")
                {
                    targetPos = mineSpawnPoint.transform.position;
                    mineAmount += 1;
                }
            }
        }

        if (mines < maxMines)
        {
            if (cooldownTimer < 0)
            {
                cooldownTimer = cooldown;
                mines++;
                Mine();
            }
        }
        cooldownTimer -= Time.deltaTime;
    }

    public void Mine()
    {
        GameObject tempMine;
        tempMine = Instantiate(mine, mineSpawner.transform.position, mineSpawner.transform.rotation) as GameObject;

        Rigidbody tempRid;
        tempRid = tempMine.GetComponent<Rigidbody>();

        tempRid.AddForce(transform.up * mineForce);
    }
    public void extractMine()
    {
        mines -= 1f;
    }
}
