using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
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
        health = gameObject.GetComponentInParent<Enemy>().maxHealth;
        slider.maxValue = health;
        slider.value = slider.maxValue;
        currentHealth = health;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        health = gameObject.GetComponentInParent<Enemy>().health;

        if (currentHealth > health)
        {
            slider.value = health;
            currentHealth = health;
        }
        transform.LookAt(transform.position + cam.transform.forward);
        canvas.transform.LookAt(transform.position + cam.transform.forward);
    }
}
