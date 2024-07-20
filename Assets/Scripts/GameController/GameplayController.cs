using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject panelOpciones, panelPausa;
    public GameObject infoCartasOnBttn, infoCartasOffBttn;
    public GameObject tutOnBttn, tutOffBttn;
    public MusicBridge levelAudio;

    // -------BOTONES DE OPCIONES------------
    private void Start()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        levelAudio = instanciaMusic.GetComponent<MusicBridge>();
        levelAudio.NotificarPausaMusica(false);
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
    // -------PANELES BOTONES--------------
    public void PauseButton()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
        levelAudio.NotificarPausaMusica(true);
    }
    public void PauseButtonBack()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        levelAudio.NotificarPausaMusica(false);
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
