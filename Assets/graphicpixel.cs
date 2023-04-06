using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class graphicpixel : MonoBehaviour
{
    public GameObject Dial;
    private Slider Screen_slider;

    private float tmp_value;
    private float value;
    private bool IsFullScreen;
    // Start is called before the first frame update

    void Start()
    {
           value = Manager_scene.instance.Fullscreen_value;
           this.gameObject.GetComponent<Slider>().value = value;
           Screen_slider = this.gameObject.GetComponent<Slider>();
    }
    void Update()
    {
        IsFullScreen = Manager_scene.instance.IsFullScreen;
        value = this.gameObject.GetComponent<Slider>().value;
        if (tmp_value != value)
        {
            if (value == 0)
            {
                IsFullScreen = false;
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Manager_scene.instance.Fullscreen_value = value;
                Manager_scene.instance.IsFullScreen = IsFullScreen;
                //Screen.SetResolution(1920, 1080, screenmode);
            }
            else if (value == 1)
            {
                IsFullScreen = true;
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                Manager_scene.instance.Fullscreen_value = value;
                Manager_scene.instance.IsFullScreen = IsFullScreen; 
            }
        }
        tmp_value = value;
    }

    public void stat1()
    {
        Dial.transform.rotation = Quaternion.Euler(0, 0, -70);
        Screen.SetResolution(1280, 720, IsFullScreen);
    }
    public void stat2()
    {
        Dial.transform.rotation = Quaternion.Euler(0, 0, -180);
        Screen.SetResolution(1280, 1024, IsFullScreen);
    }
    public void stat3()
    {
        Dial.transform.rotation = Quaternion.Euler(0, 0, 0);
        Screen.SetResolution(1920, 1080, IsFullScreen);
    }
    public void stat4()
    {
        Dial.transform.rotation = Quaternion.Euler(0, 0, -250);
        Screen.SetResolution(2560, 1440, IsFullScreen);
    }
   
}
