using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Manager_scene : MonoBehaviour
{
    //
    //씬에서 씬 사이에서 유지되어야하는 변수
    //추후 기능이 많이 없을 경우 setting으로 합칠 것

    private float Check_fullscreen;
    private bool Check_script_hide;  //스크립트 하이드 했을 때 변수
    private bool Check_script_auto_over; //스크립트 자동진행 변수
    private bool Check_menu;


    public static Manager_scene instance = null;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            if (instance != this) 
                Destroy(this.gameObject); 
        }
    }

    void Start()
    {
        Check_script_auto_over = false;
        Check_fullscreen = 0f;
        Check_script_hide = false;
        Check_menu = false;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
    public float Get_Check_fullscreen()
    {
        Debug.Log(Check_fullscreen);
        return Check_fullscreen;
    }
    public void Set_Check_fullscreen(float num)
    {
        Check_fullscreen = num;
    }
    public void Change_check_menu_true()
    {
        Check_menu = true;
    }
    public void Change_check_menu_false()
    {
        Check_menu = false;
    }
    public bool Status_check_menu_false()
    {
        return Check_menu;
    }
    public void Chage_Check_script_hide_true()
    {
        Check_script_hide = true;
    }
    public void Chage_Check_script_hide_false()
    {
        Check_script_hide = false;
    }

    public void Chage_script_auto_over_true()
    {
        Check_script_auto_over = true;
    }
    public void Chage_script_auto_over_false()
    {
        Check_script_auto_over = false;
    }

    public bool Status_Check_script_hide()
    {
        return Check_script_hide;
    }

    public bool Status_Check_script_auto_over()
    {
        return Check_script_auto_over;
    }

    public void Enabled_ui_button()
    {
        GameObject[] UI_buttons;

        UI_buttons = GameObject.FindGameObjectsWithTag("UI_button");
        for (int i = 0; i < UI_buttons.Length; i++)
        {
            UI_buttons[i].GetComponent<Button>().enabled = true;
            //UI_buttons[i].GetComponent<EventTrigger>().enabled = true;
        }
    }

    public void Disabled_ui_button()
    {
        GameObject[] UI_buttons;

        UI_buttons = GameObject.FindGameObjectsWithTag("UI_button");
        for (int i = 0; i < UI_buttons.Length; i++)
        {
            UI_buttons[i].GetComponent<Button>().enabled = false;

            UI_buttons[i].GetComponent<EventTrigger>().enabled = false;
            UI_buttons[i].SetActive(false);
            UI_buttons[i].SetActive(true);
        }
    }
}
