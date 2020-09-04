using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public GameObject endPanel;
    public Text healthCounter;

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }

    void Restart(bool button)
    {
        if (button)
        {
          
        }
    }

    void MainMenu(bool button)
    {
        if (button)
        {
            //code to go back to main menu
        }
    }
}
