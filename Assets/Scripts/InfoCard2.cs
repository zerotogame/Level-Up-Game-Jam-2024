using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCard2 : MonoBehaviour
{
    private GameObject[] panelesDioses = new GameObject[12];

    bool pressed = false;
    public float CardIDInfo;
    private void Start()
    {
        panelesDioses[0] = GameObject.Find("LokiDorsalPanel");
        panelesDioses[1] = GameObject.Find("LokiFrontal1Panel");
        panelesDioses[3] = GameObject.Find("ErisDorsalPanel");
        panelesDioses[4] = GameObject.Find("ErisFrontal1Panel");
        panelesDioses[6] = GameObject.Find("VelesDorsalPanel");
        panelesDioses[7] = GameObject.Find("VelesFrontal1Panel");
        panelesDioses[8] = GameObject.Find("VelesFrontal2Panel");
        panelesDioses[9] = GameObject.Find("CthulhuDorsalPanel");
        panelesDioses[10] = GameObject.Find("CthulhuFrontal1Panel");
        panelesDioses[11] = GameObject.Find("CthulhuFrontal2Panel");

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
        if (GameContStat.infoMouseOver && !GameContStat.infoMouseDerecho)
        {
            LokiDorsalPanelMethod();
            LokiFrontal1PanelMethod();
            ErisDorsalPanelMethod();
            ErisFrontal1PanelMethod();
            VelesDorsalPanelMethod();
            VelesFrontal1PanelMethod();
            VelesFrontal2PanelMethod();
            CthulhuDorsalPanelMethod();
            CthulhuFrontal1PanelMethod();
            CthulhuFrontal2PanelMethod();
        }
        if (GameContStat.infoMouseDerecho) 
        {
            if(Input.GetMouseButtonDown(1))
            {
                LokiDorsalPanelMethod();
                LokiFrontal1PanelMethod();
                ErisDorsalPanelMethod();
                ErisFrontal1PanelMethod();
                VelesDorsalPanelMethod();
                VelesFrontal1PanelMethod();
                VelesFrontal2PanelMethod();
                CthulhuDorsalPanelMethod();
                CthulhuFrontal1PanelMethod();
                CthulhuFrontal2PanelMethod();
            }
        }
    }

    private void OnMouseExit()
    {
        panelesDioses[0].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[1].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[3].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[4].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[6].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[7].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[8].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[9].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[10].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        panelesDioses[11].gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
    private void LokiFrontal1PanelMethod()
    {
        if (CardIDInfo == 1)
        {
            if (!pressed)
                panelesDioses[1].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[1].gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
    private void ErisFrontal1PanelMethod()
    {
        if (CardIDInfo == 4)
        {
            if (!pressed)
                panelesDioses[4].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[4].gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
    private void VelesFrontal1PanelMethod()
    {
        if (CardIDInfo == 7)
        {
            if (!pressed)
                panelesDioses[7].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[7].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void VelesFrontal2PanelMethod()
    {
        if (CardIDInfo == 8)
        {
            if (!pressed)
                panelesDioses[8].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[8].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void CthulhuDorsalPanelMethod()
    {
        if (CardIDInfo == 9)
        {
            if (!pressed)
                panelesDioses[9].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[9].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void CthulhuFrontal1PanelMethod()
    {
        if (CardIDInfo == 10)
        {
            if (!pressed)
                panelesDioses[10].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[10].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void CthulhuFrontal2PanelMethod()
    {
        if (CardIDInfo == 11)
        {
            if (!pressed)
                panelesDioses[11].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            else
                panelesDioses[11].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
