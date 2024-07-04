using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLocura : MonoBehaviour
{

    public Image barraLocura;

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
