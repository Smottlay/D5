using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barracks : MonoBehaviour
{
    public GameObject soldier;
    public int maxSoldiers;
    public int soldierCount;

    public Transform[] spawnPoints;
    public int nextSpawnPoint;

    public GameObject canvas;
    public GameObject upgradeButtonPrefab;
    public GameObject upgradeButton;
    public Text warningPrefab;
    public Text warningText;

    public float countdown;

    public bool upgrade;
    public bool click;

    void Start()
    {
        click = true;
        upgrade = false;
        maxSoldiers = spawnPoints.Length;
        Instantiate(soldier, spawnPoints[0]);
        Instantiate(soldier, spawnPoints[1]);
        soldierCount = 2;
        nextSpawnPoint = 2;
        countdown = 2f;
        canvas = GameObject.FindGameObjectWithTag("canvas");
        upgradeButton = Instantiate(upgradeButtonPrefab);
        upgradeButton.transform.SetParent(canvas.transform, false);
        upgradeButton.SetActive(false);
    }

    void Update()
    {
        if(countdown <= 0f)
        {
            countdown = 2f;
            Destroy(warningText);
            warningText = warningPrefab;
            click = true;
        }
        if(countdown <= 1.5f)
        {
            countdown -= Time.deltaTime;
        }

        if (upgradeButton.GetComponent<UpgradeManager>().buttonPressed == true)
        {
            Spawn();
            upgradeButton.GetComponent<UpgradeManager>().buttonPressed = false;
        }
    }

    public void Spawn()
    {
        if (soldierCount < maxSoldiers)
        {
            Instantiate(soldier, spawnPoints[nextSpawnPoint]);
            soldierCount++;
            nextSpawnPoint++;
            upgradeButton.SetActive(false);
        }
        else if (click)
        {
            click = false;
            warningText = Instantiate(warningText);
            warningText.transform.SetParent(canvas.transform, false);
            warningText.text = ("Max Reached!");
            warningText.color = Color.red;
            countdown = 1.5f;
            upgradeButton.SetActive(false);
        }
    }
}
