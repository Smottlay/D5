using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float mouseDetection;

    void Update()
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
        transform.position = moveDir;
    }
}
