using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject canvas;
    public GameObject endPanel;
    GameObject particleObject;
    public GameObject wholeGate;
    public GameObject brokenGate;
    public bool continuePanelActive;
    public bool endPanelActive;
    public int health;
    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        canvas.GetComponent<GraphicRaycaster>().enabled = false;
        particleObject = GameObject.FindGameObjectWithTag("DoorExplosion");
        wholeGate.SetActive(true);
        brokenGate.SetActive(false);
        alive = true;
        health = 50;
        endPanel.SetActive(false);
        continuePanelActive = false;
        endPanelActive = false;
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
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
