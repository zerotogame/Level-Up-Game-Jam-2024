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

    public BarraLocura barraLocura;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        card = GetComponent<Card>(); // Asegúrate de tener una referencia al componente Card
        originalPosition = rectTransform.anchoredPosition; // Guardar la posición original al inicio
        barraLocura = FindObjectOfType<BarraLocura>();

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
            CheckArea(card);
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


       // Método para verificar el área cuando se instancia una carta
        public void CheckArea(Card card)
        {

            string tagArea = card.gameObject.transform.parent.parent.parent.tag;
            Debug.Log("Tag Area: " + card.godType.ToString() + " " + tagArea);
            bool isArea = tagArea.Contains(card.godType.ToString());
            Debug.Log("Is Area: " + isArea);
            if (isArea)
            {
                IncreaseLocura(card);
                Debug.Log("Aumenta locura");
            }
            else
            {
                DecreaseLocura(card, tagArea);
                Debug.Log("Disminuye locura");
            }

        }

       private void IncreaseLocura(Card card)
       {
          switch (card.godType)
          {
              case GodType.Veles:
                  barraLocura.VelesMasLocura();
                  break;
              case GodType.Loki:
                  barraLocura.LokiMasLocura();
                  break;
              case GodType.Cthulhu:
                  barraLocura.CuMasLocura();
                  break;
              case GodType.Eris:
                  barraLocura.ErisMasLocura();
                  break;
              default:
                  break;
          }
       }

       /**
        * Aumentar la locua de la barra de locura
        *Condiciones:   -Si dios es Loki y se pone en area Eris decrementa en 0.25
                        -Si dios es Loki y se pone en area Veles decrementa en 0.15
                        -Si dios es Loki y se pone en area Cthulu decrementa en 0.10

                        -Si dios es Eris y se pone en area Loki decrementa en 0.10
                        -Si dios es Eris y se pone en area Veles decrementa en 0.25
                        -Si dios es Eris y se pone en area Cthulu decrementa en 0.15

                        -Si dios es Veles y se pone en area Loki decrementa en 0.15
                        -Si dios es Veles y se pone en area Eris decrementa en 0.10
                        -Si dios es Veles y se pone en area Cthulu decrementa en 0.25

                        -Si dios es Cthulu y se pone en area Loki decrementa en 0.25
                        -Si dios es Cthulu y se pone en area Eris decrementa en 0.15
                        -Si dios es Cthulu y se pone en area Veles decrementa en 0.10

        */

       private void DecreaseLocura(Card card, string tagArea)
           {
               float decrement = 0f;

               switch (card.godType)
               {
                   case GodType.Loki:
                       if (tagArea == "Eris")
                       {
                           decrement = 0.25f;
                       }
                       else if (tagArea == "Veles")
                       {
                           decrement = 0.15f;
                       }
                       else if (tagArea == "Cthulhu")
                       {
                           decrement = 0.10f;
                       }
                       break;

                   case GodType.Eris:
                       if (tagArea == "Loki")
                       {
                           decrement = 0.10f;
                       }
                       else if (tagArea == "Veles")
                       {
                           decrement = 0.25f;
                       }
                       else if (tagArea == "Cthulhu")
                       {
                           decrement = 0.15f;
                       }
                       break;

                   case GodType.Veles:
                       if (tagArea == "Loki")
                       {
                           decrement = 0.15f;
                       }
                       else if (tagArea == "Eris")
                       {
                           decrement = 0.10f;
                       }
                       else if (tagArea == "Cthulhu")
                       {
                           decrement = 0.25f;
                       }
                       break;

                   case GodType.Cthulhu:
                       if (tagArea == "Loki")
                       {
                           decrement = 0.25f;
                       }
                       else if (tagArea == "Eris")
                       {
                           decrement = 0.15f;
                       }
                       else if (tagArea == "Veles")
                       {
                           decrement = 0.10f;
                       }
                       break;
               }

               if (decrement > 0)
               {
                   barraLocura.DecreaseLocura(decrement, card.godType);
               }
           }

}
