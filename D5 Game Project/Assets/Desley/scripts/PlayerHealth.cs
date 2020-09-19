using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject endPanel;
    public ParticleSystem[] particleSystemies;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        health = 50;
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
            ActivateAllParticles();
        }
    }

void ActivateAllParticles()
{
    particleSystemies[0].Play();
    particleSystemies[1].Play();
}

public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {

    }
}
