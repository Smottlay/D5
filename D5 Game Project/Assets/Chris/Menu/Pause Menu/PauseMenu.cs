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
    private void Start()
    {
        hideSettings();
        hidePaused();
    }
    public void Update()
    {
        PauseThing();
    }
    public void PauseThing()
    {
        if(Input.GetButtonDown("Cancel"))
        {
           if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
           else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }
    public void hidePaused()
    {
        pause.alpha = 0f;
        pause.blocksRaycasts = false;
        //pauseRim.SetActive(false);
    }
    public void showPaused()
    {
        pause.alpha = 1f;
        pause.blocksRaycasts = true;
        //pauseRim.SetActive(true);
    }
    public void hideSettings()
    {
        settings.alpha = 0f;
        settings.blocksRaycasts = false;
        //settingsRim.SetActive(false);
    }
    public void showSettings()
    {
        settings.alpha = 1f;
        settings.blocksRaycasts = true;
        //settingsRim.SetActive(true);
    }
   
    public void Quit()
    {
        SceneManager.LoadScene("Ruben/Main Menu");
    }
    public void Setttings()
    {
        hidePaused();
        showSettings();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main Scene/Main Scene Dawg");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        hidePaused();
        hideSettings();
    }
    
    public void settingsBack()
    {
        hideSettings();
        showPaused();
    }
}
