using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_scriptbox_hide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    private bool Acitve_hover = false;

    float script_hide_time_now;
    private float Time_limit_hide;
    private bool status_UI_script_hideauto;
    public GameObject Scriptbox;
    private bool Isanime = false;

    void Start()
    {
        status_UI_script_hideauto = false;

        Time_limit_hide = 0f;
        script_hide_time_now = Time_limit_hide;
    }
    void Update()
    {
        if (status_UI_script_hideauto == true)
        {
            script_hide_time_now -= Time.deltaTime;
            if (script_hide_time_now < 0)
            {
                Scriptbox.GetComponent<Animation>().Play("Scriptbox_hide_off");
                status_UI_script_hideauto = false;
                Isanime = false;
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Acitve_hover)
        {
            //script_hide_time_now = Time_limit_hide;
            if (Isanime == true)
            {
                status_UI_script_hideauto = true;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Acitve_hover)
        {
            if (Isanime == false)
            {
                Scriptbox.GetComponent<Animation>().Play("Scriptbox_hide_on");
                Isanime = true;
            }
        }
    }

    public void Set_hover_on()
    {
        Acitve_hover = true;
    }
    public void Set_hover_off()
    {
        Acitve_hover = false;
        
    }
    public void Fix_aniation()
    {
        Scriptbox.GetComponent<Animation>().Play("Scriptbox_hide_off");
    }
}
