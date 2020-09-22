using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Transform cam;

    public Canvas canvas;
    public Slider slider;

    public float health;
    public float currentHealth;

    public bool updated;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        health = gameObject.GetComponentInParent<Enemy>().health;
        updated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!updated)
        {
            slider.maxValue = health;
            slider.value = slider.maxValue;
            currentHealth = health;
            updated = true;
        }

        health = gameObject.GetComponentInParent<Enemy>().health;

        if(currentHealth > health)
        {
            slider.value = health;
            currentHealth = health;
        }
        transform.LookAt(transform.position + cam.forward);
        canvas.transform.LookAt(transform.position + cam.forward);
    }
}
