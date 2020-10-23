using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount;
    public GameObject turret;
    public GameObject tower;

    public float bulletRange = 1;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().RawDamage(damageAmount);
            collision.gameObject.GetComponent<Enemy>().tower = tower;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
        
 