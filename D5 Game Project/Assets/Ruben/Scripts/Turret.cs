using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : TowerUpgrade
{
    public GameObject bulletSpawner;
    public GameObject bullet;
    public GameObject turretRing;

    public GameObject shop;

    public GameObject rangeCircle;

    public ParticleSystem muzzleFlash;
    public AudioSource gunFire;

    public Transform enemy;

    public float viewRange;
    public float viewRangeUpgrade;
    public float maxUpgrade;
    public bool viewRangeUpgradePossible;

    public int damage;
    public int damageUpgrade;
    public float maxDamageUpgrade;
    public bool damageUpgradePossible;

    public bool splashTower;

    private string enemyTag = "enemy";

    private bool flashed;

    public float bulletSpeed;
    public float bulletReload;
    public float bulletrate;
    public void Start()
    {
        viewRangeUpgradePossible = true;
        InvokeRepeating("targetToShoot", 0f, 0.5f);
        shop = GameObject.FindGameObjectWithTag("gameMaster");
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
        if(shop.GetComponent<Shop>().canUpgradeRange == false)
        {
            viewRangeUpgradePossible = false;
        }
        else
        {
            viewRangeUpgradePossible = true;
        }

        if(damage >= maxDamageUpgrade)
        {
            damageUpgradePossible = false;
        }
        if(shop.GetComponent<Shop>().canUpgradeDamage == false)
        {
            damageUpgradePossible = false;
        }
        else
        {
            damageUpgradePossible = true;
        }

        muzzleFlash.IsAlive();
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
        tempBullet.GetComponent<Bullet>().damageAmount = damage;

        if (tempBullet.tag == "rocket")
        {
            tempBullet.GetComponent<BulletSplash>().turret = gameObject;
        }
        else if (tempBullet.tag == "bullet")
        {
            tempBullet.GetComponent<Bullet>().turret = gameObject;
        }



        tempBullet.transform.Rotate(Vector3.right * -90);

        Rigidbody tempRid;
        tempRid = tempBullet.GetComponent<Rigidbody>();

        tempRid.AddForce(transform.forward * bulletSpeed);

        Destroy(tempBullet, 3f);
    }

    public void UpgradeRange()
    {
        if (viewRangeUpgradePossible == true)
        {
            viewRange += viewRangeUpgrade;
            rangeCircle.transform.localScale = new Vector3(viewRange, viewRange, viewRange) * 2;
        }
    }
    public void UpgradeDamage()
    {
        if(damageUpgradePossible == true)
        {
            damage += damageUpgrade;
        }
    }
}
