using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerUpgrade : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;

    public bool isTurretUpgrade;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
