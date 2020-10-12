using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject gameMaster;

    public void RestartButton(bool button)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().Restart();
    }

    public void MenuButton(bool button)
    {
        gameMaster.GetComponent<MainMenu>().DisableDevMode();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().MainMenu();
    }

    public void EndlessButton(bool button)
    {
        GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().endlessMode = true;
        GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().newEndlessWave = true;
        GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().continuePanel.SetActive(false);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().continuePanelActive = false;
        Time.timeScale = 1;
    }

    public void NextLevelButton(bool button)
    {
        SceneManager.LoadScene("Level 2");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
