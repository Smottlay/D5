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

    //public Transform[] mineSpots;
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
