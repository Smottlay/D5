using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public CanvasGroup settings;
    //public GameObject settingsRim;

    public GameObject spawner;
    public GameObject settings;
    public GameObject devMenu;
    public static bool devModeOn;

    public void Start()
    {
        //devModeOn = false;
        //DisableDevMode();
        spawner = null;
        devMenu.SetActive(false);
    }

    public void StartGame()
    {
        devModeOn = false;
        SceneManager.LoadScene(1);
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
        devMenu.GetComponent<DevMode>().DevModeOn();
        SceneManager.LoadScene(1);

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

    public void CheckUpdate()
    {

    }

    public void DisableDevMode()
    {
        devModeOn = false;
    }
}
