﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<int> maxInstantiate;
    public int instantiated;
    public int destroyedCounter;

    public int waveCounter;
    public int extraHealth;
    public bool giveExtraHealth;
    public float waveCountdown;
    public int regulationRounds;

    public float spawnCountdown;
    public float spawnRate;
    public bool canSpawn;

    public int spawnRandomizer;

    public GameObject normal;
    public GameObject speed;
    public GameObject tank;

    public bool newEndlessWave;
    public bool endlessMode;
    public int extraSpawns;
    public GameObject cam;
    public GameObject continuePanel;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1f;
        waveCountdown = 10;
        waveCounter = 1;
        continuePanel.SetActive(false);
        endlessMode = false;
        newEndlessWave = false;
        giveExtraHealth = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCounter > regulationRounds && !endlessMode)
        {
            cam.GetComponent<PlayerHealth>().continuePanelActive = true;
            continuePanel.SetActive(true);
            Time.timeScale = 0;
            return;
        }

        if (endlessMode && newEndlessWave)
        {
            maxInstantiate.Add(maxInstantiate.Count * 2 + extraSpawns);
            newEndlessWave = false;
        }

        if (waveCountdown <= 0)
        {
            GameObject.FindGameObjectWithTag("timer").GetComponent<WaveDisplay>().newRound = true;
            canSpawn = true;
            waveCountdown = 300;
        }

        if (canSpawn && spawnCountdown <= 0 && instantiated <= maxInstantiate[waveCounter -1])
        {
            StartRandomizing();
        }

        waveCountdown -= Time.deltaTime;
        spawnCountdown -= Time.deltaTime; 

        if(destroyedCounter == maxInstantiate[waveCounter - 1])
        {
            destroyedCounter = 0;
            waveCounter++;
            WaveCountdown();
        }

        if(waveCounter == 1)
        {
            tank.GetComponent<Enemy>().maxHealth = 400;
            normal.GetComponent<Enemy>().maxHealth = 200;
            speed.GetComponent<Enemy>().maxHealth = 100;
        }

        if(!giveExtraHealth)
        {
            giveExtraHealth = true;
            if (waveCounter < 4)
            {
                normal.GetComponent<Enemy>().maxHealth += extraHealth;
            }
            else if (waveCounter < 7)
            {
                normal.GetComponent<Enemy>().maxHealth += extraHealth;
                speed.GetComponent<Enemy>().maxHealth += extraHealth;
            }
            else if (waveCounter < 10)
            {
                normal.GetComponent<Enemy>().maxHealth += extraHealth;
                speed.GetComponent<Enemy>().maxHealth += extraHealth;
                tank.GetComponent<Enemy>().maxHealth += extraHealth;
            }
            else if(waveCounter >= 10)
            {
                normal.GetComponent<Enemy>().maxHealth += extraHealth;
                speed.GetComponent<Enemy>().maxHealth += extraHealth;
                tank.GetComponent<Enemy>().maxHealth += extraHealth;
            }
        }
    }

    void WaveCountdown()
    {
        waveCountdown = 10;
        newEndlessWave = true;
    }

    void SpawnCountdown()
    {
        if (!canSpawn && instantiated < maxInstantiate[waveCounter - 1])
        {
            spawnCountdown = 1f / spawnRate;
            canSpawn = true;
        }
        else if (instantiated == maxInstantiate[waveCounter - 1])
        {
            instantiated = 0;
            giveExtraHealth = false;
        }
    }
    void StartRandomizing()
    {
        if (waveCounter <= 3 && instantiated < maxInstantiate[waveCounter -1])
        {
            spawnRandomizer = Random.Range(1, 2);
            StartInstantiating();
        }
        else if (waveCounter <= 6 && instantiated < maxInstantiate[waveCounter -1])
        {
            spawnRandomizer = Random.Range(1, 3);
            StartInstantiating();
        }
        else if (waveCounter > 6 && instantiated < maxInstantiate[waveCounter -1]) 
        {
            spawnRandomizer = Random.Range(1, 4);
            StartInstantiating();
        }
    }

    void StartInstantiating()
    {
        if(spawnRandomizer == 1 && canSpawn)
        {
            Instantiate(normal, gameObject.transform);
            instantiated++;
            canSpawn = false;
            SpawnCountdown();
        }
        else if (spawnRandomizer == 2 && canSpawn)
        {
            Instantiate(speed, gameObject.transform);
            instantiated++;
            canSpawn = false;
            SpawnCountdown();
        }
        else if (spawnRandomizer == 3 && canSpawn)
        {
            Instantiate(tank, gameObject.transform);
            instantiated++;
            canSpawn = false;
            SpawnCountdown();
        }
    }
}
