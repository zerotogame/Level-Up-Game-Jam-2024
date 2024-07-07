using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkManager : MonoBehaviour
{
    public GameObject spritePrefab; // Prefab del sprite
    public int numberOfSprites = 10; // N�mero de sprites a generar
    public Vector2 areaCenter = Vector2.zero; // Centro del �rea de generaci�n
    public Vector2 areaSize = new Vector2(10f, 10f); // Tama�o del �rea de generaci�n
    public float moveSpeed = 2f; // Velocidad de movimiento del sprite

    void Awake()
    {
        for (int i = 0; i < numberOfSprites; i++)
        {
            SpawnRandomSprite();
        }
    }

    void SpawnRandomSprite()
    {
        // Generar una posici�n aleatoria dentro del �rea de generaci�n
        float randomX = Random.Range(areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2);
        float randomY = Random.Range(areaCenter.y - areaSize.y / 2, areaCenter.y + areaSize.y / 2);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Crear el sprite y asignar su posici�n inicial
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
