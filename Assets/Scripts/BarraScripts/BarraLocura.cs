using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraLocura : MonoBehaviour
{
    void Update()
    {
        PresionarTeclas();
    }

    void PresionarTeclas()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameContStat.velocidadPersonajes += 2f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameContStat.velocidadPersonajes -= 2f;
        }
    }
}
