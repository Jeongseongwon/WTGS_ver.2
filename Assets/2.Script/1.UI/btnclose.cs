using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class btnclose : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler

{
    bool menubar = false;
    public GameObject edpopup;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {

            if (menubar == false)
            {
                on();
            }
            else
            {
                off();
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
      
    }
    public void on()
    {
        edpopup.SetActive(true);
        menubar = true;

    }
    public void off()
    {
        edpopup.SetActive(false);
        menubar = false;

    }
}
