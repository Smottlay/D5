using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveOverTime : MonoBehaviour
{
    public SkinnedMeshRenderer sMeshRenderer;
    public bool toggleDissolveValue;
    public float totalValue;
    public float AddOnDeath;
    void Start()
    {
        totalValue = 0f;
        toggleDissolveValue = false;
        sMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            toggleDissolveValue = !toggleDissolveValue;
        }
        if (toggleDissolveValue == true)
        {
            totalValue += AddOnDeath * Time.deltaTime;
        }
        if (toggleDissolveValue == false)
        {
            totalValue = 0f;
        }
        sMeshRenderer.material.SetFloat("_TimeValue", totalValue);
    }
}
