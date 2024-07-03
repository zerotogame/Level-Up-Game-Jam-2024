using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private bool isDraggable = true; // Flag para verificar si la carta es draggable

    private RectTransform rectTransform;
    private Canvas canvas;

    private Card card; // Referencia al objeto Card que esta DraggableCard representa
    private Building currentBuilding; // Para mantener el Building actual

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        card = GetComponent<Card>(); // Asegúrate de tener una referencia al componente Card
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Verificar si la carta es draggable
        if (!isDraggable)
            return;

        // Permitir que la carta sea arrastrada
        rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Verificar si la carta es draggable
        if (!isDraggable)
            return;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out position);
        rectTransform.position = canvas.transform.TransformPoint(position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Verificar si la carta es draggable
        if (!isDraggable)
            return;

        // Si hay un Building válido debajo, establecer el CardPrefab
        if (currentBuilding != null)
        {
            currentBuilding.SetCardPrefab(card);
        }
    }

    // Método para cambiar el estado de draggable desde fuera del script
    public void SetDraggable(bool draggable)
    {
        isDraggable = draggable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto golpeado es un Building
        if (collision.gameObject.CompareTag("PointBuilding"))
        {
            currentBuilding = collision.gameObject.GetComponent<Building>();
            Debug.Log("Entered Building: " + collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar si el objeto saliente es un Building
        if (collision.gameObject.CompareTag("PointBuilding"))
        {
            if (currentBuilding == collision.gameObject.GetComponent<Building>())
            {
                currentBuilding = null;
                Debug.Log("Exited Building: " + collision.gameObject.name);
            }
        }
    }
}
