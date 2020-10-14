using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static float speed;
    public float mouseDetection;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    public bool transitionEnd;

    public Slider slider;
    public static float sens;
    public static bool firstSens;

    private void Start()
    {
        speed = 10;
        if(SceneManager.GetActiveScene().buildIndex == 0 && !firstSens)
        {
            sens = slider.value;
            firstSens = true;
        }
        PlayerMovement.speed = sens;
        slider.value = sens;
    }

    void Update()
    {
        if (slider.value != 19.5f)
        {
            sens = slider.value;
        }

        if (transitionEnd && SceneManager.GetActiveScene().buildIndex != 0)
        {
            Vector3 moveDir = transform.position;

            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - mouseDetection)
            {
                moveDir.z += speed * Time.deltaTime;
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= mouseDetection)
            {
                moveDir.z -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - mouseDetection)
            {
                moveDir.x += speed * Time.deltaTime;
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= mouseDetection)
            {
                moveDir.x -= speed * Time.deltaTime;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            moveDir.y -= scroll * speed * 50f * Time.deltaTime;

            moveDir.x = Mathf.Clamp(moveDir.x, minX, maxX);
            moveDir.y = Mathf.Clamp(moveDir.y, minY, maxY);
            moveDir.z = Mathf.Clamp(moveDir.z, minZ, maxZ);

            transform.position = moveDir;
        }
    }

    public void setSensitivity(float newSpeed)
    {
        PlayerMovement.speed = newSpeed;
    }
}
