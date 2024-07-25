using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutInGame : MonoBehaviour
{
    public GameObject[] objetos;
    public GameObject sigBttn, jugarBttn, tutPanel;
    private int indiceActual = 0;
    private int contador;

    void Start()
    {
        if (GameContStat.isTutorialOn)
        {
            tutPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            tutPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        //Time.timeScale = 0f;
        ActualizarObjetos();
    }

    public void Siguiente()
    {
        indiceActual = (indiceActual + 1) % objetos.Length;
        ActualizarObjetos();
    }

    public void Anterior()
    {
        indiceActual = (indiceActual - 1 + objetos.Length) % objetos.Length;
        ActualizarObjetos();
    }

    public void JugarTutBttn() 
    {
        tutPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void ActualizarObjetos()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(i == indiceActual);
            contador = i;
        }
        if (indiceActual == 4)
        {
            sigBttn.SetActive(false);
            jugarBttn.SetActive(true);
        }
        else
        {
            sigBttn.SetActive(true);
            jugarBttn.SetActive(false);
        }
        //Debug.Log(indiceActual);
    }
}
