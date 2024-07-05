using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkManager : MonoBehaviour
{
    public GameObject spritePrefab; // Prefab del sprite
    public int numberOfSprites = 10; // Número de sprites a generar
    public Vector2 areaCenter = Vector2.zero; // Centro del área de generación
    public Vector2 areaSize = new Vector2(10f, 10f); // Tamaño del área de generación
    public float moveSpeed = 2f; // Velocidad de movimiento del sprite

    void Start()
    {
        for (int i = 0; i < numberOfSprites; i++)
        {
            SpawnRandomSprite();
        }
    }

    void SpawnRandomSprite()
    {
        // Generar una posición aleatoria dentro del área de generación
        float randomX = Random.Range(areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2);
        float randomY = Random.Range(areaCenter.y - areaSize.y / 2, areaCenter.y + areaSize.y / 2);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Crear el sprite y asignar su posición inicial
        GameObject newSprite = Instantiate(spritePrefab, randomPosition, Quaternion.identity);

        // Configurar el script RandomWalk en el sprite
        Personaje randomWalk = newSprite.GetComponent<Personaje>();
        if (randomWalk != null)
        {
            randomWalk.moveSpeed = moveSpeed;
            randomWalk.Initialize(areaCenter, areaSize);
        }
    }
}
