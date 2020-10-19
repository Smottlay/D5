using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLayer : MonoBehaviour
{
    public float cooldown;
    private float cooldownTimer;
    public int damage;
    public int damageUpgrade;
    public int maxDamage;

    public bool damageUpgradePossible;
    public float damageUpgrades;

    public float mineForce;
    public GameObject mineSpawner;

    public float mines;
    public float maxMines;

    public bool firstSpawn;
    public Vector3 targetPos;
    public float mineAmount;

    public Transform[] mineSpawnPoints;
    public bool[] activeSpawnPoints;
    public Transform roadTransform;
    public GameObject road;
    public GameObject mine;

    public GameObject shop;

    public ParticleSystem thunkDust;
    public AudioSource mineThunk;
    public AudioSource slowThunk;

    public int kills;
    public int creepsSlowed;

    void Start()
    {
        damageUpgradePossible = true;
        maxMines = Mathf.Infinity;
        shop = GameObject.FindGameObjectWithTag("gameMaster");
    }

    void Update()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("road");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestRoad = null;

        foreach (GameObject road in roads)
        {
            float distanceToRoad = Vector3.Distance(transform.position, road.transform.position);
            if (distanceToRoad < shortestDistance)
            {
                shortestDistance = distanceToRoad;
                nearestRoad = road;


            }
        }

        if (gameObject.GetComponent<Lookat>().nearestRoad != null && !firstSpawn)
        {
            road = gameObject.GetComponent<Lookat>().nearestRoad;
        }

        if (road != null && !firstSpawn)
        {
            mineSpawnPoints = nearestRoad.GetComponentsInChildren<Transform>();
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
            if (cooldownTimer < 0 && activeSpawnPoints[0])
            {
                cooldownTimer = cooldown;
                mines++;
                Mine0();
                activeSpawnPoints[0] = false;
            }
            else if (cooldownTimer < 0 && activeSpawnPoints[1])
            {
                cooldownTimer = cooldown;
                mines++;
                Mine1();
                activeSpawnPoints[1] = false;
            }
            else if (cooldownTimer < 0 && activeSpawnPoints[2])
            {
                cooldownTimer = cooldown;
                mines++;
                Mine2();
                activeSpawnPoints[2] = false;
            }
        }
        cooldownTimer -= Time.deltaTime;

        if (shop.GetComponent<Shop>().canUpgradeDamage == false)
        {
            damageUpgradePossible = false;
        }
        else
        {
            damageUpgradePossible = true;
        }
        if (damageUpgrade >= maxDamage)
        {
            damageUpgradePossible = false;
        }
    }


    public void Mine0()
    {
        thunkDust.Play();
        slowThunk.Play();
        GameObject tempMine;
        tempMine = Instantiate(mine, mineSpawner.transform.position, mineSpawner.transform.rotation) as GameObject;

        targetPos = mineSpawnPoints[4].transform.position;
        tempMine.GetComponent<Mine>().damageAmount = damage;
        tempMine.GetComponent<Mine>().targetPos = targetPos;
        tempMine.GetComponent<Mine>().mineLayer = gameObject;
        tempMine.GetComponent<Mine>().spawnPointID = 0;
        tempMine.GetComponent<Mine>().tower = gameObject;

        Rigidbody tempRid;
        tempRid = tempMine.GetComponent<Rigidbody>();

        tempRid.AddForce(transform.up * mineForce);
    }

    public void Mine1()
    {
        thunkDust.Play();
        slowThunk.Play();
        GameObject tempMine;
        tempMine = Instantiate(mine, mineSpawner.transform.position, mineSpawner.transform.rotation) as GameObject;

        targetPos = mineSpawnPoints[5].transform.position;
        tempMine.GetComponent<Mine>().damageAmount = damage;
        tempMine.GetComponent<Mine>().targetPos = targetPos;
        tempMine.GetComponent<Mine>().mineLayer = gameObject;
        tempMine.GetComponent<Mine>().spawnPointID = 1;
        tempMine.GetComponent<Mine>().tower = gameObject;

        Rigidbody tempRid;
        tempRid = tempMine.GetComponent<Rigidbody>();

        tempRid.AddForce(transform.up * mineForce);
    }

    public void Mine2()
    {
        thunkDust.Play();
        slowThunk.Play();
        GameObject tempMine;
        tempMine = Instantiate(mine, mineSpawner.transform.position, mineSpawner.transform.rotation) as GameObject;

        targetPos = mineSpawnPoints[6].transform.position;
        tempMine.GetComponent<Mine>().damageAmount = damage;
        tempMine.GetComponent<Mine>().targetPos = targetPos;
        tempMine.GetComponent<Mine>().mineLayer = gameObject;
        tempMine.GetComponent<Mine>().spawnPointID = 2;
        tempMine.GetComponent<Mine>().tower = gameObject;

        Rigidbody tempRid;
        tempRid = tempMine.GetComponent<Rigidbody>();

        tempRid.AddForce(transform.up * mineForce);
    }

    public void UpgradeDamage()
    {
        if (damageUpgradePossible == true)
        {
            damage += damageUpgrade;
        }
    }

    public void extractMine()
    {
        mines -= 1f;
    }
}
