using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int wPoint = 0; wPoint < points.Length; wPoint++)
        {
            points[wPoint] = transform.GetChild(wPoint);
        }
    }
}
