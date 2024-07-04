using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Mazo : MonoBehaviour
{

    private static string cardPath = "Assets/Resources/Prefab/Cards/";
    public string velvetPath = cardPath+"Velvet_Card";
    public string lokiPath = cardPath+"Loki_Card";
    public string cthuluPath = cardPath+"Cuthulu_Card";
    public string erisPath = cardPath+"Eris_Card";

    private List<GameObject> velvetCartas = new List<GameObject>();
    private List<GameObject> lokiCartas = new List<GameObject>();
    private List<GameObject> cthuluCartas = new List<GameObject>();
    private List<GameObject> erisCartas = new List<GameObject>();

    void Start()
    {
        // Cargar prefabs desde las carpetas
        velvetCartas = LoadPrefabsFromFolder(velvetPath);
        lokiCartas = LoadPrefabsFromFolder(lokiPath);
        cthuluCartas = LoadPrefabsFromFolder(cthuluPath);
        erisCartas = LoadPrefabsFromFolder(erisPath);

        // Instanciar cartas
        InstanciarCartas(velvetCartas, 2);
        InstanciarCartas(lokiCartas, 2);
        InstanciarCartas(cthuluCartas, 2);
        InstanciarCartas(erisCartas, 2);
    }

    List<GameObject> LoadPrefabsFromFolder(string path)
    {
        return Resources.LoadAll<GameObject>(path).ToList();
    }

    void InstanciarCartas(List<GameObject> cartas, int cantidad)
    {
        //DEBUG.Log("Instanciando cartas total cartas " + cartas.Count + " cantidad " + cantidad);
        for (int i = 0; i < cantidad; i++)
        {
            if (cartas.Count == 0) break;

            int randomIndex = Random.Range(0, cartas.Count);
            GameObject cartaPrefab = cartas[randomIndex];
            Instantiate(cartaPrefab, transform);
        }
    }
}
