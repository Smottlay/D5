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
    public float viewRangeUpgrade;
    public float maxUpgrade;
    private bool viewRangeUpgradePossible;

    private string enemyTag = "enemy";

    private bool flashed;


    public float bulletSpeed;
    private float bulletReload;
    public float bulletrate;
    public void Start()
    {
        viewRangeUpgradePossible = true;
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
        if(viewRange >= maxUpgrade)
        {
            viewRangeUpgradePossible = false;
        }


        bulletReload -= Time.deltaTime;

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

            Reload();
        }
    }

    public void Reload()
    {
        if (enemy == null)
        {
            return;
        }
        else if (bulletReload <= 0f && enemy.GetComponent<Enemy>().dissolving == false)
        {
            bulletReload = 1f / bulletrate;
            Shoot();
        }
    }


    public void Shoot()
    {
        muzzleFlash.Play();
        gunFire.Play();

        GameObject tempBullet;
        tempBullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;

        if(tempBullet.tag == "rocket")
        {
            tempBullet.GetComponent<BulletSplash>().turret = gameObject;
        }
        else if(tempBullet.tag == "bullet")
        {
            tempBullet.GetComponent<Bullet>().turret = gameObject;
        }



        tempBullet.transform.Rotate(Vector3.right * -90);

        Rigidbody tempRid;
        tempRid = tempBullet.GetComponent<Rigidbody>();

        tempRid.AddForce(transform.forward * bulletSpeed);

        Destroy(tempBullet, 3f);
    }

    public void upgradeRange()
    {
        if (viewRangeUpgradePossible == true)
        {
            viewRange += viewRangeUpgrade;
        }
    }
    public void UpgradeDamage()
    {
        
    }
}
