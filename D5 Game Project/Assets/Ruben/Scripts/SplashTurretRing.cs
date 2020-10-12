using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTurretRing : MonoBehaviour
{
    public Transform enemyTarget;
    public float viewRange;
    public string enemyTag = "enemy";

    public GameObject turret;
    public GameObject enemy;

    void Start()
    {
        enemy = null;
        viewRange = turret.GetComponent<SplashTurret>().viewRange;
    }

    void Update()
    {
        if (turret.GetComponent<SplashTurret>().enemy != null)
        {
            enemy = gameObject.GetComponentInChildren<SplashTurret>().enemy.gameObject;
        }
        else if (turret.GetComponent<SplashTurret>().enemy == null)
        {
            enemy = null;
        }

        if (enemy != null)
        {
            if (viewRange > Vector3.Distance(transform.position, enemy.transform.position))
            {
                transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));
            }
            else
            {
                enemy = gameObject.GetComponentInChildren<SplashTurret>().enemy.gameObject;
            }

        }
    }
}
