using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D normalCursor; // Cursor normal
    public Texture2D handCursor;   // Cursor de mano en puño

    private static CursorManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Cambiar el cursor cuando se presiona el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
        }

        // Restaurar el cursor cuando se suelta el botón izquierdo del mouse
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
        }
        
    }

}
