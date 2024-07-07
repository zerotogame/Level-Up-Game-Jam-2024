using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    // Tutorial Paneles
    public GameObject panelTut1, panelTut2, panelTut3, panelTutParent;

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
        //Debug.Log("Continuar1Bttn");
        panelTut1.SetActive(false);
        panelTut2.SetActive(true);
    }
    public void Continuar2Bttn()
    {
        //Debug.Log("Continuar2Bttn");
        panelTut2.SetActive(false);
        panelTut3.SetActive(true);
    }
    public void Continuar3Bttn()
    {
        //Debug.Log("Continuar3Bttn");
        Time.timeScale = 1.0f;
        panelTut3.SetActive(false);

    }
    public void Continuar4Bttn()
    {
        //Debug.Log("Continuar4Bttn");
        panelTut3.SetActive(false);
        Time.timeScale = 1.0f;

        //Obtenemos el panel canvas padre de los tutoriales
        //panelTutParent.SetActive(false);
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
