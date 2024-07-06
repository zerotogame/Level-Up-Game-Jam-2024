using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChtulu : MonoBehaviour
{
    private Animator animLocura;
    public int textID;

    private void Start()
    {
        animLocura = GetComponent<Animator>();
    }
    private void Update()
    {
        if (textID == 1 && Input.GetKeyDown(KeyCode.Q))
        {
            animLocura.SetTrigger("MasLocura");
        }
        if (textID == 2 && Input.GetKeyDown(KeyCode.A))
        {
            animLocura.SetTrigger("MasLocura");
        }
        if (textID == 3 && Input.GetKeyDown(KeyCode.Z))
        {
            animLocura.SetTrigger("MasLocura");
        }
        if (textID == 4 && Input.GetKeyDown(KeyCode.E)) 
        {
            animLocura.SetTrigger("MasLocura");
        }
    }
}
