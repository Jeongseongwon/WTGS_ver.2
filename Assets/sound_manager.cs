using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_manager : MonoBehaviour
{

    public AudioSource[] music;

    public void SetMusicVolume(float volume)
    {
        music[0].volume = volume;
    }
    public void SEtNarationvolume(float volume)
    {
        music[1].volume = volume;
    }
}
