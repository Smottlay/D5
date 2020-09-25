using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public CanvasGroup settings;
    //public GameObject settingsRim;

    public GameObject settings;

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
        //SceneManager.LoadScene("SceneName");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
