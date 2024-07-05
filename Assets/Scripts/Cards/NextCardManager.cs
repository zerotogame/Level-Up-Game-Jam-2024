using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        List<GameObject> velesCard = LoadPrefabsFromFolder(velesPath);
        List<GameObject> lokiCard = LoadPrefabsFromFolder(lokiPath);
        List<GameObject> cthuluCard = LoadPrefabsFromFolder(cthuluPath);
        List<GameObject> erisCard = LoadPrefabsFromFolder(erisPath);

        cardPrefabs.AddRange(velesCard);
        cardPrefabs.AddRange(lokiCard);
        cardPrefabs.AddRange(cthuluCard);
        cardPrefabs.AddRange(erisCard);

        cardPrefabs = cardPrefabs.OrderBy(x => Random.value).ToList();

        // Verificar si los prefabs se cargaron correctamente

        Debug.Log("Cargando prefabs...");

        if (cardPrefabs.Count == 0)
        {
            Debug.LogError("No se encontraron cartas en las rutas especificadas.");
            return;
        }

        Debug.Log("Prefabs cargados correctamente. Total de cartas: " + cardPrefabs.Count);

    }

    List<GameObject> LoadPrefabsFromFolder(string path)
    {
        Object[] loadedObjects = Resources.LoadAll<GameObject>(path);
        List<GameObject> loadedPrefabs = new List<GameObject>();

        foreach (Object obj in loadedObjects)
        {
            if (obj is GameObject go)
            {
                if (go.GetComponent<Card>() != null)
                {
                    loadedPrefabs.Add(go);
                }
            }
        }

        if (loadedPrefabs.Count == 0)
        {
            Debug.LogError("No se encontraron prefabs en la ruta: " + path);
        }

        return loadedPrefabs;
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

        Debug.Log("Carta instanciada: " + currentCard.name);
    }


    public void NextCard()
    {
        // Destruir la carta actual
        Destroy(currentCard);

        // Escoger un índice aleatorio
        int randomIndex = Random.Range(0, cardPrefabs.Count);

        // Instanciar la carta aleatoria
        currentCard = Instantiate(cardPrefabs[randomIndex], transform.position, transform.rotation);

        Debug.Log("Carta instanciada: " + currentCard.name);
    }
    public GameObject GetCurrentCard()
    {
        return currentCard;
    }


}
