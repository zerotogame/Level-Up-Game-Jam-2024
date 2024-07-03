using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBuilding : MonoBehaviour
{
    public List<Building> buildings; // Lista de edificios
    public RectTransform area; // El RectTransform que define el área

    void Start()
    {
        if (buildings.Count != 3)
        {
            Debug.LogError("Debes asignar exactamente 3 prefabs en la lista 'buildings'.");
            return;
        }

        area = GetComponent<RectTransform>();


        // Recorre cada hijo del objeto actual
        for (int i = 0; i < 3; i++)
        {
            Transform child = transform.GetChild(i);

            // Encuentra un prefab que no haya sido usado aún
            for (int j = 0; j < buildings.Count; j++)
            {
                    // Instancia el prefab en la posición y rotación del objeto hijo vacío
                                        Building randomBuilding = GetRandomBuilding();
                    Building instance = Instantiate(randomBuilding, child.position, child.rotation, area);

                    // Marca el prefab como usado


                    // Destruye el objeto hijo vacío original
                    Destroy(child.gameObject);

                    break;

            }
        }
    }

    Vector3 GetRandomPositionInArea()
    {
        // Obtener las dimensiones del RectTransform
        float width = area.rect.width;
        float height = area.rect.height;

        // Calcular una posición aleatoria dentro del RectTransform
        float randomX = Random.Range(-width / 2, width / 2);
        float randomY = Random.Range(-height / 2, height / 2);

        return new Vector3(randomX, randomY, 0);
    }

     /**
         * Método que en el array selecciona un building aleatorio
         */
        public Building GetRandomBuilding()
        {
            int randomIndex = Random.Range(0, buildings.Count);
            return buildings[randomIndex];
        }
}
