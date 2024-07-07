using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class CursorPruebaCartas : MonoBehaviour
{
    private void OnMouseDown()
    {
        CursorManager.Instance.SetHandCursor();
    }
}
