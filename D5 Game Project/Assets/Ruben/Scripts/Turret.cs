using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : TowerUpgrade
{
    public GameObject bulletSpawner;
    public GameObject bullet;
    public GameObject turretRing;

    public ParticleSystem muzzleFlash;
    public AudioSource gunFire;

    public Transform enemy;
    public float viewRange;
    public float viewRangeUpdate;
    private string enemyTag = "enemy";

    public float bulletSpeed;
    private float bulletReload;
    public float bulletrate;
    public void Start()
    {
        bulletReload = bulletrate;
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
        if (enemy == null)
            return;

        if(enemy.tag == "Untagged")
        {
            enemy = null;
            targetToShoot();
            return;
        }

        float distance = Vector3.Distance(enemy.position, transform.position);
        if (distance <= viewRange)
        {
            Vector3 dir = enemy.position - transform.position;
            transform.LookAt(new Vector3(enemy.position.x, enemy.position.y, enemy.position.z));
        }
    }

    public void Reload()
    {
        if(enemy == null)
        {
            return;
        }
        else if (bulletReload <= 0f && enemy.GetComponent<Enemy>().dissolving == false)
        {
            bulletReload = 1f / bulletrate;
            Shoot();
        }
        bulletReload -= Time.deltaTime;
    }

    public void Shoot()
    {
        muzzleFlash.Play();
        gunFire.Play();

        GameObject tempBullet;
        tempBullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;

        tempBullet.transform.Rotate(Vector3.right * -90);

        Rigidbody tempRid;
        tempRid = tempBullet.GetComponent<Rigidbody>();

        tempRid.AddForce(transform.forward * bulletSpeed);

        Destroy(tempBullet, 3f);
    }

    public void upgradeRange()
    {
        viewRange += viewRangeUpdate;
    }
    public void UpgradeDamage()
    {
        
    }
}
