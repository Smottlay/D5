using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Transform target;

    public int attackDamage;
    public float attackRate;
    public float attackCountdown = 0f;
    public float range;
    public float rotationSpeed = 10f;

    public bool searching;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, .1f);
        searching = true; 
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject attackableEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range && searching && enemy.GetComponent<Enemy>().attackable==true)
            {
                enemy.GetComponent<Enemy>().attackable = false;
                enemy.GetComponent<Enemy>().attacker = gameObject;
                attackableEnemy = enemy;
                target = attackableEnemy.transform;
                searching = false;
            }
        }
    }
   
    void Update()
    {
       if (target == null)
       {
            gameObject.GetComponent<Animator>().SetBool("Attack", false);
            return;
       }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        target.GetComponent<PathFinding>().speed = 0;

        if(attackCountdown <= 0f)
        {
            Attack();
            attackCountdown = 1f / attackRate;
        }

        attackCountdown -= Time.deltaTime;
    }

    void Attack()
    {
        gameObject.GetComponent<Animator>().SetBool("Attack", true);
        target.GetComponent<Animator>().SetBool("gettingAttacked", true);
        target.GetComponent<Enemy>().health -= attackDamage;
    }

   private void OnDrawGizmosSelected()
   { 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
   }
}
