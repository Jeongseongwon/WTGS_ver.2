using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_manager : MonoBehaviour
{

    private AudioSource Hover;
    private AudioSource Click;
    private AudioSource BGM;

    private GameObject Scenecontroller;
    //private AudioSource Hover;


    private void OnLevelWasLoaded(int level)
    {
        Scenecontroller = GameObject.FindGameObjectWithTag("Scene_controller");
        Debug.Log("씬 전환시 호출 확인");
    }
    private void Start()
    {
        
    }
    public void Set_all_sound_volume(float volume)
    {
        Hover.volume = volume;
        Click.volume = volume;
        BGM.volume = volume;
    }

    public void Set_effect_sound_volume(float volume)
    {
        Hover.volume = volume;
        Click.volume = volume;
    }

    public void Set_narration_volume(float volume)
    {
        Scenecontroller.GetComponent<AudioSource>().volume = volume;
    }
}
