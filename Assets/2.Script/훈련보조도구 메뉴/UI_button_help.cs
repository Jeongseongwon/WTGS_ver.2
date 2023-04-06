using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_button_help : MonoBehaviour, IPointerClickHandler
{

    private string Object_name;

    public Text texthover;

    public GameObject getscript;
    private int num=0;
    void Start()
    {
        Object_name = this.gameObject.name;
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        num = getscript.GetComponent<Help_page>().Get_num();
        
        if (Object_name == "prev_btn")
        {
            if (num > 0)
            {
                getscript.GetComponent<Help_page>().Red_num();
            }
        }
        else if (Object_name == "next_btn")
        {
            if (num < 3)
            {
                getscript.GetComponent<Help_page>().Add_num();
            }
        }
    }

}
