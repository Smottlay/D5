using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplash : MonoBehaviour
{
    //public int damageAmount;
    public float splashRadius;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            splash();
        }
    }

    void splash()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);

        foreach(Collider nearbyEnemy in colliders)
        {
            print("sploosh");
        }

        Destroy(gameObject);
    }
}
