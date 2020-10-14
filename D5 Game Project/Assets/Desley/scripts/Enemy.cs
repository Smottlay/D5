using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject attacker;

    public GameObject healthBar;

    public AudioSource death;

    public GameObject gameMaster;

    public AudioSource attackingSound;

    public SkinnedMeshRenderer sMeshRenderer;
    public float dissolveTimer;
    public float addOnDeath;
    public bool dissolving;
    Collider colider;

    public int maxHealth;
    public int health;
    public int finishDamage;
    public int coinReward;

    public bool attackable;
    public bool healthBarVisible;
    public bool mineExplosion;
    public bool mineDetecion;

    public float cripleTimer = 15;
    public float cripleCountdown;
    public float cripleSpeed;

    public float damageCountdown;

    public Animation walk;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        transform.position = GameObject.FindGameObjectWithTag("spawner").transform.position;
        colider = gameObject.GetComponent<BoxCollider>();
        sMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        gameMaster = GameObject.FindGameObjectWithTag("gameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        sMeshRenderer.material.SetFloat("_TimeValue", dissolveTimer);
        if (health <= 0 && attacker != null && !dissolving)
        {
            cripleSpeed = 0;
            gameObject.GetComponent<PathFinding>().normalSpeed = 0;
            gameObject.GetComponent<PathFinding>().speed = 0;
            gameObject.GetComponent<Animator>().SetBool("gettingAttacked", true);
            attacker.gameObject.GetComponent<Soldier>().target = null;
            attacker.gameObject.GetComponent<Soldier>().searching = true;
            gameMaster.GetComponent<Shop>().addGold();
            GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().destroyedCounter++;
            gameObject.tag = "Untagged";
            dissolving = true;
            death.Play();
        }
        else if (health <= 0 && attacker == null && !dissolving)
        {
            cripleSpeed = 0;
            gameObject.GetComponent<PathFinding>().normalSpeed = 0;
            gameObject.GetComponent<PathFinding>().speed = 0;
            gameObject.GetComponent<Animator>().SetBool("gettingAttacked", true);
            gameMaster.GetComponent<Shop>().addGold();
            GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawn>().destroyedCounter++;
            gameObject.tag = "Untagged";
            dissolving = true;
            death.Play();
        }
        
        if (dissolving)
        {
            dissolveTimer += addOnDeath * Time.deltaTime;
            healthBar.SetActive(false);
        }
        if(dissolveTimer >= .7f)
        {
            Destroy(gameObject);
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
                gameObject.GetComponent<Animator>().SetFloat("speed", .5f);
                mineDetecion = false;
            }
            
            if (cripleCountdown <= 0)
            {
                gameObject.GetComponent<PathFinding>().NormalSpeed();
                gameObject.GetComponent<Animator>().SetFloat("speed", 1f);
                cripleCountdown = cripleTimer;
                mineExplosion = false;
                mineDetecion = true;
            }
        }

        if (damageCountdown <= 0f)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>().health -= finishDamage;
            attackingSound.Play();
            damageCountdown = 1.2f;
        }
    }

    public void AttackGate()
    {
        if (!dissolving)
        {
            gameObject.GetComponent<PathFinding>().speed = 0;
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
            damageCountdown -= Time.deltaTime;
        }
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
