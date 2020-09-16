using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float mouseDetection;

    public Vector2 horLimit;

    public float minY;
    public float maxY;

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

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        moveDir.y -= scroll * speed * 50f * Time.deltaTime;

        moveDir.x = Mathf.Clamp(moveDir.x, - horLimit.x, horLimit.x);
        moveDir.z = Mathf.Clamp(moveDir.z, - horLimit.y, horLimit.y);

        moveDir.y = Mathf.Clamp(moveDir.y, minY, maxY);

        transform.position = moveDir;
    }
}
