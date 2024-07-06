using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCard2 : MonoBehaviour
{
    private GameObject[] panelesDioses = new GameObject[11];

    bool pressed = false;
    public float CardIDInfo;
    private void Start()
    {
        panelesDioses[0] = GameObject.Find("LokiDorsalPanel");
        panelesDioses[3] = GameObject.Find("ErisDorsalPanel");
        panelesDioses[6] = GameObject.Find("VelesDorsalPanel");
        panelesDioses[9] = GameObject.Find("CthulhuDorsalPanel");

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
        LokiDorsalPanelMethod();
        ErisDorsalPanelMethod();
        VelesDorsalPanelMethod();
        CthulhuDorsalPanelMethod();
    }

    private void OnMouseExit()
    {
        panelesDioses[0].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[3].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[6].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[9].gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void LokiDorsalPanelMethod()
    {
        if (CardIDInfo == 0)
        {
            if (!pressed)
                panelesDioses[0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[0].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void ErisDorsalPanelMethod()
    {
        if (CardIDInfo == 3)
        {
            if (!pressed)
                panelesDioses[3].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[3].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void VelesDorsalPanelMethod() 
    {
        if (CardIDInfo==6) 
        {
            if (!pressed)
                panelesDioses[6].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[6].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void CthulhuDorsalPanelMethod()
    {
        if (CardIDInfo == 9)
        {
            if (!pressed)
                panelesDioses[6].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[6].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
