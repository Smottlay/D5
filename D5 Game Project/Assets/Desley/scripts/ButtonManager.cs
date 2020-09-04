using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void RestartButton(bool button)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().Restart();
    }

    public void MenuButton(bool button)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().MainMenu();
    }
}
