using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_script_hideauto : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public bool off;
    public GameObject panel;

    void Start()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (off == true)
            {
                panel.GetComponent<UI_scriptbox_hide>().Set_hover_on();
            }
            else if (off == false)
            {
                panel.GetComponent<UI_scriptbox_hide>().Set_hover_off();
                panel.GetComponent<UI_scriptbox_hide>().Fix_aniation();
            }

        }
    }

}
