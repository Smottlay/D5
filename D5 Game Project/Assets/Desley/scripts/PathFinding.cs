using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public int speed;
    public float rotationSpeed;

    private Transform target;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }

        Vector3 lookDir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookDir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            gameObject.GetComponent<Enemy>().TargetReached();
            return;
        }

        waypointIndex++;

        target = Waypoints.points[waypointIndex];
    }
}
