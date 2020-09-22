using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject endPanel;
    GameObject particleObject;
    public GameObject wholeGate;
    public GameObject brokenGate;

    public bool continuePanelActive;
    public int health;
    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        particleObject = GameObject.FindGameObjectWithTag("DoorExplosion");
        wholeGate.SetActive(true);
        brokenGate.SetActive(false);
        alive = true;
        health = 50;
        endPanel.SetActive(false);
        GameObject.FindGameObjectWithTag("canvas").GetComponent<GraphicRaycaster>().enabled = false;
        continuePanelActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && alive)
        {
            GameObject.FindGameObjectWithTag("canvas").GetComponent<GraphicRaycaster>().enabled = true;
            particleObject.GetComponent<ParticlePlayer>().ParticleStart();
            wholeGate.SetActive(false);
            brokenGate.SetActive(true);
            endPanel.SetActive(true);
            alive = false;
            Time.timeScale = 0.25f;
        }

        if (continuePanelActive)
        {
            GameObject.FindGameObjectWithTag("canvas").GetComponent<GraphicRaycaster>().enabled = true;
        }
        else
        {
            GameObject.FindGameObjectWithTag("canvas").GetComponent<GraphicRaycaster>().enabled = false;
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
