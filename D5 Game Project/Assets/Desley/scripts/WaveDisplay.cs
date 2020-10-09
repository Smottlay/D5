using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveDisplay : MonoBehaviour
{
    public bool newRound;

    public GameObject timerText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
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
            timeText.text = ("Preparation ") + roundTimeDisplay.ToString("0.0");
            timeText.color = Color.white;
        }
        if(roundTimeDisplay <= .1)
        {
            timerText.SetActive(false);
        }
        if (newRound)
        {
            roundText.text = ("Wave ") + roundDisplay;
            roundText.color = Color.white;
            newRound = false;
        }
    }
}
