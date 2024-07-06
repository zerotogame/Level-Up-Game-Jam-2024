using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GodType
{
    Veles,
    Loki,
    Cthulhu,
    Eris
}
public class Card : MonoBehaviour
{
   [SerializeField] private string cardName;
   [SerializeField] private string cardDescription;
   [SerializeField] private float locura =0f;
   [SerializeField] private float inteligencia =0f;
    public GodType godType;

    void Start()
    {
        SetTypeGod();
    }

    public string CardName
    {
        get { return cardName; }
        set { cardName = value; }
    }

    public string CardDescription
    {
        get { return cardDescription; }
        set { cardDescription = value; }
    }

    public float Locura
    {
        get { return locura; }
        set { locura = value; }
    }

    public float Inteligencia
    {
        get { return inteligencia; }
        set { inteligencia = value; }
    }

    public void Play()
    {
        Debug.Log("Card Played: " + cardName);
    }

    private void SetTypeGod()
    {
        switch (gameObject.tag)
        {
            case "Veles_Card":
                godType = GodType.Veles;
                break;
            case "Loki_Card":
                godType = GodType.Loki;
                break;
            case "Cthulu_Card":
                godType = GodType.Cthulhu;
                break;
            case "Eris_Card":
                godType = GodType.Eris;
                break;
        }
    }

}
