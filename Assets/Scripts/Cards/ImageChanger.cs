using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image imageComponent; // El componente Image del prefab
    public Sprite image1; // La primera imagen
    public Sprite image2; // La segunda imagen

    void Awake()
    {
        if (GameContStat.modoDeJuego == 1)
            imageComponent.sprite = image2;
        else
            imageComponent.sprite = image1;
    }
}
