using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Foundation : MonoBehaviour
{
    private GameObject turret;

    public Color hoverColor;
    private Color startColor;
    public Vector3 posOffSet;

    private Renderer rend;

    BuildManager buildmanager;

    void Start()
    {
        buildmanager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildmanager.GetTurretToBuild() == null)
            return;

        if (turret != null)
        {
            Debug.Log("cant build");
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + posOffSet, transform.rotation);
        Destroy(gameObject);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildmanager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
