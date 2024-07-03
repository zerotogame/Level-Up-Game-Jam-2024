using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanceBuilding : MonoBehaviour
{
      public Building prefab; // El prefab que quieres instanciar
      public int numberOfPrefabs = 3; // Número de prefabs a instanciar
      public RectTransform area; // El RectTransform que define el área
      public List<Building> buildings = new List<Building>(); // Lista de edificios

      void Start()
      {
          area = GetComponent<RectTransform>();

          for (int i = 0; i < numberOfPrefabs; i++)
          {
              InstantiatePrefabInArea();
          }
      }

      void InstantiatePrefabInArea()
      {
          Vector3 randomPosition = GetRandomPositionInArea();
          Building prefab = GetRandomBuilding();
          Building instance = Instantiate(prefab, area);
          instance.GetComponent<RectTransform>().anchoredPosition = randomPosition;
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
     Metodo que en el array selecciona un building aleatorio
     */

        public Building GetRandomBuilding()
        {
            int randomIndex = Random.Range(0, buildings.Count);
            return buildings[randomIndex];
        }
}