using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    GameObject barrack;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        range = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, range))
            {
                if (hit.transform.CompareTag("barrack"))
                {
                    barrack = hit.collider.gameObject;
                    Upgrade();
                }
            }
        }
    }

    public void Upgrade()
    {
        barrack.GetComponent<Barracks>().upgradeButton.SetActive(true);
    }
}
