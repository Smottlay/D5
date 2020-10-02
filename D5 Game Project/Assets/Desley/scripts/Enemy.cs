using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject attacker;

    public GameObject healthBar;

    Collider colider;

    public int maxHealth;
    public int health;
    public int finishDamage;
    public int coinReward;

    public bool attackable;
    public bool healthBarVisible;
    public bool mineExplosion;
    public bool mineDetecion;

    public float cripleTimer;
    public float cripleCountdown;
    public float cripleSpeed;

    public float damageCountdown;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mineDetecion = true;
        healthBarVisible = false;
        transform.position = GameObject.FindGameObjectWithTag("spawner").transform.position;
        attackable = true;
        colider = gameObject.GetComponent<BoxCollider>();
        damageCountdown = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && attacker != null)
        {
            attacker.gameObject.GetComponent<Soldier>().target = null;
            attacker.gameObject.GetComponent<Soldier>().searching = true;
            GameObject.FindGameObjectWithTag("shop").GetComponent<Shop>().deadEnemy = gameObject;
            GameObject.FindGameObjectWithTag("shop").GetComponent<Shop>().addGold();
            GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().destroyedCounter++;
            Destroy(this.gameObject);
        }
        else if(health <= 0 && attacker == null)
        {
            GameObject.FindGameObjectWithTag("shop").GetComponent<Shop>().deadEnemy = gameObject;
            GameObject.FindGameObjectWithTag("shop").GetComponent<Shop>().addGold();
            GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().destroyedCounter++;
            Destroy(this.gameObject);
        }

        if(health < maxHealth && !healthBarVisible)
        {
            healthBar.SetActive(true);
            healthBarVisible = true;
        }

        if(mineExplosion == true)
        {
            cripleCountdown -= Time.deltaTime;
            if (cripleCountdown > 0)
            {
                gameObject.GetComponent<PathFinding>().speed = cripleSpeed;
                mineDetecion = false;
            }
            
            if (cripleCountdown <= 0)
            {
                gameObject.GetComponent<PathFinding>().NormalSpeed();
                cripleCountdown = cripleTimer;
                mineExplosion = false;
                mineDetecion = true;
            }
        }

        else if (damageCountdown <= 0f)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().health -= finishDamage;
            damageCountdown = 1.25f;
        }
    }

    public void AttackGate()
    {
        gameObject.GetComponent<PathFinding>().speed = 0;
        gameObject.GetComponent<Animator>().SetBool("Attack", true);
        damageCountdown -= Time.deltaTime;
    }

    public void RawDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    public void SplashDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    public void MineDamage(int damageAmount)
    {
        health -= damageAmount;
        mineExplosion = true;
        mineDetecion = false;
    }
}
