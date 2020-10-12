using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed;
    public float mouseDetection;

    public Vector2 horLimit;

    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    public bool transitionEnd;

    private void Start()
    {
        speed = 10;
    }

    void Update()
    {
        if (transitionEnd)
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

            moveDir.x = Mathf.Clamp(moveDir.x, -horLimit.x, horLimit.x);
            moveDir.z = Mathf.Clamp(moveDir.z, -horLimit.y, horLimit.y);

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
