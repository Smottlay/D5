using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Foundation : MonoBehaviour
{
    private GameObject turret;
    private GameObject shop;
    public GameObject refund;
    public GameObject gameMaster;

    public Color hoverColor;
    private Color startColor;
    public Vector3 posOffSet;

    private Renderer rend;
    public AudioSource thunk;

    public bool foundationStatus;

    public GameObject statsPanel;
    public GameObject buildSign;

    BuildManager buildmanager;

    void Start()
    {
        foundationStatus = true;
        buildmanager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        shop = GameObject.FindGameObjectWithTag("shop");
        gameMaster = GameObject.FindGameObjectWithTag("gameMaster");
    }
    public void Update()
    {
        refund = GameObject.FindGameObjectWithTag("refund");
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildmanager.GetTurretToBuild() == null)
            return;
        if (foundationStatus == false)
            return;

        if (turret != null)
        {
            Debug.Log("cant build");
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + posOffSet, transform.rotation);
        statsPanel.SetActive(true);

        gameMaster.GetComponent<Shop>().NoRefund();
        buildmanager.NoTurretToBuild();
        shop.SetActive(true);
        refund.SetActive(false);

        Destroy(buildSign);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }
    void OnMouseEnter()
    {
        if(foundationStatus == true)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (buildmanager.GetTurretToBuild() == null)
                return;
            rend.material.color = hoverColor;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void DisableFoundation()
    {
        foundationStatus = false;
    }
    public void EnableFoundation()
    {
        foundationStatus = true;
    }
}
