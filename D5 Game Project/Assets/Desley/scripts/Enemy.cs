using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int attackDamage;
    public float attackRate;
    public int finishDamage;
    public int coinReward;

    public bool canAttack;
    public bool searching;
    public bool soldierAlive;

    public int normalSpeed;

    public GameObject soldier;

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = this.gameObject.GetComponent<PathFinding>().speed;
        searching = true;
        canAttack = false;
        soldierAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //code to give player currency
            Destroy(this.gameObject);
        }

        if (searching)
        {
            SearchForSoldier();
        }

        if (canAttack)
        {
            AttackSoldier();
        }
    }

    public void SearchForSoldier()
    {
        if(Vector3.Distance(soldier.transform.position, transform.position) <= .5f)
        {
            searching = false;
            this.gameObject.GetComponent<PathFinding>().speed = 0;
            canAttack = true;
        }
    }

    public void AttackSoldier()
    {
        soldier.GetComponent<soldier>().health -= attackDamage;
        HasAttackedSoldier();
    }

    public void HasAttackedSoldier()
    {
        if(soldier.GetComponent<soldier>().health <= 0)
        {
            canAttack = false;
            this.gameObject.GetComponent<PathFinding>().speed = normalSpeed;
        }
    }

    public void TargetReached()
    {
        //code to do dmg to player
        Destroy(this.gameObject);
    }
}
