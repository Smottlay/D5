using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLook : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }
}
