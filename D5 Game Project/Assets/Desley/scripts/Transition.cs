using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator transition;
    public GameObject cam;
    public GameObject spawner;
    public GameObject timePanel;
    public GameObject ui;

    public void Start()
    {
        transition.SetBool("End", false);
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spawner = GameObject.FindGameObjectWithTag("spawner");
        timePanel = GameObject.FindGameObjectWithTag("timePanel");
        ui = GameObject.Find("UI");
        ui.GetComponent<Canvas>().enabled = false;
        spawner.SetActive(false);
        timePanel.SetActive(false);
    }

    public void EndTransition()
    {
        transition.SetBool("End", true);
        spawner.SetActive(true);
        timePanel.SetActive(true);
        ui.GetComponent<Canvas>().enabled = true;
        cam.GetComponent<PlayerMovement>().transitionEnd = true;
        GameObject.FindGameObjectWithTag("timer").GetComponent<WaveDisplay>().transitionEnd = true;
    }
}
