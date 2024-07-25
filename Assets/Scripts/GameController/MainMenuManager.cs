using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject opcionesPanel, creditosPanel, mainMenuPanel;
    public GameObject mainBttnPanel, modosBttnPanel;
    public GameObject tutOnBttn, tutOffBttn;
    public GameObject infoCartasOnBttn, infoCartasOffBttn;
    public GameObject aciveButtons, deactiveButtons;

    private void Start()
    {
        ActiveButtonsModes();
    }

    private void Update()
    {
        if (GameContStat.infoMouseOver)
            InfoCArtasOn();
        else
            InfoCArtasOff();

        if (GameContStat.isTutorialOn)
            TutOnBttn();
        else
            TutOffBttn();
    }

    public void JugarBoton()
    {
        mainBttnPanel.SetActive(false);
        modosBttnPanel.SetActive(true);
    }
    public void JugarBackBoton()
    {
        mainBttnPanel.SetActive(true);
        modosBttnPanel.SetActive(false);
    }

    private void ActiveButtonsModes() 
    {
        if (GameContStat.introPlayed)
        {
            deactiveButtons.SetActive(false);
            aciveButtons.SetActive(true);
        }
    }

    public void FacilBttn() 
    {
        GameContStat.modoDeJuego = 1;
        SceneManager.LoadScene("Game");
    }
    public void NormalBttn()
    {
        GameContStat.modoDeJuego = 2;
        SceneManager.LoadScene("Game");
    }
    public void DificilBttn()
    {
        GameContStat.modoDeJuego = 3;
        SceneManager.LoadScene("Game");
    }

    public void TutorialBoton() 
    {
        GameContStat.modoDeJuego = 1;
        SceneManager.LoadScene("TutorialScene");
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

    public void TutOnBttn()
    {
        GameContStat.isTutorialOn = true;
        tutOnBttn.SetActive(true);
        tutOffBttn.SetActive(false);
    }
    public void TutOffBttn()
    {
        GameContStat.isTutorialOn = false;
        tutOnBttn.SetActive(false);
        tutOffBttn.SetActive(true);
    }
}
