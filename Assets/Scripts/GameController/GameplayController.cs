using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject panelOpciones, panelPausa;
    public GameObject textoEstadoActivoOver, textoEstadoInactivoOver;

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
}
