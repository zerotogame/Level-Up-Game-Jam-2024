using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraLocura : MonoBehaviour
{

    public Image barraLocura;
    public GameObject victoryPanel, defeatPanel;
    [SerializeField] private float valorIncremento = 0.05f;
    [SerializeField] private float valorDecremento = 0.025f;


    private void Start()
    {
        Time.timeScale = 1f;
        GameContStat.velocidadPersonajesLoki = 1f;
        GameContStat.velocidadPersonajesVeles = 1f;
        GameContStat.velocidadPersonajesEris = 1f;
        GameContStat.velocidadPersonajesCthulhu = 1f;
        GameContStat.barraLocuraCantidad = 0.5f;
    }
    private void Update()
    {
        GameContStat.barraLocuraCantidad = barraLocura.fillAmount;
        CondicionDeVictoria();
        CondicionDeDerrota();
        TeclasLocura();
        BarraAutomacia();
    }

    void TeclasLocura()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            LokiMasLocura(valorIncremento);
        if (Input.GetKeyDown(KeyCode.W))
            LokiMenosLocura();
        if (Input.GetKeyDown(KeyCode.A))
            ErisMasLocura(valorIncremento);
        if (Input.GetKeyDown(KeyCode.S))
            ErisMenosLocura();
        if (Input.GetKeyDown(KeyCode.Z))
            VelesMasLocura(valorIncremento);
        if (Input.GetKeyDown(KeyCode.X))
            VelesMenosLocura();
        if (Input.GetKeyDown(KeyCode.E))
            CuMasLocura(valorIncremento);
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
    public void CondicionDeDerrota()
    {
        if (barraLocura.fillAmount <= 0)
        {
            defeatPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // -------PERONAJES BOTONES--------------

    public void LokiMasLocura(float valorIncremento)
    {
        barraLocura.fillAmount += valorIncremento;
        GameContStat.velocidadPersonajesLoki += 1f;
    }

    public void LokiMenosLocura()
    {
        barraLocura.fillAmount -= valorDecremento;
        GameContStat.velocidadPersonajesLoki -= 1f;
        CondicionesVelocidadPerosnajes();
    }

    public void ErisMasLocura(float valorIncremento)
    {
        barraLocura.fillAmount += valorIncremento;
        GameContStat.velocidadPersonajesEris += 1f;
    }

    public void ErisMenosLocura()
    {
        barraLocura.fillAmount -= valorDecremento;
        GameContStat.velocidadPersonajesEris -= 1f;
        CondicionesVelocidadPerosnajes();
    }

    public void CuMasLocura(float valorIncremento)
    {
        barraLocura.fillAmount += valorIncremento;
        GameContStat.velocidadPersonajesCthulhu += 1f;
    }

    public void CuMenosLocura()
    {
        barraLocura.fillAmount -= valorDecremento;
        GameContStat.velocidadPersonajesCthulhu -= 1f;
        CondicionesVelocidadPerosnajes();
        
    }

    public void VelesMasLocura(float valorIncremento)
    {
        barraLocura.fillAmount += valorIncremento;
        GameContStat.velocidadPersonajesVeles += 1f;
    }

    public void VelesMenosLocura()
    {
        barraLocura.fillAmount -=valorDecremento;
        GameContStat.velocidadPersonajesVeles -= 1f;
        CondicionesVelocidadPerosnajes();
    }

    public void DecreaseLocura(float decrement,GodType godType)
    {
        barraLocura.fillAmount -= decrement;
        CondicionesVelocidadPorTipoDios(godType);


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

    private void CondicionesVelocidadPorTipoDios(GodType godType)
    {
        if (godType == GodType.Loki)
        {
            if (GameContStat.velocidadPersonajesLoki <= 1f)
                GameContStat.velocidadPersonajesLoki = 1f;
        }
        if (godType == GodType.Eris)
        {
            if (GameContStat.velocidadPersonajesEris <= 1f)
                GameContStat.velocidadPersonajesEris = 1f;
        }
        if (godType == GodType.Cthulhu)
        {
            if (GameContStat.velocidadPersonajesCthulhu <= 1f)
                GameContStat.velocidadPersonajesCthulhu = 1f;
        }
        if (godType == GodType.Veles)
        {
            if (GameContStat.velocidadPersonajesVeles <= 1f)
                GameContStat.velocidadPersonajesVeles = 1f;
        }
    }
}
