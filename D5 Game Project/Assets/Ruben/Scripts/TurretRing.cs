using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRing : MonoBehaviour
{
    public Transform enemyTarget;
    public float viewRange;
    public string enemyTag = "enemy";

    public GameObject turret;

    void Start()
    {
        InvokeRepeating("targetToShoot", 0f, 0.5f);
    }

    public void targetToShoot()
    {
        if (enemyTarget != null && Vector3.Distance(transform.position, enemyTarget.position) <= viewRange)
        {
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= viewRange)
        {
            enemyTarget = nearestEnemy.transform;
        }
        else
        {
            enemyTarget = null;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(enemyTarget.position, transform.position);
        if (distance <= viewRange)
        {
            Vector3 dir = enemyTarget.position - transform.position;
            transform.LookAt(new Vector3(enemyTarget.position.x, transform.position.y, enemyTarget.position.z));

            ShootTarget();
        }

        if (enemyTarget == null)
            return;

    }

    public void ShootTarget()
    {
        turret.GetComponent<Turret>().reload();
    }
}
