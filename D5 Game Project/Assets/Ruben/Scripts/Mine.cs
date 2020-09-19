using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float splashRadius;

    public Vector3 targetPos;
    private Vector3 startPos;
    private Vector3 nextPos;
    public GameObject mineLayer;

    public float speed;

    public GameObject road;

    public float roadRadius;
    public string roadTag = "road";
    public string mineSpawnPointTag = "mineSpawnPoint";

    public Rigidbody rb;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Vector3 nextPos = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "road")
        {
            print("arrived");
            speed = 0f;
        }


        if(collision.gameObject.tag == "enemy")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);

            foreach (Collider nearbyEnemy in colliders)
            {
                mineLayer.GetComponent<MineLayer>().extractMine();
                //criple;
            }

            Destroy(gameObject);
        }
    }
}
