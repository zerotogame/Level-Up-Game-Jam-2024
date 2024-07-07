using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum BuildingType
{
    Iglesia,
    Hospital,
    Casa,
    Comercio,
    Fabrica
}

public class Building : MonoBehaviour
{
    private string _objectID;
    public BuildingType _type;
    public Card cardPrefab; // Referencia al prefab de la carta
    public Sprite sprite; // Referencia al sprite del edificio

    void Start()
    {
        Debug.Log("Building script started.");
        Debug.Log("Object ID: " + _objectID);
        Debug.Log("Type: " + _type.ToString());
        generateId();
        setSprite();
    }

    public Building(string objectID, BuildingType type)
    {
        _objectID = objectID;
        _type = type;
    }

    public string objectID
    {
        get { return _objectID; }
        set { _objectID = value; }
    }

    public BuildingType type
    {
        get { return _type; }
        set { _type = value; }
    }

    public void SetCardPrefab(Card card)
    {
        cardPrefab = card;
        Debug.Log("Card Prefab set to: " + (cardPrefab != null ? cardPrefab.name : "null"));
        // Aquí puedes realizar cualquier acción adicional necesaria al establecer el prefab de la carta
    }

    public void ClearCardPrefab()
    {
        cardPrefab = null;
        Debug.Log("Card Prefab cleared.");
        // Aquí puedes realizar cualquier acción adicional necesaria al limpiar el prefab de la carta
    }

    void generateId()
    {
        _objectID = System.Guid.NewGuid().ToString();
    }

    void setSprite()
    {
        Sprite[] sprites = getRandomSprite();
        Debug.Log("Setting sprite..." + _type.ToString());
        Debug.Log("Sprites: " + (sprites != null ? sprites.Length.ToString() : "null"));

        if (sprites != null)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            Debug.Log("Random index: " + randomIndex);
            //sprite = sprites[randomIndex];
            GetComponent<Image>().sprite = sprites[randomIndex];
        }
    }

    void getSprite()
    {
        Debug.Log("Getting sprite...");
        if (sprite != null)
        {
            Debug.Log("Sprite: " + sprite.name);
        }
        else
        {
            Debug.LogError("Sprite is null.");
        }
    }

    Sprite[] getRandomSprite()
    {
        switch (_type)
        {
            case BuildingType.Iglesia:
                return Resources.LoadAll<Sprite>("Img/Sprites/Building/Sprite_Iglesia");
            case BuildingType.Hospital:
                return Resources.LoadAll<Sprite>("Img/Sprites/Building/Sprite_Hospital");
            case BuildingType.Comercio:
                return Resources.LoadAll<Sprite>("Img/Sprites/Building/Sprite_Comercio");
            case BuildingType.Fabrica:
                return Resources.LoadAll<Sprite>("Img/Sprites/Building/Sprite_Fabrica");
            case BuildingType.Casa:
                return null;
                break;
            default:
            Debug.LogError("No se encontraron sprites para el tipo de edificio: " + _type.ToString());
                return null;
        }
    }



}
