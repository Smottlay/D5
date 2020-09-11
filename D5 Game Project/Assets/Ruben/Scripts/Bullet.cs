using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //collision.gameObject.GetComponent<Enemy>().health(damageAmount);
            print("hit");
            Destroy(gameObject);
        }
    }
}
