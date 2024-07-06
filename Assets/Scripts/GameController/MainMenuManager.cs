using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject opcionesPanel, creditosPanel, mainMenuPanel;

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
}
