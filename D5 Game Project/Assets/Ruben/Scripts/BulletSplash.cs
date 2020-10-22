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
    public GameObject tower;


    public void Start()
    {
        enemy = turret.gameObject.GetComponent<SplashTurret>().enemy.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Instantiate(particle, enemy.transform.position, enemy.transform.rotation);
            sploosh.Play();
            splash();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void splash()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);

        foreach (Collider nearbyEnemy in colliders)
        {
            if(nearbyEnemy.gameObject.tag == "soldier")
            {
                print("lessdamage");
                nearbyEnemy.GetComponent<Enemy>().RawDamage(damageAmount/2);
                nearbyEnemy.GetComponent<Enemy>().tower = tower;
            }

            else if (nearbyEnemy.gameObject.tag == "enemy")
            {
                print("moredamage");
                nearbyEnemy.GetComponent<Enemy>().RawDamage(damageAmount);
                nearbyEnemy.GetComponent<Enemy>().tower = tower;
           
            }
        }

        Destroy(gameObject);
    }
}
