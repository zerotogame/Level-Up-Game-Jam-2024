using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBuilding : MonoBehaviour
{
    public List<Building> buildings; // Lista de edificios
    public RectTransform area; // El RectTransform que define el área

    [Header("Número minimo de edificios")]
    [SerializeField] private int minBuildings = 3;
    // Número máximo de edificios
    //Se indica de forma automatica dependiendo del numero de puntos de anclaje que tenga el objeto
   [SerializeField] private int maxBuildings = 3;

    void Start()
    {
        // Verificar que hay al menos 3 prefabs en la lista de edificios
        if (buildings.Count < 3)
        {
            Debug.LogError("Debes asignar al menos 3 prefabs en la lista 'buildings'.");
            return;
        }

        area = GetComponent<RectTransform>();
        maxBuildings = area.childCount;

        // Obtener los puntos de anclaje (hijos del objeto actual)
        List<Transform> anchorPoints = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
         string tagName = transform.GetChild(i).tag;

         if (tagName == "PointReferenceBuilding"){
            anchorPoints.Add(transform.GetChild(i));
         }
        }

        // Determinar aleatoriamente el número de edificios a generar
        int numBuildings = Random.Range(minBuildings, Mathf.Min(maxBuildings + 1, anchorPoints.Count + 1));

        // Instanciar edificios en los puntos de anclaje seleccionados aleatoriamente
        for (int i = 0; i < numBuildings; i++)
        {
            // Seleccionar un punto de anclaje aleatorio
            int randomIndex = Random.Range(0, anchorPoints.Count);
            Transform anchor = anchorPoints[randomIndex];

            // Instanciar un edificio aleatorio como hijo del punto de anclaje
            Building randomBuilding = GetRandomBuilding();
            Building instance = Instantiate(randomBuilding, anchor.position, anchor.rotation, anchor);

            // Eliminar el punto de anclaje de la lista para no reutilizarlo
            anchorPoints.RemoveAt(randomIndex);
        }

        // Eliminar los puntos de anclaje no utilizados
        foreach (Transform unusedAnchor in anchorPoints)
        {
            Destroy(unusedAnchor.gameObject);
        }
    }

    // Método para obtener un edificio aleatorio de la lista de edificios
    public Building GetRandomBuilding()
    {
        int randomIndex = Random.Range(0, buildings.Count);
        return buildings[randomIndex];
    }
}
