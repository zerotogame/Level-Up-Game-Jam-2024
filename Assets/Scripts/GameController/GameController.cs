using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public BarraLocura barraLocura;

    void Start()
    {
        barraLocura = this.GetComponent<BarraLocura>();
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
