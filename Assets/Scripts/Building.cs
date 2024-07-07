using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BuildingType
{
    Iglesia,
    Hospital,
    Casa
}
public class Building : MonoBehaviour
{
    private string _objectID;
    public BuildingType _type;
    public Card cardPrefab; // Referencia al prefab de la carta

    void Start()
    {
        generateId();
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
}
