using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChtulu : MonoBehaviour
{
    private Animator animText;
    public int textID;

    private void Start()
    {
        animText = GetComponent<Animator>();
    }
    private void Update()
    {
        if (textID == 1 && Input.GetKeyDown(KeyCode.Q))
        {
            animText.SetTrigger("MasLocura");
        }
        if (textID == 2 && Input.GetKeyDown(KeyCode.A))
        {
            animText.SetTrigger("MasLocura");
        }
        if (textID == 3 && Input.GetKeyDown(KeyCode.Z))
        {
            animText.SetTrigger("MasLocura");
        }
        if (textID == 4 && Input.GetKeyDown(KeyCode.E)) 
        {
            animText.SetTrigger("MasLocura");
        }
    }
}
