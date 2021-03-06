﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject canvas;
    public GameObject endPanel;
    public GameObject particleObject;
    public GameObject wholeGate;
    public GameObject brokenGate;

    public bool continuePanelActive;
    public bool endPanelActive;
    public float health;
    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        canvas.GetComponent<GraphicRaycaster>().enabled = false;
        particleObject = GameObject.FindGameObjectWithTag("DoorExplosion");
        wholeGate.SetActive(true);
        brokenGate.SetActive(false);
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && alive)
        {
            endPanelActive = true;
            particleObject.GetComponent<ParticlePlayer>().ParticleStart();
            shopPanel.SetActive(false);
            wholeGate.SetActive(false);
            brokenGate.SetActive(true);
            endPanel.SetActive(true);
            alive = false;
            gameObject.GetComponent<MusicPlayer>().OnDeath();
            Time.timeScale = 0.25f;
            return;
        }

        if (continuePanelActive && !endPanelActive)
        {
            canvas.GetComponent<GraphicRaycaster>().enabled = true;
        }
        else if (!continuePanelActive && endPanelActive)
        {
            canvas.GetComponent<GraphicRaycaster>().enabled = true;
        }
        else if (!continuePanelActive)
        {
            canvas.GetComponent<GraphicRaycaster>().enabled = false;
        }
    }

public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void unlimitedHealth()
    {
        health = Mathf.Infinity;
    }
}
