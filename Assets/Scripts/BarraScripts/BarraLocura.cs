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
        Time.timeScale = 1f;
        GameContStat.velocidadPersonajesLoki = 1f;
        GameContStat.velocidadPersonajesVeles = 1f;
        GameContStat.velocidadPersonajesEris = 1f;
        GameContStat.velocidadPersonajesCthulhu = 1f;
    }
    private void Update()
    {
        CondicionDeVictoria();
        CondicionDeDerrota();
        TeclasLocura();
        BarraAutomacia();
    }

    void TeclasLocura()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            LokiMasLocura();
        if (Input.GetKeyDown(KeyCode.W))
            LokiMenosLocura();
        if (Input.GetKeyDown(KeyCode.A))
            ErisMasLocura();
        if (Input.GetKeyDown(KeyCode.S))
            ErisMenosLocura();
        if (Input.GetKeyDown(KeyCode.Z))
            VelesMasLocura();
        if (Input.GetKeyDown(KeyCode.X))
            VelesMenosLocura();
        if (Input.GetKeyDown(KeyCode.E))
            CuMasLocura();
        if (Input.GetKeyDown(KeyCode.R))
            CuMenosLocura();
    }

    void BarraAutomacia()
    {
        if (barraLocura.fillAmount >= 0.7f)
        {
            barraLocura.fillAmount += 0.025f * Time.deltaTime;
            GameContStat.velocidadPersonajesLoki += .5f * Time.deltaTime;
            GameContStat.velocidadPersonajesVeles += .5f * Time.deltaTime;
            GameContStat.velocidadPersonajesEris += .5f * Time.deltaTime;
            GameContStat.velocidadPersonajesCthulhu += .5f * Time.deltaTime;
        }
        if (barraLocura.fillAmount < 0.7f && barraLocura.fillAmount > 0.3f)
        {
            barraLocura.fillAmount = barraLocura.fillAmount;
        }
        if (barraLocura.fillAmount < 0.6f)
        {
            GameContStat.velocidadPersonajesLoki -= .5f * Time.deltaTime;
            GameContStat.velocidadPersonajesVeles -= .5f * Time.deltaTime;
            GameContStat.velocidadPersonajesEris -= .5f * Time.deltaTime;
            GameContStat.velocidadPersonajesCthulhu -= .5f * Time.deltaTime;
            CondicionesVelocidadPerosnajes();
        }
        if (barraLocura.fillAmount < 0.3f)
            barraLocura.fillAmount -= 0.025f * Time.deltaTime;
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
    public void ReiniciarButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    private void CondicionDeVictoria()
    {
        if (barraLocura.fillAmount >= 1)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void CondicionDeDerrota()
    {
        if (barraLocura.fillAmount <= 0)
        {
            defeatPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // -------PERONAJES BOTONES--------------

    public void LokiMasLocura()
    {
        barraLocura.fillAmount += .025f;
        GameContStat.velocidadPersonajesLoki += 1f;
    }

    public void LokiMenosLocura()
    {
        barraLocura.fillAmount -= .025f;
        GameContStat.velocidadPersonajesLoki -= 1f;
        CondicionesVelocidadPerosnajes();
    }

    public void ErisMasLocura()
    {
        barraLocura.fillAmount += .025f;
        GameContStat.velocidadPersonajesEris += 1f;
    }

    public void ErisMenosLocura()
    {
        barraLocura.fillAmount -= .025f;
        GameContStat.velocidadPersonajesEris -= 1f;
        CondicionesVelocidadPerosnajes();
    }

    public void CuMasLocura()
    {
        barraLocura.fillAmount += .025f;
        GameContStat.velocidadPersonajesCthulhu += 1f;
    }

    public void CuMenosLocura()
    {
        barraLocura.fillAmount -= .025f;
        GameContStat.velocidadPersonajesCthulhu -= 1f;
        CondicionesVelocidadPerosnajes();
        
    }

    public void VelesMasLocura()
    {
        barraLocura.fillAmount += .025f;
        GameContStat.velocidadPersonajesVeles += 1f;
    }

    public void VelesMenosLocura()
    {
        barraLocura.fillAmount -= .025f;
        GameContStat.velocidadPersonajesVeles -= 1f;
        CondicionesVelocidadPerosnajes();
    }

    private void CondicionesVelocidadPerosnajes()
    {
        if (GameContStat.velocidadPersonajesLoki <= 1f)
            GameContStat.velocidadPersonajesLoki = 1f;
        if (GameContStat.velocidadPersonajesEris <= 1f)
            GameContStat.velocidadPersonajesEris = 1f;
        if (GameContStat.velocidadPersonajesCthulhu <= 1f)
            GameContStat.velocidadPersonajesCthulhu = 1f;
        if (GameContStat.velocidadPersonajesVeles <= 1f)
            GameContStat.velocidadPersonajesVeles = 1f;
    }
}
