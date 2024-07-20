using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DlobleClick : MonoBehaviour
{
    public GameObject objectToActivate; // El objeto que quieres activar
    public float doubleClickTime = 0.3f; // Tiempo máximo entre clicks para considerarlo un doble click

    private float lastClickTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime)
            {
                ActivateObject();
            }

            lastClickTime = Time.time;
        }
    }

    void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
