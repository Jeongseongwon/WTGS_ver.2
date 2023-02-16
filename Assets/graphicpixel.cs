using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class graphicpixel : MonoBehaviour {
    FullScreenMode screenmode;
    public GameObject[] quality;
    bool windowstate = false;
    // Start is called before the first frame update
    public void stat1()
{
        Screen.SetResolution(1280, 720, screenmode);
        Debug.Log("1");

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
    public void window()
    {
        if(windowstate==false)
        {
            screenmode = FullScreenMode.Windowed;
            Screen.SetResolution(1920, 1080, screenmode);
            windowstate = true;
            Debug.Log("window");
        }
        else
        {
            screenmode = FullScreenMode.FullScreenWindow;
            windowstate = false;
            Debug.Log("full");
        }
      
    }
    public void full()
    {
        screenmode = FullScreenMode.FullScreenWindow;
    }
}
