using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del sprite
    public Vector2 areaSize = new Vector2(10f, 10f); // Tamaño del área en la que se moverá el sprite

    private Vector2 targetPosition;

    void Start()
    {
        SetNewRandomTargetPosition();
    }

    void Update()
    {
        if (GameContStat.velocidadPersonajes >= 2f)
            moveSpeed = GameContStat.velocidadPersonajes;
        else
            moveSpeed = 2f;


        MoveTowardsTargetPosition();
        if (ReachedTargetPosition())
        {
            SetNewRandomTargetPosition();
        }
    }

    void SetNewRandomTargetPosition()
    {
        float randomX = Random.Range(-areaSize.x / 2, areaSize.x / 2);
        float randomY = Random.Range(-areaSize.y / 2, areaSize.y / 2);
        targetPosition = new Vector2(randomX, randomY);
    }

    void MoveTowardsTargetPosition()
    {
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    bool ReachedTargetPosition()
    {
        return Vector2.Distance(transform.position, targetPosition) < 0.1f;
    }
}
