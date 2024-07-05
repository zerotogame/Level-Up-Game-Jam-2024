using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCard2 : MonoBehaviour
{
    private GameObject velesDorsalPanel;
    bool pressed = false;
    private void Start()
    {
        velesDorsalPanel = GameObject.Find("VelesDorsalPanel");
    }

    private void OnMouseDown()
    {
        pressed = true;
    }

    private void OnMouseUp()
    {
        pressed = false;
    }

    private void OnMouseOver()
    {
        if (!pressed) 
            velesDorsalPanel.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        else
            velesDorsalPanel.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnMouseExit()
    {
        velesDorsalPanel.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
