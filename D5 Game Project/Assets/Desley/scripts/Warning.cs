using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Warning : MonoBehaviour
{
    public AudioSource resourceVoiceOver;
    public AudioSource gateVoiceOver;

    public GameObject warningPanel;
    public TextMeshProUGUI warningText;
    [TextArea(5, 2)]
    public string[] warnings;

    public GameObject spawner;
    public float  currentPlayerHp;
    public GameObject player;

    public bool warningPanelActive;
    public bool resourceWarning;
    public bool blockGateWarning;

    public float resourceWarningTimer;
    public float gateWarningTimer;

    public bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        currentPlayerHp = player.GetComponent<PlayerHealth>().health;
        warningPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner == null && gameStarted)
        {
            spawner = GameObject.FindGameObjectWithTag("spawner");
        }

        if (gameStarted)
        {
            if (spawner.GetComponent<Spawn>().waveCounter == 7 && !resourceWarning)
            {
                resourceVoiceOver.Play();
                warningPanel.SetActive(true);
                warningText.text = warnings[1];
                resourceWarningTimer = 10;
                resourceWarning = true;
                blockGateWarning = true;
            }
        }

        resourceWarningTimer -= Time.deltaTime;

        if(resourceWarningTimer <= 0 && resourceWarning)
        {
            warningPanel.SetActive(false);
            resourceWarningTimer = Mathf.Infinity;
            blockGateWarning = false;
        }

        if(player.GetComponent<PlayerHealth>().health < currentPlayerHp && !warningPanelActive && !blockGateWarning)
        {
            gateVoiceOver.Play();
            warningPanel.SetActive(true);
            warningText.text = warnings[0];
            gateWarningTimer = 10;
            warningPanelActive = true;
        }

        gateWarningTimer -= Time.deltaTime;

        if(gateWarningTimer <= 0 && warningPanelActive)
        {
            warningPanel.SetActive(false);
            gateWarningTimer = Mathf.Infinity;
            warningPanelActive = false;
            currentPlayerHp = player.GetComponent<PlayerHealth>().health;
        }
    }
}
