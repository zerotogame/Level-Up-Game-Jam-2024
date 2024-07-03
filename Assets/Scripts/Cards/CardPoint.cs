using UnityEngine;

public class CardPoint : MonoBehaviour
{
    [SerializeField]
    private Card cardPrefab; // Referencia al prefab de la carta

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
}
