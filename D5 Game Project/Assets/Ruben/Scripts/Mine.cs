using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float splashRadius;

    public Vector3 targetPos;
    public Vector3 startPos;
    public Vector3 nextPos;
    public GameObject mineLayer;

    public float speed;

    public Transform road;
    public float roadRadius;
    public string roadTag = "road";

    public Rigidbody rb;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag(roadTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestRoad = null;

        foreach (GameObject road in roads)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, road.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestRoad = road;
                targetPos = road.transform.position;
                //targetPos = new Vector3(Random.Range(road.transform.position.z - 2, road.transform.position.z + 2), 0);
            }
        }
        if (nearestRoad != null && shortestDistance <= roadRadius)
        {
            road = nearestRoad.transform;
        }
        else
        {
            road = null;
        }

        float distance = Vector3.Distance(road.position, transform.position);
        if (distance <= roadRadius)
        {
            Vector3 nextPos = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            transform.LookAt(nextPos - transform.position);
            transform.position = nextPos;
        }
        if (road == null)
            return;
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
