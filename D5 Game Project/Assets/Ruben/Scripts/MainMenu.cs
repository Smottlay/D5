using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public CanvasGroup settings;
    //public GameObject settingsRim;

    public GameObject settings;
    public GameObject devMenu;
    static bool devModeOn;

    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene/Main Scene Dawg");
    }

    public void Settings()
    {
        settings.SetActive(true);
    }

    public void BackToMainMenu()
    {
        settings.SetActive(false);
    }

    public void DevMode()
    {
        devModeOn = true;
        SceneManager.LoadScene("Main Scene/Main Scene Dawg");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (devModeOn == true)
        {
            devMenu.SetActive(true);
        }
        if (devModeOn == false)
        {
            devMenu.SetActive(false);
        }
    }

    public void disableDevMode()
    {
        devModeOn = false;
    }
}
