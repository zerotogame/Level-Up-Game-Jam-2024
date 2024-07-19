using UnityEngine;
using TMPro;
using System.Collections;

public class TypeWriteEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float typingSpeed = 0.05f;

    public GameObject ContBttn;

    private string fullText;
    private string currentText = "";

    void OnEnable()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        fullText = textMeshPro.text;
        textMeshPro.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        ContBttn.SetActive(true);
    }
}
