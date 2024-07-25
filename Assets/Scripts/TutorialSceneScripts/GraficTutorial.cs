using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraficTutorial : MonoBehaviour
{
    public GameObject tutPanel1, tutPanel2, tutPanel3, tutPanel4;

    public void Cont1Bttn() 
    {
        tutPanel1.SetActive(false);
        tutPanel2.SetActive(true);
    }
    public void Cont2Bttn()
    {
        tutPanel2.SetActive(false);
        tutPanel3.SetActive(true);
    }
    public void Cont3Bttn()
    {
        tutPanel3.SetActive(false);
        tutPanel4.SetActive(true);
    }
    public void Cont4Bttn()
    {
        SceneManager.LoadScene("Game");
        GameContStat.introPlayed = true;
    }
}
