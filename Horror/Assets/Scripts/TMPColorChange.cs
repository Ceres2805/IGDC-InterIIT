using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TMPColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text buttonText;  // Assign your TMP text component here
    public Color normalColor = Color.white;
    public Color hoverColor = Color.green;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor;
    }
}
