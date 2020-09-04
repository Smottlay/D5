using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    public bool newRound;

    public GameObject timerText;
    public Text roundText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        newRound = true;
        timerText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int roundDisplay = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().waveCounter;
        float roundTimeDisplay = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().waveCountdown;
        if(roundTimeDisplay <= 10)
        {
            timerText.SetActive(true);
            timeText.text = ("Preperation ") + roundTimeDisplay.ToString("0.00");
        }
        if(roundTimeDisplay <= .1)
        {
            timerText.SetActive(false);
        }
        if (newRound)
        {
            roundText.text = ("Round ") + roundDisplay;
            newRound = false;
        }
    }
}
