using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resource : MonoBehaviour
{
    public GameObject drill;
    public Vector3 posOffSet;

    BuildManager buildmanager;
    private Renderer rend;

    public Color hoverColor;
    private Color startColor;

    private void Start()
    {
        buildmanager = BuildManager.instance;
        rend = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildmanager.GetTurretToBuild() == null)
            return;
        if (drill != null)
        {
            Debug.Log("cant build");
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        drill = (GameObject)Instantiate(turretToBuild, transform.position + posOffSet, transform.rotation);
        Destroy(gameObject);

        Instantiate(drill, transform.position + posOffSet, transform.rotation);
        Destroy(gameObject);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildmanager.GetTurretToBuild() == null)
            return;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
