using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletSpawner;
    public GameObject bullet;

    public Transform enemy;

    public float bulletSpeed;
    private float bulletReload = 0f;
    public float bulletrate;

    void Start()
    {
        enemy = gameObject.GetComponent<TurretRing>().enemyTarget;
    }

    void Update()
    {
        bulletReload -= Time.deltaTime;
        transform.LookAt(new Vector3(transform.position.x, enemy.position.y, transform.position.z));
    }

    public void reload()
    {
        if (bulletReload <= 0f)
        {
            shoot();
            bulletReload = 1f / bulletrate;
        }
    }
    public void shoot()
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
