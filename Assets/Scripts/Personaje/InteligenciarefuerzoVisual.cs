using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteligenciarefuerzoVisual : MonoBehaviour
{
    private Animator animText;
    public int textID;

    private void Start()
    {
        animText = GetComponent<Animator>();
    }
    private void Update()
    {
        if (textID == 1 && Input.GetKeyDown(KeyCode.W))
        {
            animText.SetTrigger("MasLocura");
        }
        if (textID == 2 && Input.GetKeyDown(KeyCode.S))
        {
            animText.SetTrigger("MasLocura");
        }
        if (textID == 3 && Input.GetKeyDown(KeyCode.X))
        {
            animText.SetTrigger("MasLocura");
        }
        if (textID == 4 && Input.GetKeyDown(KeyCode.R))
        {
            animText.SetTrigger("MasLocura");
        }
    }
}
