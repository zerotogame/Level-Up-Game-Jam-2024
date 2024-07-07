using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    // Tutorial Paneles
    public GameObject panelTut1, panelTut2, panelTut3, panelTut4, panelTutorialParent;
    public GameObject tutOnBttn, tutOffBttn;

    public GameObject panelOpciones, panelPausa;
    public GameObject textoEstadoActivoOver, textoEstadoInactivoOver;

    // -------TUTORIAL BOTONES Y PANELES------------
    private void Start()
    {
        if (GameContStat.tutoriaActivo)
        {
            panelTutorialParent.SetActive(true);
            Time.timeScale = 0f;
        }
        else 
        {
            panelTutorialParent.SetActive(false);
            Time.timeScale = 1f;
        }
            
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
    public void InfoOnMouseOverBttn() 
    { 
        GameContStat.infoMouseOver = !GameContStat.infoMouseOver;
        if (GameContStat.infoMouseOver)
        {
            textoEstadoActivoOver.SetActive(true);
            textoEstadoInactivoOver.SetActive(false);
        }
        else
        {
            textoEstadoActivoOver.SetActive(false);
            textoEstadoInactivoOver.SetActive(true);
        }
    }
    public void InfoClickDerechoBttn() 
    { 
        GameContStat.infoMouseDerecho = !GameContStat.infoMouseDerecho;
    }

    // ---------BOTONES TUTORIAL-----------------
    public void PanelTutorial1Activo()
    {
        //GameContStat.infoMouseOver = true;
        GameContStat.tutoriaActivo = true;
        tutOnBttn.SetActive(true);
        tutOffBttn.SetActive(false);
    }
    public void PanelTutorial1Inactivo()
    {
        //GameContStat.infoMouseOver = false;
        GameContStat.tutoriaActivo = false;
        tutOnBttn.SetActive(false);
        tutOffBttn.SetActive(true);
    }
}
