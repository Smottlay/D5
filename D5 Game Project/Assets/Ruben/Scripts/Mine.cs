﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject tower;

    public GameObject firstEnemy;

    public AudioSource explosion;

    public float splashRadius;
    public int damageAmount;

    public float kinematicCountdown;
    public float kinematicOffCountdown;

    public int spawnPointID;

    public Vector3 targetPos;
    private Vector3 startPos;
    private Vector3 nextPos;
    public GameObject mineLayer;

    public GameObject particle;

    public float speed;

    public string roadTag = "road";
    public string mineSpawnPointTag = "mineSpawnPoint";

    public Rigidbody rb;

    public bool hasExploded;
    public float destroyTimer;

    public void Start()
    {
        kinematicCountdown = 1.5f;
        kinematicOffCountdown = 1f;
        destroyTimer = Mathf.Infinity;
    }


    public void Update()
    {
       gameObject.transform.position =  Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        kinematicCountdown -= Time.deltaTime;
        if(kinematicCountdown<= 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            kinematicCountdown = 0;
            kinematicOffCountdown -= Time.deltaTime;
        }
        if(kinematicOffCountdown <= 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            kinematicOffCountdown = 0;
        }

        destroyTimer -= Time.deltaTime;

        if(destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        firstEnemy = other.gameObject;

        if(other.gameObject.tag == "enemy")
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);

        if(firstEnemy.GetComponent<Enemy>().mineDetecion == true)
        {
            foreach (Collider nearbyEnemy in colliders)
            {
                if (nearbyEnemy.gameObject.tag == "enemy")
                {

                    if (nearbyEnemy.GetComponent<Enemy>().mineDetecion == true && !hasExploded)
                    {
                        explosion.Play();
                        hasExploded = true;
                        mineLayer.GetComponent<MineLayer>().activeSpawnPoints[spawnPointID] = true;
                        nearbyEnemy.GetComponent<Enemy>().MineDamage(damageAmount);
                        nearbyEnemy.GetComponent<Enemy>().tower = tower;
                        Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
                        destroyTimer = .5f;

                        tower.GetComponent<MineLayer>().mineList.Remove(gameObject);
                    }
                }
            }
        }
    }


}
