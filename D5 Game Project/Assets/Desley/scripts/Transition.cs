using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator transition;
    public GameObject cam;
    public GameObject spawner;
    public GameObject timePanel;

    public void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spawner = GameObject.FindGameObjectWithTag("spawner");
        timePanel = GameObject.FindGameObjectWithTag("timePanel");
        cam.GetComponent<PlayerMovement>().setSensitivity(0);
        spawner.SetActive(false);
        timePanel.SetActive(false);
    }

    public void EndTransition()
    {
        transition.SetTrigger("End");
        cam.GetComponent<PlayerMovement>().setSensitivity(1);
        spawner.SetActive(true);
        timePanel.SetActive(true);
    }
}
