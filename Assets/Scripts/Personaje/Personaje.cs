using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del sprite
    private Vector2 targetPosition;
    private Vector2 areaCenter;
    private Vector2 areaSize;
    public int personajeID;

    public void Initialize(Vector2 center, Vector2 size)
    {
        areaCenter = center;
        areaSize = size;
        SetNewRandomTargetPosition();
    }

    void Update()
    {
        PresonajesEleccion();

        MoveTowardsTargetPosition();
        if (ReachedTargetPosition())
        {
            SetNewRandomTargetPosition();
        }
    }

    private void PresonajesEleccion() 
    {
        if (personajeID == 1)
            moveSpeed = GameContStat.velocidadPersonajesLoki;
        else if (personajeID == 2)
            moveSpeed = GameContStat.velocidadPersonajesEris;
        else if (personajeID == 3)
            moveSpeed = GameContStat.velocidadPersonajesVeles;
        else if (personajeID == 4)
            moveSpeed = GameContStat.velocidadPersonajesCthulhu;
    }


    void SetNewRandomTargetPosition()
    {
        // Define una nueva posición aleatoria dentro del área
        float randomX = Random.Range(areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2);
        float randomY = Random.Range(areaCenter.y - areaSize.y / 2, areaCenter.y + areaSize.y / 2);
        targetPosition = new Vector2(randomX, randomY);
    }

    void MoveTowardsTargetPosition()
    {
        // Mueve el sprite hacia la posición objetivo
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    bool ReachedTargetPosition()
    {
        // Comprueba si el sprite ha alcanzado la posición objetivo
        return Vector2.Distance(transform.position, targetPosition) < 0.1f;
    }
}
