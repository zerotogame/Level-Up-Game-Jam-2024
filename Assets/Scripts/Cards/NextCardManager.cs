using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCardManager : MonoBehaviour
{
    [Header("Total de cartas en la partida")]
    [SerializeField] private int totalCards = 32;

    [SerializeField] private string velesPath = "Prefabs/Cards/Veles_Card";
    [SerializeField] private string lokiPath = "Prefabs/Cards/Loki_Card";
    [SerializeField] private string cthuluPath = "Prefabs/Cards/Cthulu_Card";
    [SerializeField] private string erisPath = "Prefabs/Cards/Eris_Card";

    [SerializeField] private GameObject currentCard;

    private List<GameObject> cardPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar la lista de prefabs de cartas
        cardPrefabs = new List<GameObject>();

        // Cargar cada prefab de carta y añadirlo a la lista
        LoadCardPrefabs();

        // Inicializar una carta aleatoria
        InitializeRandomCard();
    }

    void LoadCardPrefabs()
    {
        // Cargar cada prefab y añadirlo a la lista de prefabs
        GameObject velesCard = Resources.Load<GameObject>(velesPath);
        GameObject lokiCard = Resources.Load<GameObject>(lokiPath);
        GameObject cthuluCard = Resources.Load<GameObject>(cthuluPath);
        GameObject erisCard = Resources.Load<GameObject>(erisPath);

        // Verificar si los prefabs se cargaron correctamente
        Debug.Log("Cargando prefabs...");
        if (velesCard != null) { cardPrefabs.Add(velesCard); Debug.Log("Veles_Card cargada correctamente."); }
        else Debug.LogError("Error al cargar Veles_Card.");

        if (lokiCard != null) { cardPrefabs.Add(lokiCard); Debug.Log("Loki_Card cargada correctamente."); }
        else Debug.LogError("Error al cargar Loki_Card.");

        if (cthuluCard != null) { cardPrefabs.Add(cthuluCard); Debug.Log("Cthulu_Card cargada correctamente."); }
        else Debug.LogError("Error al cargar Cthulu_Card.");

        if (erisCard != null) { cardPrefabs.Add(erisCard); Debug.Log("Eris_Card cargada correctamente."); }
        else Debug.LogError("Error al cargar Eris_Card.");
    }

    void InitializeRandomCard()
    {
        if (cardPrefabs.Count == 0)
        {
            Debug.LogError("No se encontraron cartas en las rutas especificadas.");
            return;
        }

        // Escoger un índice aleatorio
        int randomIndex = Random.Range(0, cardPrefabs.Count);

        // Instanciar la carta aleatoria
        currentCard = Instantiate(cardPrefabs[randomIndex], transform.position, transform.rotation);

        // Hacer que la carta instanciada sea hija del objeto vacío (opcional)
        currentCard.transform.parent = this.transform;

        Debug.Log("Carta instanciada: " + currentCard.name);
    }
}
