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

    public GameObject rangeCircle;
    public GameObject shop;
    public GameObject pulse;
    public Transform enemy;

    public GameObject towerBase;
    public MeshRenderer emission;

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
    private float bulletReload;
    public float bulletrate;
    public float addPulse;

    public float particleReload;
    public float particleReloadTime = 2f;

    public int kills;
    public int rangeUpgrades;
    public int damageUpgrades;

    public void Start()
    {
        shop = GameObject.FindGameObjectWithTag("gameMaster");
        emission = towerBase.GetComponent<MeshRenderer>();
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
        if (shop.GetComponent<Shop>().canUpgradeRange == false)
        {
            viewRangeUpgradePossible = false;
        }
        else
        {
            viewRangeUpgradePossible = true;
        }
        if (viewRange >= maxUpgrade)
        {
            viewRangeUpgradePossible = false;
        }

        if (shop.GetComponent<Shop>().canUpgradeDamage == false)
        {
            damageUpgradePossible = false;
        }
        else
        {
            damageUpgradePossible = true;
        }
        if (damage >= maxDamageUpgrade)
        {
            damageUpgradePossible = false;
        }

        particleReload -= Time.deltaTime;

        muzzleFlash.IsAlive();
        bulletReload -= Time.deltaTime;
        addPulse = 2 - bulletReload;
        emission.material.SetFloat("_PulseTime", addPulse);

        if (enemy == null)
        {
            emission.material.SetFloat("_PulseTime", 0);
            return;
        }
           

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
        tempBullet.GetComponent<BulletSplash>().damageAmount = damage;
        tempBullet.GetComponent<BulletSplash>().tower = gameObject;

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
        if (damageUpgradePossible == true)
        {
            damage += damageUpgrade;
        }
    }
}
