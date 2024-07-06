using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Mazo : MonoBehaviour
{
    [Header("Paths de las cartas")]
    [SerializeField] private string velesPath = "Prefabs/Cards/Veles_Card";
    [SerializeField] private string lokiPath = "Prefabs/Cards/Loki_Card";
    [SerializeField] private string cthuluPath = "Prefabs/Cards/Cthulu_Card";
    [SerializeField] private string erisPath = "Prefabs/Cards/Eris_Card";

    public int totalCartasDioses = 2;

    public GameObject nextCardPrefab; // Referencia al prefab de la próxima carta
    public GameObject containerNextCard; // Referencia al contenedor de la próxima carta

    private List<GameObject> velesCartas = new List<GameObject>();
    private List<GameObject> lokiCartas = new List<GameObject>();
    private List<GameObject> cthuluCartas = new List<GameObject>();
    private List<GameObject> erisCartas = new List<GameObject>();
    private List<GameObject> allCards = new List<GameObject>();

    private int currentContainerIndex = 0; // Índice para seguir el orden de los contenedores

    void Start()
    {
        // Cargar prefabs desde las carpetas
        velesCartas = LoadPrefabsFromFolder(velesPath);
        lokiCartas = LoadPrefabsFromFolder(lokiPath);
        cthuluCartas = LoadPrefabsFromFolder(cthuluPath);
        erisCartas = LoadPrefabsFromFolder(erisPath);

        allCards.AddRange(velesCartas);
        allCards.AddRange(lokiCartas);
        allCards.AddRange(cthuluCartas);
        allCards.AddRange(erisCartas);

        allCards = allCards.OrderBy(x => Random.value).ToList();
        nextCardPrefab = allCards[Random.Range(0, allCards.Count)];
        containerNextCard.GetComponent<Image>().sprite = nextCardPrefab.GetComponent<Card>().SpriteDorsal;

        // Instanciar cartas
        InstanciarCartasEnContenedor(velesCartas, totalCartasDioses);
        InstanciarCartasEnContenedor(lokiCartas, totalCartasDioses);
        InstanciarCartasEnContenedor(cthuluCartas, totalCartasDioses);
        InstanciarCartasEnContenedor(erisCartas, totalCartasDioses);
    }

    void Update()
    {
        // Verificar dinámicamente si el contenedor ha perdido sus hijos
        CheckIfContainerLosesChildren();
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

    void InstanciarCartasEnContenedor(List<GameObject> cartas, int cantidad)
    {
        if (cartas.Count < cantidad)
        {
            Debug.LogError($"No hay suficientes cartas para instanciar {cantidad} cartas.");
            return;
        }
        cartas = cartas.OrderBy(x => Random.value).ToList();

        // Obtener todos los contenedores "container_card" bajo Mazo
        Transform[] containers = transform.GetComponentsInChildren<Transform>()
                                  .Where(t => t.name == "container_card").ToArray();

        if (containers.Length == 0)
        {
            Debug.LogError("No se encontraron contenedores 'container_card' bajo Mazo.");
            return;
        }

        // Instanciar una carta en cada contenedor en orden
        for (int i = 0; i < Mathf.Min(containers.Length, cantidad); i++)
        {
            if (cartas.Count == 0)
            {
                Debug.LogWarning("Se acabaron las cartas disponibles.");
                break;
            }

            GameObject cartaPrefab = cartas[0];
            Instantiate(cartaPrefab, containers[currentContainerIndex]);

            cartas.RemoveAt(0);
            currentContainerIndex = (currentContainerIndex + 1) % containers.Length;
        }
    }

    void CheckIfContainerLosesChildren()
    {
        Transform[] containers = transform.GetComponentsInChildren<Transform>()
                                      .Where(t => t.name == "container_card").ToArray();

        foreach (Transform container in containers)
        {
            if (container.childCount == 0)
            {
                if (nextCardPrefab == null)
                {
                    Debug.LogWarning("No existe carta en el manager");
                    return;
                }

                nextCardPrefab = allCards[Random.Range(0, allCards.Count)];

                containerNextCard.GetComponent<Image>().sprite = nextCardPrefab.GetComponent<Card>().SpriteDorsal;

                Instantiate(nextCardPrefab, container);
                Debug.Log("El contenedor ahora está vacío.");
            }
        }
    }
}
