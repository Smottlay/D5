using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTurret : MonoBehaviour
{
    public GameObject bulletSpawner;
    public GameObject bullet;
    public GameObject turretRing;

    public ParticleSystem muzzleFlash;
    public AudioClip gunFire;
    public AudioClip laserLoad;
    public AudioSource audioS;

    public GameObject pulse;
    public Transform enemy;

    public float viewRange;
    public float viewRangeUpgrade;
    public float maxUpgrade;
    private bool viewRangeUpgradePossible;

    public bool splashTower;

    private string enemyTag = "enemy";

    private bool flashed;

    public float bulletSpeed;
    private float bulletReload;
    public float bulletrate;

    public float particleReload;
    public float particleReloadTime = 2f;
    public void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
        particleReload = particleReloadTime;
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
        particleReload -= Time.deltaTime;

        if (viewRange >= maxUpgrade)
        {
            viewRangeUpgradePossible = false;
        }

        muzzleFlash.IsAlive();
        bulletReload -= Time.deltaTime;

        if (enemy == null)
            return;

        if (enemy.tag == "Untagged")
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
            if(particleReload < particleReloadTime)
            {
                ParticlePlay();
            }
            if(particleReload <= 0)
            {
                Reload();
            }
        }
    }

    public void ParticlePlay()
    {
        if (muzzleFlash.IsAlive(true))
        {
            return;
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(laserLoad, 1);
            muzzleFlash.Play();
            particleReload = particleReloadTime;
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
        GetComponent<AudioSource> ().PlayOneShot (gunFire, 1);

        GameObject tempBullet;
        tempBullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;

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
        }
    }
    public void UpgradeDamage()
    {

    }
}
