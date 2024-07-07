using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    // Tutorial Paneles
    public GameObject panelTut1, panelTut2, panelTut3, panelTut4, panelTutParent;

    public GameObject panelOpciones, panelPausa;
    public GameObject tutOnBttn, tutOffBttn, infoCartasOnBttn, infoCartasOffBttn;

    // -------TUTORIAL BOTONES Y PANELES------------
    private void Start()
    {
        if (GameContStat.tutoriaActivo)
        {
            Time.timeScale = 0f;
            panelTutParent.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1f;
            panelTutParent.SetActive(false);
        }
    }
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
    public void Continuar1Bttn()
    {
        panelTut1.SetActive(false);
        panelTut2.SetActive(true);
    }
    public void Continuar2Bttn()
    {
        panelTut2.SetActive(false);
        panelTut3.SetActive(true);
    }
    public void Continuar3Bttn()
    {
        panelTut3.SetActive(false);
        panelTut4.SetActive(true);
    }
    public void Continuar4Bttn()
    {
        panelTut4.SetActive(false);
        Time.timeScale = 1.0f;
    }


    // -------PANELES BOTONES--------------
    public void PauseButton()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PauseButtonBack()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OpcionesBttn()
    {
        panelOpciones.SetActive(true);
        panelPausa.SetActive(false);
    }
    public void OpcionesBackBttn()
    {
        panelOpciones.SetActive(false);
        panelPausa.SetActive(true);
    }

    // -------BOTONES OPCIONES--------------

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
