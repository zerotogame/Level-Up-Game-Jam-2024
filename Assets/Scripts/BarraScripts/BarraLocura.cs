using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraLocura : MonoBehaviour
{

    public Image barraLocura;
    public GameObject pausePanel, victoryPanel, defeatPanel;

    private void Start()
    {
        GameContStat.velocidadPersonajesLoki = 2f;
        GameContStat.velocidadPersonajesVeles = 2f;
        GameContStat.velocidadPersonajesEris = 2f;
        GameContStat.velocidadPersonajesCthulhu = 2f;
}

    // -------PANELES BOTONES--------------
    public void PauseButton() 
    { 
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PauseButtonBack()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
    }
    public void SalirButton()
    {
        Application.Quit();
    }



    // -------PERONAJES BOTONES--------------
    public void LokiMasLocura() 
    {
        barraLocura.fillAmount += .05f;
        GameContStat.velocidadPersonajesLoki += 2f;
    }

    public void LokiMenosLocura()
    {
        barraLocura.fillAmount -= .05f;
        GameContStat.velocidadPersonajesLoki -= 2f;
    }

    public void ErisMasLocura()
    {
        barraLocura.fillAmount += .05f;
        GameContStat.velocidadPersonajesEris += 2f;
    }

    public void ErisMenosLocura()
    {
        barraLocura.fillAmount -= .05f;
        GameContStat.velocidadPersonajesEris -= 2f;
    }

    public void CuMasLocura()
    {
        barraLocura.fillAmount += .05f;
        GameContStat.velocidadPersonajesCthulhu += 2f;
    }

    public void CuMenosLocura()
    {
        barraLocura.fillAmount -= .05f;
        GameContStat.velocidadPersonajesCthulhu -= 2f;
    }

    public void VelesMasLocura()
    {
        barraLocura.fillAmount += .05f;
        GameContStat.velocidadPersonajesVeles += 2f;
    }

    public void VelesMenosLocura()
    {
        barraLocura.fillAmount -= .05f;
        GameContStat.velocidadPersonajesVeles -= 2f;
    }
}
