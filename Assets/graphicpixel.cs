using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class graphicpixel : MonoBehaviour
{
    FullScreenMode screenmode;
    public GameObject[] quality;
    bool windowstate = false;
    private Slider Screen_slider;


    private float tmp_value;
    private float value;
    // Start is called before the first frame update

    void Start()
    {
        Screen_slider = this.gameObject.GetComponent<Slider>();
        Screen_slider.value = Manager_scene.instance.Get_Check_fullscreen();
    }
    void Update()
    {
        value = Screen_slider.value;
        if (tmp_value != value)
        {
            if (value == 0)
            {
                screenmode = FullScreenMode.Windowed;
                Screen.SetResolution(1920, 1080, screenmode);

                windowstate = true;
                Debug.Log("window");

            }else if (value == 1)
            {

                screenmode = FullScreenMode.FullScreenWindow;
                windowstate = false;
                Debug.Log("full");
            }
            Manager_scene.instance.Set_Check_fullscreen(Screen_slider.value);
        }
        tmp_value = value;
    }

    public void stat1()
    {
        Screen.SetResolution(1280, 720, screenmode);

    }
    public void stat2()
    {
        Screen.SetResolution(1280, 1024, screenmode);

    }
    public void stat3()
    {
        Screen.SetResolution(1920, 1080, screenmode);

    }
    public void stat4()
    {
        Screen.SetResolution(2560, 1440, screenmode);

    }
   
    public void full()
    {
        screenmode = FullScreenMode.FullScreenWindow;
    }
}
