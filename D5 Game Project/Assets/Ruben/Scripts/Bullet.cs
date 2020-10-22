using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount;
    public GameObject turret;
    public GameObject tower;

    public float bulletRange = 1;

    private void Update()
    {
        DoDamage();
    }

    public void DoDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bulletRange);
        foreach (Collider enemy in colliders)
        {
            if (enemy.gameObject.tag == "enemy")
            {
                enemy.gameObject.GetComponent<Enemy>().RawDamage(damageAmount);
                enemy.gameObject.GetComponent<Enemy>().tower = tower;
                Destroy(gameObject);
            }
        }
    }   
}
