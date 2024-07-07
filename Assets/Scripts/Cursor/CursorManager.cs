using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D normalCursor; // Cursor normal
    public Texture2D handCursor;   // Cursor de mano en puño
    public Texture2D hoverCursor;  // Cursor cuando pasa por encima del objeto

    private static CursorManager instance;
    private bool isHovering = false;

    public static CursorManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CursorManager>();
                if (instance == null)
                {
                    Debug.LogError("No instance of CursorManager found in the scene.");
                }
            }
            return instance;
        }
    }

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
        if (Input.GetMouseButtonDown(0))
        {
            SetHandCursor();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isHovering)
            {
                SetHoverCursor();
            }
            else
            {
                SetNormalCursor();
            }
        }
    }

    public void SetNormalCursor()
    {
        isHovering = false;
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetHoverCursor()
    {
        isHovering = true;
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetHandCursor()
    {
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
    }

}
