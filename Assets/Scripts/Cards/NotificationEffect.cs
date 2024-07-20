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
    public GameObject notificationPrefab; // Prefab que contiene TextMeshProUGUI y el script NotificationEffect
    public float tiempoVida = 3f; // Tiempo de vida del mensaje
    public float desplazamientoY = 30f; // Cantidad de desplazamiento en el eje Y
    public RectTransform canvasRectTransform; // Referencia al RectTransform del Canvas

    void Start()
    {
        // Obtener el RectTransform del Canvas
        if (canvasRectTransform == null)
        {
            canvasRectTransform = GetComponent<RectTransform>();
        }

        if (notificationPrefab == null)
        {
            Debug.LogError("El prefab de Notification no está asignado en Start.");
        }
    }

    public void MostrarMensaje(TypeEffect tipo, string mensaje)
    {
        if (notificationPrefab == null)
        {
            Debug.LogError("El prefab de Notification no está asignado en MostrarMensaje.");
            return;
        }

        // Crear un nuevo GameObject temporal para el mensaje
        GameObject nuevoObjeto = Instantiate(notificationPrefab, canvasRectTransform);
        TextMeshProUGUI nuevoTexto = nuevoObjeto.GetComponent<TextMeshProUGUI>();

        if (nuevoTexto == null)
        {
            Debug.LogError("El prefab de Notification no contiene un componente TextMeshProUGUI.");
            return;
        }

        // Configurar el mensaje y el color
        switch (tipo)
        {
            case TypeEffect.Locura:
                nuevoTexto.color = Color.cyan;
                break;
            case TypeEffect.Inteligencia:
                nuevoTexto.color = Color.green;
                break;
            default:
                nuevoTexto.color = Color.white;
                break;
        }

        nuevoTexto.text = mensaje;
        nuevoTexto.alpha = 1f; // Asegúrate de que el texto sea completamente opaco al inicio

        // Posicionar en una ubicación aleatoria dentro del Canvas
        //Vector2 posicionAleatoria = ObtenerPosicionAleatoria();
        nuevoTexto.rectTransform.anchoredPosition = Vector2.zero;

        // Iniciar la animación
        StartCoroutine(AnimarMensaje(nuevoObjeto, nuevoTexto, tiempoVida, desplazamientoY));
    }

    /*Vector2 ObtenerPosicionAleatoria()
    {
        // Obtener los límites del Canvas
        float minX = -canvasRectTransform.rect.width / 4;
        float maxX = canvasRectTransform.rect.width / 4;
        float minY = -canvasRectTransform.rect.height / 4;
        float maxY = canvasRectTransform.rect.height / 4;

        // Calcular una posición aleatoria dentro de los límites
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }*/

    IEnumerator AnimarMensaje(GameObject objeto, TextMeshProUGUI texto, float duracion, float desplazamientoY)
    {
        if (texto == null || objeto == null)
        {
            yield break;
        }

        Vector3 posicionInicial = texto.rectTransform.anchoredPosition;
        Vector3 posicionFinal = posicionInicial + new Vector3(0, desplazamientoY, 0);
        float tiempoTranscurrido = 0;

        while (tiempoTranscurrido < duracion)
        {
            if (texto == null || objeto == null)
            {
                yield break;
            }

            tiempoTranscurrido += Time.deltaTime;
            float porcentajeCompletado = tiempoTranscurrido / duracion;

            // Interpolación de la posición
            texto.rectTransform.anchoredPosition = Vector3.Lerp(posicionInicial, posicionFinal, porcentajeCompletado);

            // Interpolación de la transparencia
            texto.alpha = Mathf.Lerp(1, 0, porcentajeCompletado);

            yield return null;
        }

        if (objeto != null)
        {
            // Destruir el objeto temporal después de la animación
            Destroy(objeto);
        }
    }
}
