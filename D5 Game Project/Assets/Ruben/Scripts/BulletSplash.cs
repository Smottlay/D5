using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplash : MonoBehaviour
{
    //public int damageAmount;
    public float splashRadius;
    public int damageAmount;

    public ParticleSystem sploosh;
    public GameObject particle;
    public GameObject enemy;
    public GameObject turret;

    public void Start()
    {
        enemy = turret.gameObject.GetComponent<Turret>().enemy.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Instantiate(particle, enemy.transform.position, enemy.transform.rotation);
            sploosh.Play();
            splash();
        }

        if(collision.gameObject.tag == "road")
        {
            sploosh.Play();
            splash();
        }

        if(collision.gameObject.tag == "terrain")
        {
            sploosh.Play();
            splash();
        }
    }

    void splash()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);

        foreach (Collider nearbyEnemy in colliders)
        {
            if (nearbyEnemy.gameObject.tag == "enemy")
            {
                nearbyEnemy.GetComponent<Enemy>().RawDamage(damageAmount);
            }
        }

        Destroy(gameObject);
    }
}
