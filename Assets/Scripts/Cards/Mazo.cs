using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Mazo : MonoBehaviour
{
    [Header("Paths de las cartas")]
    [SerializeField] private string velesPath = "Prefabs/Cards/Veles_Card";
    [SerializeField] private string lokiPath = "Prefabs/Cards/Loki_Card";
    [SerializeField] private string cthuluPath = "Prefabs/Cards/Cthulu_Card";
    [SerializeField] private string erisPath = "Prefabs/Cards/Eris_Card";

    public int totalCartasDioses = 2;

    public GameObject nextCardPrefab; // Referencia al prefab de la próxima carta

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

        // Instanciar cartas
        InstanciarCartasEnContenedor(velesCartas, totalCartasDioses);
        InstanciarCartasEnContenedor(lokiCartas, totalCartasDioses);
        InstanciarCartasEnContenedor(cthuluCartas, totalCartasDioses);
        InstanciarCartasEnContenedor(erisCartas, totalCartasDioses);
    }

    //Comprobar si algun contenedor hijo ha perdido sus hijos

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
            // Asegurar que no exceda el número de cartas disponibles
            if (cartas.Count == 0)
            {
                Debug.LogWarning("Se acabaron las cartas disponibles.");
                break;
            }

            // Obtener la carta correspondiente según el índice actual
            GameObject cartaPrefab = cartas[0];

            // Instanciar la carta en el contenedor actual
            Instantiate(cartaPrefab, containers[currentContainerIndex]);

            // Eliminar el prefab de la lista para evitar duplicados y avanzar al siguiente contenedor
            cartas.RemoveAt(0);
            currentContainerIndex = (currentContainerIndex + 1) % containers.Length; // Avanzar circularmente
        }
    }


        void CheckIfContainerLosesChildren()
        {
            // Obtener todos los contenedores "container_card" bajo Mazo
            Transform[] containers = transform.GetComponentsInChildren<Transform>()
                                      .Where(t => t.name == "container_card").ToArray();

            // Verificar si algún contenedor ha perdido sus hijos
            foreach (Transform container in containers)
            {
                if (container.childCount == 0)
                {

                    if (nextCardPrefab == null)
                    {
                        Debug.LogWarning("No existe carta en el manager");
                        return;
                    }

                    // Elegir una nueva carta aleatoria y eliminarla de la lista
                    nextCardPrefab = allCards[Random.Range(0, allCards.Count)];
                    allCards.Remove(nextCardPrefab);

                    // Instanciar una nueva carta en el contenedor
                    Instantiate(nextCardPrefab, container);
                    Debug.Log("El contenedor ahora está vacío.");
                    // Aquí puedes ejecutar cualquier otra acción que necesites cuando el contenedor pierde sus hijos
                }
            }
        }


}
