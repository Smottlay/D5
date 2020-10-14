using System.Collections;
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
    public bool devMode;

    public GameObject timePanel;

    public int spawnRandomizer;

    public GameObject normal;
    public GameObject speed;
    public GameObject tank;

    public bool newEndlessWave;
    public bool endlessMode;
    public int extraSpawns;
    public int multiplier;
    public GameObject cam;
    public GameObject continuePanel;

    public int normalMaxHp;
    public int speedMaxHp;
    public int tankMaxHp;

    public float buildSignTimer;

    // Start is called before the first frame update
    void Start()
    {
        continuePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCounter > regulationRounds && !endlessMode && !devMode)
        {
            cam.GetComponent<PlayerHealth>().continuePanelActive = true;
            continuePanel.SetActive(true);
            Time.timeScale = .25f;
            return;
        }

        if (devMode)
        {
            timePanel.SetActive(false);
        }

        if (endlessMode && newEndlessWave && !devMode)
        {
            maxInstantiate.Add(maxInstantiate.Count * multiplier + extraSpawns);
            newEndlessWave = false;
        }

        if (waveCountdown <= 0 && !devMode)
        {
            GameObject.FindGameObjectWithTag("timer").GetComponent<WaveDisplay>().newRound = true;
            canSpawn = true;
            waveCountdown = Mathf.Infinity;
        }

        if (canSpawn && spawnCountdown <= 0 && instantiated <= maxInstantiate[waveCounter -1] && !devMode)
        {
            StartRandomizing();
        }

        waveCountdown -= Time.deltaTime;
        spawnCountdown -= Time.deltaTime; 

        if(destroyedCounter == maxInstantiate[waveCounter - 1] && !devMode)
        {
            destroyedCounter = 0;
            waveCounter++;
            WaveCountdown();
        }

        if(waveCounter == 1)
        {
            tank.GetComponent<Enemy>().maxHealth = tankMaxHp;
            normal.GetComponent<Enemy>().maxHealth = normalMaxHp;
            speed.GetComponent<Enemy>().maxHealth = speedMaxHp;
        }

        buildSignTimer -= Time.deltaTime;
        if(buildSignTimer <= 0)
        {
            GameObject[] buildSigns = GameObject.FindGameObjectsWithTag("BuildSign");
            foreach(GameObject sign in buildSigns)
            {
                Destroy(sign);
            }
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
            SpawnNormal();
        }
        else if (waveCounter <= 6 && instantiated < maxInstantiate[waveCounter -1])
        {
            spawnRandomizer = Random.Range(1, 3);
            if(spawnRandomizer == 1)
            {
                SpawnNormal();
            }
            else if(spawnRandomizer == 2)
            {
                SpawnSpeed();
            }
        }
        else if (waveCounter > 6 && instantiated < maxInstantiate[waveCounter -1]) 
        {
            spawnRandomizer = Random.Range(1, 4);
            if (spawnRandomizer == 1)
            {
                SpawnNormal();
            }
            else if (spawnRandomizer == 2)
            {
                SpawnSpeed();
            }
            else if(spawnRandomizer == 3)
            {
                SpawnTank();
            }
        }
    }


    public void SpawnSpeed()
    {
        Instantiate(speed, gameObject.transform);
        instantiated++;
        canSpawn = false;
        SpawnCountdown();
    }
    public void SpawnNormal()
    {
        Instantiate(normal, gameObject.transform);
        instantiated++;
        canSpawn = false;
        SpawnCountdown();
    }
    public void SpawnTank()
    {
        Instantiate(tank, gameObject.transform);
        instantiated++;
        canSpawn = false;
        SpawnCountdown();
    }

    public void DevModeSpeed()
    {
        Instantiate(speed, gameObject.transform);
    }
    public void DevModeNormal()
    {
        Instantiate(normal, gameObject.transform);
    }
    public void DevModeTank()
    {
        Instantiate(tank, gameObject.transform);
    }
}
