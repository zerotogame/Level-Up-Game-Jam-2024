using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private bool isDraggable = true; // Flag para verificar si la carta es draggable
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Card card; // Referencia al objeto Card que esta DraggableCard representa
    [SerializeField]
    private Building currentBuilding; // Para mantener el Building actual
    private Vector2 originalPosition; // Para guardar la posición original de la carta
    FMOD.Studio.EventInstance agarrarCartas;

    FMOD.Studio.EventInstance sonidoCartaCthulhu;
    FMOD.Studio.EventInstance sonidoCartaLuki;
    FMOD.Studio.EventInstance sonidoCartaEris;
    FMOD.Studio.EventInstance sonidoCartaVeles;

    public BarraLocura barraLocura;
    public NotificationEffect notificationEffect;

    [SerializeField] private float valorIncremento= 0.05f;

    // Valores de decremento
    private float valor1 = 0.05f, valor2 = 0.03f, valor3 = 0.025f, valor4 = 0.02f;

    private void Start()
    {
        // Checa modo de juego
        CheckModo();

        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        card = GetComponent<Card>(); // Asegúrate de tener una referencia al componente Card
        originalPosition = rectTransform.anchoredPosition; // Guardar la posición original al inicio
        barraLocura = FindObjectOfType<BarraLocura>();
        notificationEffect=  GameObject.FindGameObjectWithTag("NotificationEffect").GetComponent<NotificationEffect>();
        agarrarCartas = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/AgarrarCarta");

        sonidoCartaCthulhu = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SoltarCarta_Cthulhu");
        sonidoCartaLuki = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SoltarCarta_Loki");
        sonidoCartaEris = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SoltarCarta_Eris");
        sonidoCartaVeles = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SoltarCarta_Veles");
    }
    void CheckModo() // Modo de Juego
    {
        if (GameContStat.modoDeJuego == 1) // Facil
        {
            valorIncremento = 0.1f;
            valor1 = 0; 
            valor2 = 0;
            valor3 = 0;
            valor4 = 0;
        }
        if (GameContStat.modoDeJuego == 2) // Normal
        {
            valorIncremento = 0.075f;
            valor1 = 0.025f;
            valor2 = 0.025f;
            valor3 = 0.025f;
            valor4 = 0.025f;
        }
        if (GameContStat.modoDeJuego == 3) // Dificil
        {
            valorIncremento = 0.05f;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Verificar si la carta es draggable
        if (!isDraggable)
            return;

        // Permitir que la carta sea arrastrada
        rectTransform.SetAsLastSibling();
        agarrarCartas.start();
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
        if (currentBuilding != null && currentBuilding.cardPrefab == null)
        {
            currentBuilding.SetCardPrefab(card);
            SetDraggable(false); // Hacer que la carta no sea arrastrable
            CenterAndResizeCard(currentBuilding); // Centrar y reducir la carta
            CheckArea(card);
            card.GetComponent<InfoCard2>().enabled = true; // Deshabilitar el componente Card
            string tagArea = card.gameObject.transform.parent.parent.parent.tag;
            SonidoDioses(card, tagArea);
        }
        else
        {
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

    /**
    * Aumentar la locura de la barra de locura
    * Condiciones: - Todoso los dioses aumentan en 0.25
    */
    private void IncreaseLocura(Card card)
    {
        notificationEffect.MostrarMensaje(TypeEffect.Locura,"Aumento de locura +" + valorIncremento*100);
        switch (card.godType)
        {
            case GodType.Veles:
                barraLocura.VelesMasLocura(valorIncremento);
                break;
            case GodType.Loki:
                barraLocura.LokiMasLocura(valorIncremento);
                break;
            case GodType.Cthulhu:
                barraLocura.CuMasLocura(valorIncremento);
                break;
            case GodType.Eris:
                barraLocura.ErisMasLocura(valorIncremento);
                break;
            default:
                break;
        }
    }

    /**
    * Aumentar la locua de la barra de locura
    * Condiciones: - Si dios es Loki y se pone en area Eris decrementa en 0.25
    *              - Si dios es Loki y se pone en area Veles decrementa en 0.15
    *              - Si dios es Loki y se pone en area Cthulu decrementa en 0.10
    *
    *              - Si dios es Eris y se pone en area Loki decrementa en 0.10
    *              - Si dios es Eris y se pone en area Veles decrementa en 0.25
    *              - Si dios es Eris y se pone en area Cthulu decrementa en 0.15
    *
    *              - Si dios es Veles y se pone en area Loki decrementa en 0.15
    *              - Si dios es Veles y se pone en area Eris decrementa en 0.10
    *              - Si dios es Veles y se pone en area Cthulu decrementa en 0.25
    *
    *              - Si dios es Cthulu y se pone en area Loki decrementa en 0.25
    *              - Si dios es Cthulu y se pone en area Eris decrementa en 0.15
    *              - Si dios es Cthulu y se pone en area Veles decrementa en 0.10
    */
    private void DecreaseLocura(Card card, string tagArea)
    {
        float decrement = 0f;

        Debug.Log("Tag Area: " + tagArea);
        Debug.Log("Card GodType: " + card.godType);
        switch (card.godType)
        {
            case GodType.Loki:
                if (tagArea.Contains("Eris"))
                {
                    decrement = valor1;
                }
                else if (tagArea.Contains("Veles"))
                {
                    decrement = valor2;
                }
                else if (tagArea.Contains("Cthulhu"))
                {
                    decrement = valor4;
                }
                break;

            case GodType.Eris:
                if (tagArea.Contains("Loki"))
                {
                    decrement = valor4;
                }
                else if (tagArea.Contains("Veles"))
                {
                    decrement = valor1;
                }
                else if (tagArea.Contains("Cthulhu"))
                {
                    decrement = valor2;
                }
                break;

            case GodType.Veles:
                if (tagArea.Contains("Loki"))
                {
                    decrement = valor1;
                }
                else if (tagArea.Contains("Eris"))
                {
                    decrement = valor3;
                }
                else if (tagArea.Contains("Cthulhu"))
                {
                    decrement = valor1;
                }
                break;

            case GodType.Cthulhu:
                if (tagArea.Contains("Loki"))
                {
                    decrement = valor1;
                }
                else if (tagArea.Contains("Eris"))
                {
                    decrement = valor3;
                }
                else if (tagArea.Contains("Veles"))
                {
                    decrement = valor1;
                }
                break;

            default:
                Debug.LogError("No se ha encontrado el tipo de dios");
                break;
        }

        if (decrement > 0)
        {
            notificationEffect.MostrarMensaje(TypeEffect.Inteligencia,"Aumento de la Inteligencia +" + decrement*100);
            barraLocura.DecreaseLocura(decrement, card.godType);
        }
    }
    private void SonidoDioses(Card card, string tagArea)
    {   
        switch (card.godType)
        {
            case GodType.Veles:
                if(tagArea.Contains("Veles"))
                {
                    sonidoCartaVeles.start();
                }                
                break;
            case GodType.Loki:
                if (tagArea.Contains("Loki"))
                {
                    sonidoCartaLuki.start();
                }                
                break;
            case GodType.Cthulhu:
                if (tagArea.Contains("Loki"))
                {
                    sonidoCartaCthulhu.start();
                }                
                break;
            case GodType.Eris:
                if (tagArea.Contains("Eris"))
                {
                    sonidoCartaEris.start();
                }
                break;
            default:
                break;
        }
    }
}
