using System.Collections;
using UnityEngine;
using TMPro;

public enum TypeEffect
{
    Locura,
    Inteligencia
}

public class NotificationEffect : MonoBehaviour
{
    public TextMeshProUGUI textPrefab; // Referencia al prefab de TextMeshPro en la UI
    public float tiempoVida = 3f; // Tiempo de vida del mensaje
    public float desplazamientoY = 30f; // Cantidad de desplazamiento en el eje Y
    public RectTransform canvasRectTransform; // Referencia al RectTransform del Canvas

    void Start()
    {
        // Obtener el RectTransform del Canvas
        canvasRectTransform = GetComponent<RectTransform>();

        textPrefab = this.GetComponent<TextMeshProUGUI>();
    }
    public void MostrarMensaje(TypeEffect tipo, string mensaje)
    {
        // Instanciar un nuevo TextMeshProUGUI
        TextMeshProUGUI nuevoTexto = Instantiate(textPrefab, canvasRectTransform);

        // Configurar el mensaje y el color
        switch (tipo)
        {
            case TypeEffect.Locura:
                nuevoTexto.color = Color.red;
                break;

            case TypeEffect.Inteligencia:
                nuevoTexto.color = Color.blue;
                break;

            default:
                nuevoTexto.color = Color.white;
                break;
        }

        nuevoTexto.text = mensaje;
        nuevoTexto.alpha = 1f; // Asegúrate de que el texto sea completamente opaco al inicio

        // Posicionar en una ubicación aleatoria dentro del Canvas
        Vector2 posicionAleatoria = ObtenerPosicionAleatoria();
        nuevoTexto.rectTransform.anchoredPosition = posicionAleatoria;

        // Iniciar la animación
        StartCoroutine(AnimarMensaje(nuevoTexto, tiempoVida, desplazamientoY));
    }

    Vector2 ObtenerPosicionAleatoria()
    {
        // Obtener los límites del Canvas
        float minX = -canvasRectTransform.rect.width / 2;
        float maxX = canvasRectTransform.rect.width / 2;
        float minY = -canvasRectTransform.rect.height / 2;
        float maxY = canvasRectTransform.rect.height / 2;

        // Calcular una posición aleatoria dentro de los límites
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    IEnumerator AnimarMensaje(TextMeshProUGUI texto, float duracion, float desplazamientoY)
    {
        Vector3 posicionInicial = texto.rectTransform.anchoredPosition;
        Vector3 posicionFinal = posicionInicial + new Vector3(0, desplazamientoY, 0);
        float tiempoTranscurrido = 0;

        while (tiempoTranscurrido < duracion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float porcentajeCompletado = tiempoTranscurrido / duracion;

            // Interpolación de la posición
            texto.rectTransform.anchoredPosition = Vector3.Lerp(posicionInicial, posicionFinal, porcentajeCompletado);

            // Interpolación de la transparencia
            texto.alpha = Mathf.Lerp(1, 0, porcentajeCompletado);

            yield return null;
        }

        // Destruir el objeto de texto después de la animación
        Destroy(texto.gameObject);
    }
}
