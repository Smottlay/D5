using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup pause;
    public CanvasGroup settings;
    public GameObject pauseRim;
    public GameObject settingsRim;
    public float lastTimescale;

    public GameObject shop;

    public bool pausedActive;
    public bool settingsActive;
    private void Start()
    {
        shop = GameObject.FindGameObjectWithTag("shop");

        HideSettings();
        HidePaused();
    }
    public void Update()
    {
        PauseThing();
    }
    public void PauseThing()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(!pausedActive && !settingsActive && Time.timeScale >= 1)
            {
                lastTimescale = Time.timeScale;
                Time.timeScale = 0;
                ShowPaused();
            }
            else if(pausedActive && !settingsActive)
            {
                Time.timeScale = lastTimescale;
                HidePaused();
            }
            else if (settingsActive)
            {
                HideSettings();
            }
        }
    }
    public void HidePaused()
    {
        pause.alpha = 0f;
        pause.blocksRaycasts = false;
        pausedActive = false;
        shop.SetActive(true);
        //pauseRim.SetActive(false);
    }
    public void ShowPaused()
    {
        pause.alpha = 1f;
        pause.blocksRaycasts = true;
        pausedActive = true;
        shop.SetActive(false);
        //pauseRim.SetActive(true);
    }
    public void HideSettings()
    {
        settings.alpha = 0f;
        settings.blocksRaycasts = false;
        settingsActive = false;
        shop.SetActive(true);
        //settingsRim.SetActive(false);
    }
    public void ShowSettings()
    {
        settings.alpha = 1f;
        settings.blocksRaycasts = true;
        settingsActive = true;
        shop.SetActive(false);
        //settingsRim.SetActive(true);
    }
   
    public void Quit()
    {
        SceneManager.LoadScene("Ruben/Main Menu");
    }
    public void Setttings()
    {
       //HidePaused();
        ShowSettings();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        HidePaused();
        HideSettings();
    }
    
    public void settingsBack()
    {
        HideSettings();
        ShowPaused();
    }
}
