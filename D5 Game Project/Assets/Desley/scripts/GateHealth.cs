using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateHealth : MonoBehaviour
{
    GameObject cam;

    public Canvas canvas;
    public Slider slider;

    public float health;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        health = cam.GetComponent<PlayerHealth>().health;
        slider.maxValue = 50;
        slider.value = slider.maxValue;
        currentHealth = 50;
    }

    // Update is called once per frame
    void Update()
    {
        health = cam.GetComponent<PlayerHealth>().health;

        if (currentHealth > health)
        {
            slider.value = health;
            currentHealth = health;
        }
        transform.LookAt(transform.position + cam.transform.forward);
        canvas.transform.LookAt(transform.position + cam.transform.forward);
    }
}
