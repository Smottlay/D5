using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resource : MonoBehaviour
{
    private GameObject turret;
    private GameObject shop;
    public GameObject refund;
    public GameObject gameMaster;

    public Color hoverColor;
    private Color startColor;
    public Vector3 posOffSet;

    private Renderer rend;

    private bool mineralStatus;
    public bool mineralUsed;

    public GameObject statsPanel;
    public GameObject buildSign;

    BuildManager buildmanager;

    void Start()
    {
        mineralUsed = false;
        mineralStatus = true;
        buildmanager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        shop = GameObject.FindGameObjectWithTag("shop");
        gameMaster = GameObject.FindGameObjectWithTag("gameMaster");     
    }
    private void Update()
    {
        refund = GameObject.FindGameObjectWithTag("refund");
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildmanager.GetTurretToBuild() == null)
            return;
        if (mineralStatus == false)
            return;
        if (mineralUsed == true)
            return;

        if (turret != null)
        {
            Debug.Log("cant build");
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + posOffSet, transform.rotation);
        statsPanel.SetActive(true);

        Destroy(buildSign);
        gameMaster.GetComponent<Shop>().NoRefund();
        mineralUsed = true;
        buildmanager.NoTurretToBuild();
        shop.SetActive(true);
        refund.SetActive(false);
    }
    void OnMouseEnter()
    {
        if (mineralStatus == true)
        {
            if (mineralUsed == true)
                return;
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
    public void DisableMineral()
    {
        mineralStatus = false;
    }
    public void EnableMineral()
    {
        mineralStatus = true;
    }
} 