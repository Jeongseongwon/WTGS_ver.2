using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Manager_scene : MonoBehaviour
{
    //
    //������ �� ���̿��� �����Ǿ���ϴ� ����
    //���� ����� ���� ���� ��� setting���� ��ĥ ��

    private float Check_fullscreen;
    private bool Check_script_hide;  //��ũ��Ʈ ���̵� ���� �� ����
    private bool Check_script_auto_over; //��ũ��Ʈ �ڵ����� ����
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
            Debug.Log("��üȭ��");
            FullScreen();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("âȭ��");
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
