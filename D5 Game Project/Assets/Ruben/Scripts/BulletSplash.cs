using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplash : MonoBehaviour
{
    //public int damageAmount;
    public float splashRadius;
    public int damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            splash();
        }

        if(collision.gameObject.tag == "road")
        {
            splash();
        }

        if(collision.gameObject.tag == "terrain")
        {
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
