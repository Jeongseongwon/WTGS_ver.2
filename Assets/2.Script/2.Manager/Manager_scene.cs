using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
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
    
    public bool IsFullScreen = true;
    public float Fullscreen_value = 1f;

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

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt)&& Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("전체화면");
            FullScreen();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("창화면");
            WindowScreen();
        }
    }
    public void FullScreen()
    {
        IsFullScreen = true;
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Fullscreen_value = 1f;
    }
    public void WindowScreen()
    {
        IsFullScreen = false;
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Fullscreen_value = 0f;
    }
    public void Paused_on()
    {
        Time.timeScale = 0f;
        Debug.Log("PAUSED");
    }
    public void Paused_off()
    {
        Time.timeScale = 1f;
    }
   
   
    public bool Status_Check_script_hide()
    {
        return Check_script_hide;
    }

    public bool Status_Check_script_auto_over()
    {
        return Check_script_auto_over;
    }

    //public void Enabled_ui_button()
    //{
    //    GameObject[] UI_buttons;

    //    UI_buttons = GameObject.FindGameObjectsWithTag("UI_button");
    //    for (int i = 0; i < UI_buttons.Length; i++)
    //    {
    //        UI_buttons[i].GetComponent<Button>().enabled = true;
    //        //UI_buttons[i].GetComponent<EventTrigger>().enabled = true;
    //    }
    //}

    //public void Disabled_ui_button()
    //{
    //    GameObject[] UI_buttons;

    //    UI_buttons = GameObject.FindGameObjectsWithTag("UI_button");
    //    for (int i = 0; i < UI_buttons.Length; i++)
    //    {
    //        UI_buttons[i].GetComponent<Button>().enabled = false;

    //        UI_buttons[i].GetComponent<EventTrigger>().enabled = false;
    //        UI_buttons[i].SetActive(false);
    //        UI_buttons[i].SetActive(true);
    //    }
    //}
}
