using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UI_button_menu : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Text texthover;
    [TextArea]
    public string textthis;
    void Start()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        texthover.GetComponent<Text>().text = " ";
        //«ÿ¥Á æ¿ »£√‚
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exxit");
        texthover.text = "";
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
        texthover.text = textthis;

    }
}
