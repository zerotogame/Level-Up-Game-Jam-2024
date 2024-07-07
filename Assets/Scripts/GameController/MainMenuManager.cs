using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject opcionesPanel, creditosPanel, mainMenuPanel;
    public GameObject tutOnBttn, tutOffBttn;
    public GameObject infoCartasOnBttn, infoCartasOffBttn;

    private void Update()
    {
        if (GameContStat.tutoriaActivo)
            PanelTutorialActivo();
        else
            PanelTutorialInactivo();

        if (GameContStat.infoMouseOver)
            InfoCArtasOn();
        else
            InfoCArtasOff();
    }

    public void JugarBoton()
    {
        SceneManager.LoadScene("Game");
    }

    public void CargarIntro()
    {
            SceneManager.LoadScene("Introduction");
    }

    public void SalirBoton()
    {
        Application.Quit();
    }

    public void OpcionesBoton()
    {
        opcionesPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void OpcionesBackBoton()
    {
        opcionesPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void CreditosBoton()
    {
        creditosPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void CreditosBackBoton()
    {
        creditosPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void PanelTutorialActivo()
    {
        GameContStat.tutoriaActivo = true;
        tutOnBttn.SetActive(true);
        tutOffBttn.SetActive(false);
    }
    public void PanelTutorialInactivo()
    {
        GameContStat.tutoriaActivo = false;
        tutOnBttn.SetActive(false);
        tutOffBttn.SetActive(true);
    }

    public void InfoCArtasOn() 
    {
        GameContStat.infoMouseOver = true;
        infoCartasOnBttn.SetActive(true);
        infoCartasOffBttn.SetActive(false);
    }

    public void InfoCArtasOff() 
    {
        GameContStat.infoMouseOver = false;
        infoCartasOnBttn.SetActive(false);
        infoCartasOffBttn.SetActive(true);
    }
}
