using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : MonoBehaviour
{
    public int health;
    public int attackDamage;
    public float attackRate;

    public GameObject normal;
    public GameObject speed;
    public GameObject tank;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        normal.GetComponent<Enemy>().soldier = this.gameObject;
        speed.GetComponent<Enemy>().soldier = this.gameObject;
        tank.GetComponent<Enemy>().soldier = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
