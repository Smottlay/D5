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

    public int roundDisplay;
    public float roundTimeDisplay;
    public bool transitionEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transitionEnd)
        {
            roundDisplay = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().waveCounter;
            roundTimeDisplay = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().waveCountdown;
        }
        else
        {
            return;
        }

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
