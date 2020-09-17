using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    public Vector3 roadPos;
    public Transform road;
    public GameObject nearestRoad;

    private void Start()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("road");
        float shortestDistance = Mathf.Infinity;
        nearestRoad = null;

        foreach (GameObject road in roads)
        {
            float distanceToRoad = Vector3.Distance(transform.position, road.transform.position);
            if (distanceToRoad < shortestDistance)
            {
                shortestDistance = distanceToRoad;
                nearestRoad = road;
                gameObject.GetComponent<Barracks>().nearestRoad = nearestRoad;
                roadPos = road.transform.position;
            }
        }
        if (nearestRoad != null && shortestDistance <= 100)
        {
            road = nearestRoad.transform;
        }

        float distance = Vector3.Distance(road.position, transform.position);
        if (distance <= 100)
        {
            transform.LookAt(new Vector3(road.position.x, transform.position.y, road.position.z));
        }
    }
}
