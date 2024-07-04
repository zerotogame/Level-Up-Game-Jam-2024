using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{
   [SerializeField] private string cardName;
   [SerializeField] private string cardDescription;
   //[SerializeField] private Sprite cardImage;
   [SerializeField] private int cardCost;

    public bool checkboxVelvet;
    public bool checkboxLoki;
    public bool checkboxCuthulu;
    public bool checkboxEris;

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

/*
    public Sprite CardImage
    {
        get { return cardImage; }
        set { cardImage = value; }
    }
*/

    public void Play()
    {
        Debug.Log("Card Played: " + cardName);
    }

    private void SetTypeGod(){
         // Capturar el tag del objeto
                string objectTag = gameObject.tag;

                // Usar un switch para setear el checkbox correspondiente
                switch (objectTag)
                {
                    case "Velvet_Card":
                        checkboxVelvet = true;
                        break;
                    case "Loki_Card":
                        checkboxLoki = true;
                        break;
                    case "Cuthulu_Card":
                        checkboxCuthulu = true;
                        break;
                    case "Eris_Card":
                        checkboxEris = true;
                        break;
                    default:
                        Debug.LogWarning("Tag no reconocido: " + objectTag);
                        break;
                }
    }

}
