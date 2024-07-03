using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLocura : MonoBehaviour
{

    public Image barraLocura;
    void Update()
    {
        PresionarTeclas();
    }

    void PresionarTeclas()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            barraLocura.fillAmount += .1f;
            GameContStat.velocidadPersonajes += 2f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            barraLocura.fillAmount -= .1f;
            GameContStat.velocidadPersonajes -= 2f;
        }
    }
}
