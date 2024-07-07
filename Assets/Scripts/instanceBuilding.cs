using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstanceBuilding : MonoBehaviour
{
    public List<Building> buildings; // Lista de edificios
    public RectTransform area; // El RectTransform que define el área
    private BarraLocura barraLocura;

    [Header("Número minimo de edificios")]
    public int minBuildings = 3;
    // Número máximo de edificios
    //Se indica de forma automatica dependiendo del numero de puntos de anclaje que tenga el objeto
    public int maxBuildings = 3;

   string areaName;

    void Start()
    {
        // Verificar que hay al menos 3 prefabs en la lista de edificios
        if (buildings.Count < 3)
        {
            Debug.LogError("Debes asignar al menos 3 prefabs en la lista 'buildings'.");
            return;
        }

        area = GetComponent<RectTransform>();
        areaName = area.name;
        Debug.Log("Area name: " + areaName);

        maxBuildings = area.childCount;

        // Obtener los puntos de anclaje (hijos del objeto actual)
        List<Transform> anchorPoints = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            string tagName = transform.GetChild(i).tag;
            if (tagName == "PointReferenceBuilding"){
               anchorPoints.Add(transform.GetChild(i));
            }

        }

        // Determinar aleatoriamente el número de edificios a generar
        int numBuildings = Random.Range(minBuildings, Mathf.Min(maxBuildings + 1, anchorPoints.Count + 1));
        Debug.Log("numBuildings: " + numBuildings);
        // Instanciar edificios en los puntos de anclaje seleccionados aleatoriamente
        for (int i = 0; i < numBuildings; i++)
        {
            // Seleccionar un punto de anclaje aleatorio
            int randomIndex = Random.Range(0, anchorPoints.Count);
            Transform anchor = anchorPoints[randomIndex];

            // Instanciar un edificio aleatorio como hijo del punto de anclaje
            Building randomBuilding = GetRandomBuilding();
            if(randomBuilding._type == BuildingType.Casa){
                selectSpriteCasa(areaName,randomBuilding);

            }


            Building instance = Instantiate(randomBuilding, anchor.position, anchor.rotation, anchor);


            // Eliminar el punto de anclaje de la lista para no reutilizarlo
            anchorPoints.RemoveAt(randomIndex);
        }

        // Eliminar los puntos de anclaje no utilizados
        foreach (Transform unusedAnchor in anchorPoints)
        {
            Destroy(unusedAnchor.gameObject);
        }
    }

    void Update()
    {
        // Aquí puedes realizar cualquier acción adicional necesaria al limpiar el prefab de la carta
        bool isAllPointsHavenCard= allPointsHaveCard();
        Debug.Log("isAllPointsHavenCard: "+isAllPointsHavenCard);

        if(isAllPointsHavenCard){
            barraLocura = GameObject.Find("BarraLocuraImg").GetComponent<BarraLocura>();
            barraLocura.CondicionDeDerrota();
        }
    }

    // Método para obtener un edificio aleatorio de la lista de edificios
    public Building GetRandomBuilding()
    {
        int randomIndex = Random.Range(0, buildings.Count);
        return buildings[randomIndex];
    }


    //Dependiendo del nombre del area se selecciona el sprite correspondiente
    private void selectSpriteCasa(string areaName,Building instance) {
        switch (areaName){
            case "Area-Loki":
                Sprite spriteLoki = Resources.Load<Sprite>("Img/Sprites/Building/Casas/casa_loki");
                instance.GetComponent<Image>().sprite = spriteLoki;

            break;
            case"Area-Cuthulu":
                Sprite spriteCut = Resources.Load<Sprite>("Img/Sprites/Building/Casas/casa_cthulu");
                instance.GetComponent<Image>().sprite  = spriteCut;
            break;
            case"Area-Veles":
                Sprite spriteVeles = Resources.Load<Sprite>("Img/Sprites/Building/Casas/casa_veles");
                instance.GetComponent<Image>().sprite  = spriteVeles;
            break;
            case"Area-Eris":
                Sprite spriteEris = Resources.Load<Sprite>("Img/Sprites/Building/Casas/casa_eris");
                instance.GetComponent<Image>().sprite  = spriteEris;
            break;
            default:
            break;
        }

    }

    private bool allPointsHaveCard(){
        int totalChilds = transform.childCount;
        Debug.Log("totalChilds: " + totalChilds);
        for (int i = 0; i < totalChilds; i++)
        {
            Card card = transform.GetChild(i).GetComponent<Card>();
            Debug.Log("card " + card);
            if(card == null){
                return false;
            }

        }
        return true;
    }
}
