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
    public int cripleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mineDetecion = true;
        healthBarVisible = false;
        transform.position = GameObject.FindGameObjectWithTag("spawner").transform.position;
        attackable = true;
        colider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && attacker != null)
        {
            //code to give player currency
            GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().destroyedCounter++;
            attacker.gameObject.GetComponent<Soldier>().searching = true;
            attacker.gameObject.GetComponent<Soldier>().target = null;
            Destroy(this.gameObject);
        }
        else if(health <= 0 && attacker == null)
        {
            //code to give player currency
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
                colider.enabled = true;
            }
        }
    }

    public void TargetReached()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().health -= finishDamage;
        GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().destroyedCounter++;
        Destroy(this.gameObject);
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
        colider.enabled = false;
        mineExplosion = true;
        mineDetecion = false;
    }
}
