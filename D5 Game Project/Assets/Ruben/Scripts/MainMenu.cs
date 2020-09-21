using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    public void StartGame()
    {
        SceneManager.LoadScene("SceneName");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SceneName");
    }

    public void DevMode()
    {
        SceneManager.LoadScene("SceneName");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("SceneName");
    }
}
