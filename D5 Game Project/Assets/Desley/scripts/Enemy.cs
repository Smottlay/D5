﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int finishDamage;
    public int coinReward;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("spawner").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //code to give player currency
            GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().destroyedCounter++;
            Destroy(this.gameObject);
        }
    }

    public void TargetReached()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().health -= finishDamage;
        GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().destroyedCounter++;
        Destroy(this.gameObject);
    }
}
