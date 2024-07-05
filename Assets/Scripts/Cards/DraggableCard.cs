using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    public bool isDraggable = true; // Flag para verificar si la carta es draggable
    [SerializeField]
    public RectTransform rectTransform;
    [SerializeField]
    public Canvas canvas;
    [SerializeField]
    public Card card; // Referencia al objeto Card que esta DraggableCard representa
    [SerializeField]
    public Building currentBuilding; // Para mantener el Building actual

    private Vector2 originalPosition; // Para guardar la posición original de la carta


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        card = GetComponent<Card>(); // Asegúrate de tener una referencia al componente Card
        originalPosition = rectTransform.anchoredPosition; // Guardar la posición original al inicio
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
            SetDraggable(false); // Hacer que la carta no sea arrastrable
            CenterAndResizeCard(currentBuilding); // Centrar y reducir la carta
        } else{
           // Si no hay Building válido, volver a la posición original
           rectTransform.anchoredPosition = originalPosition;
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

            //Generate new Card in after point
            

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

    // Método para centrar la carta en el Building y reducir su tamaño a la mitad
    private void CenterAndResizeCard(Building building)
    {
        // Centrar la carta en el Building
        transform.SetParent(building.transform);
        rectTransform.anchoredPosition = Vector2.zero;

        // Reducir el tamaño de la carta a la mitad
        rectTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
