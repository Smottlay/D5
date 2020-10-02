using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float splashRadius;
    public int damageAmount;

    public float kinematicCountdown;
    public float kinematicOffCountdown;

    public int spawnPointID;

    public Vector3 targetPos;
    private Vector3 startPos;
    private Vector3 nextPos;
    public GameObject mineLayer;

    public ParticleSystem explosion;

    public float speed;

    public string roadTag = "road";
    public string mineSpawnPointTag = "mineSpawnPoint";

    public Rigidbody rb;

    public void Start()
    {
        kinematicCountdown = 1.5f;
        kinematicOffCountdown = 1f;
    }


    public void Update()
    {
       gameObject.transform.position =  Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        kinematicCountdown -= Time.deltaTime;
        if(kinematicCountdown<= 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            kinematicCountdown = 0;
            kinematicOffCountdown -= Time.deltaTime;
        }
        if(kinematicOffCountdown <= 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            kinematicOffCountdown = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Explode();
        }
    }

    public void Explode()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);

        foreach (Collider nearbyEnemy in colliders)
        {
            if (nearbyEnemy.gameObject.tag == "enemy")
            {

                if (nearbyEnemy.GetComponent<Enemy>().mineDetecion == true)
                {
                    explosion.Play();
                    mineLayer.GetComponent<MineLayer>().activeSpawnPoints[spawnPointID] = true;
                    nearbyEnemy.GetComponent<Enemy>().MineDamage(damageAmount);
                    Destroy(gameObject);
                }
            }
        }
    }
}
