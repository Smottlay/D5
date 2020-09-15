using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletSpawner;
    public GameObject bullet;
    public GameObject turretRing;

    public Transform enemy;
    public float viewRange;
    private string enemyTag = "enemy";

    public float bulletSpeed;
    private float bulletReload = 0f;
    public float bulletrate;

    void Start()
    {
        InvokeRepeating("targetToShoot", 0f, 0.5f);
    }

    public void targetToShoot()
    {
        if (enemy != null && Vector3.Distance(transform.position, enemy.position) <= viewRange)
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
            enemy = nearestEnemy.transform;
        }
        else
        {
            enemy = null;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(enemy.position, transform.position);
        if (distance <= viewRange)
        {
            Vector3 dir = enemy.position - transform.position;
            transform.LookAt(new Vector3(enemy.position.x, enemy.position.y, enemy.position.z));
        }

        if (enemy == null)
            return;
    }

    public void Reload()
    {
        if (bulletReload <= 0f)
        {
            Shoot();
            bulletReload = 1f / bulletrate;
        }
        bulletReload -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject tempBullet;
        tempBullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;

        tempBullet.transform.Rotate(Vector3.right * -90);

        Rigidbody tempRid;
        tempRid = tempBullet.GetComponent<Rigidbody>();

        tempRid.AddForce(transform.forward * bulletSpeed);

        Destroy(tempBullet, 3f);
    }
}
