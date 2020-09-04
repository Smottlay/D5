using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public GameObject endPanel;
    public Text healthCounter;

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
        healthCounter.color = Color.red;
        healthCounter.text = ("Health: ") + health;

        if(health <= 0)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {

    }
}
