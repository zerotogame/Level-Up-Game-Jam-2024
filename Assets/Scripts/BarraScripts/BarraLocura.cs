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
    public MusicBridge levelAudio;
    private void Start()
    {
        CheckModo();
        Time.timeScale = 1f;
        GameContStat.velocidadPersonajesLoki = 1f;
        GameContStat.velocidadPersonajesVeles = 1f;
        GameContStat.velocidadPersonajesEris = 1f;
        GameContStat.velocidadPersonajesCthulhu = 1f;
        GameContStat.barraLocuraCantidad = 0.5f;

        GameObject instanciaMusic = GameObject.Find("Music");
        levelAudio = instanciaMusic.GetComponent<MusicBridge>();
        levelAudio.NotificarEstadoJuego("JuegoEnCurso");
    }
    private void Update()
    {
        GameContStat.barraLocuraCantidad = barraLocura.fillAmount;
        CondicionDeVictoria();
        CondicionDeDerrota();
        TeclasLocura();
        BarraLocuraMusica();
    }

    void CheckModo() // Modo de Juego
    {
        if (GameContStat.modoDeJuego == 1) // Facil
        {
            valorIncremento = 0.1f;
            valorDecremento = 0f;
        }
        if (GameContStat.modoDeJuego == 2) // Normal
        {
            valorIncremento = 0.075f;
        }
        if (GameContStat.modoDeJuego == 3) // Dificil
        {
            valorIncremento = 0.05f;
        }
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

    void BarraLocuraMusica()
    {
        if (barraLocura.fillAmount < 0.3f)
        {
            levelAudio.NotificarCambioAudio(30);
        }
        if (barraLocura.fillAmount > 0.3f && barraLocura.fillAmount < 0.4f)
        {
            levelAudio.NotificarCambioAudio(40);
        }
        if (barraLocura.fillAmount > 0.55f && barraLocura.fillAmount < 0.75f)
        {
            levelAudio.NotificarCambioAudio(60);
        }
        if (barraLocura.fillAmount > 0.75f)
        {
            levelAudio.NotificarCambioAudio(75);
        }           
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
        levelAudio.NotificarCambioAudio(20);
        levelAudio.NotificarEstadoJuego("JuegoEnCurso");
        Time.timeScale = 1f;
    }
    private void CondicionDeVictoria()
    {
        if (barraLocura.fillAmount >= 1)
        {
            victoryPanel.SetActive(true);
            levelAudio.DetenerAmbience();
            levelAudio.NotificarCambioAudio(100);
            levelAudio.NotificarEstadoJuego("Ganar");
            Invoke(nameof(VicDefeatWait), 3f);
        }
    }
    public void CondicionDeDerrota()
    {
        if (barraLocura.fillAmount <= 0)
        {
            SetDerrrotaPanel();
        }
    }

    public void SetDerrrotaPanel()
    {
        defeatPanel.SetActive(true);
        Invoke(nameof(VicDefeatWait), 3f);
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

    private void VicDefeatWait() 
    {
        Time.timeScale = 0f;
    }
}
