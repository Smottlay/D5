using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void Retry()
    {
        SceneManager.LoadScene("scenename");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("scenename");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
