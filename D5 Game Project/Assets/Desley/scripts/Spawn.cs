using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int[] maxInstantiate;
    public int instantiated;
    public int destroyedCounter;

    public int waveCounter;
    public float waveCountdown;

    public float spawnCountdown;
    public float spawnRate;
    public bool canSpawn;

    public int spawnRandomizer;

    public GameObject normal;
    public GameObject speed;
    public GameObject tank;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1.5f;
        waveCountdown = 10;
        waveCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveCountdown <= 0)
        {
            canSpawn = true;
            waveCountdown = 100;
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
    }

    void WaveCountdown()
    {
        waveCountdown = 10;
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
            Instantiate(normal);
            instantiated++;
            canSpawn = false;
            SpawnCountdown();
        }
        else if (spawnRandomizer == 2 && canSpawn)
        {
            Instantiate(speed);
            instantiated++;
            canSpawn = false;
            SpawnCountdown();
        }
        else if (spawnRandomizer == 3 && canSpawn)
        {
            Instantiate(tank);
            instantiated++;
            canSpawn = false;
            SpawnCountdown();
        }
    }
}
