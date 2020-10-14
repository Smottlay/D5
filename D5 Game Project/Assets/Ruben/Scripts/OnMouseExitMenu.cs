using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseExitMenu : MonoBehaviour
{
    public GameObject menu;

    public void OnMouseExit()
    {
        menu.SetActive(false);
    }
}
