using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject helpPanel;


    public void Update()
    {
        if(Time.timeScale == 0)
        {
            helpPanel.SetActive(false);
        }
    }
    public void HelpActive()
    {
        helpPanel.SetActive(true);
    }

    public void HelpDisabled()
    {
        helpPanel.SetActive(false);
    }
}
