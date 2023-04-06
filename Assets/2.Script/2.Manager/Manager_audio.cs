using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_audio : MonoBehaviour
{
    public static Manager_audio instance = null;
    private AudioSource Hover;
    private AudioSource Click;
    private AudioSource BGM;
    private AudioSource Narration;
    public AudioSource Narration_End;
    private AudioSource Intro;
    public AudioSource Error;
    private AudioSource Correct_answer;
    private AudioSource strong_wind;
    private AudioSource low_wind;
    private AudioSource Wrong_answer;

    private GameObject Scenecontroller;
    // Start is called before the first frame update
    // 각 볼륨 값 정의하고
    // 팝업이 열릴 때 마다 한 번 값을 가져와서 슬라이더를 조절해준다

    //각 사운드의 볼륨을 일괄적으로 지정해주고 그것에 맞춰서 될지 한 번 확인해보자


    private float All_volume = 1f;
    private float Effect_volume = 0.5f;
    private float Narr_volume = 0.5f;
    private float BGM_volume = 0.1f;

    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    void Start()
    {
        Init_sound();
    }

    public float Get_all_volume()
    {
        return All_volume;
    }
    public float Get_Effect_volume()
    {
        return Effect_volume;
    }
    public float Get_Narr_volume()
    {
        return Narr_volume;
    }
    public float Get_BGM_volume()
    {
        return BGM_volume;
    }

    public void Get_hover()
    {
        Hover.Play();
        //Debug.Log("hover");
    }

    public void Get_click()
    {
        Click.Play();
        //Debug.Log("click");
    }

    public void Get_intro()
    {
        Intro.Play();
        //Debug.Log("click");
    }
    public void Get_bgm()
    {
        BGM.Play();
        //Debug.Log("click");
    }
    public void Get_Narration_end()
    {
        Narration_End.Play();
        //Debug.Log("click");
    }

    public void Get_Error()
    {
        Error.Play();
        //Debug.Log("click");
    }

    public void Get_Correct_answer()
    {
        Correct_answer.Play();
        //Debug.Log("click");
    }

    public void Get_Wrong_answer()
    {
        Wrong_answer.Play();
        //Debug.Log("click");
    }
    public void Get_Strong_wind()
    {
        strong_wind.Play();
        //Debug.Log("click");
    }
    public void Get_Low_wind()
    {
        low_wind.Play();
        //Debug.Log("click");
    }
    public void Stop_Strong_wind()
    {
        strong_wind.Stop();
        //Debug.Log("click");
    }
    public void Stop_Low_wind()
    {
        low_wind.Stop();
        //Debug.Log("click");
    }
    private void OnLevelWasLoaded(int level)
    {
        Init_sound();
    }
    private void Init_sound()
    {
        if (GameObject.FindGameObjectWithTag("Scene_controller") != null)
        {
            Scenecontroller = GameObject.FindGameObjectWithTag("Scene_controller");
            Narration = Scenecontroller.GetComponent<AudioSource>();
        }

        Hover = this.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        Click = this.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        BGM = this.transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        Intro = this.transform.GetChild(3).gameObject.GetComponent<AudioSource>();

        Narration_End = this.transform.GetChild(5).gameObject.GetComponent<AudioSource>();
        Error = this.transform.GetChild(6).gameObject.GetComponent<AudioSource>();
        Correct_answer = this.transform.GetChild(7).gameObject.GetComponent<AudioSource>();
        strong_wind = this.transform.GetChild(8).gameObject.GetComponent<AudioSource>();
        low_wind = this.transform.GetChild(9).gameObject.GetComponent<AudioSource>();

        Wrong_answer = this.transform.GetChild(10).gameObject.GetComponent<AudioSource>();
        
        Set_effect_sound_volume(Effect_volume);
        Set_narration_volume(Narr_volume);

        Set_BGM_volume(BGM_volume);
    }
    public void Set_all_sound_volume(float volume)
    {
        if(volume == 0)
        {
            Hover.mute = true;
            Click.mute = true;
            BGM.mute = true;
            Intro.mute = true;
            Error.mute = true;
            Correct_answer.mute = true;
            Wrong_answer.mute = true;
            strong_wind.mute = true;
            low_wind.mute = true;
            Narration_End.mute = true;

            if (Scenecontroller != null)
            {
                Narration.mute = true;
            }
        }
        else if(volume == 1)
        {
            Hover.mute = false;
            Click.mute = false;
            BGM.mute = false;
            Intro.mute = false;
            Error.mute = false;
            Correct_answer.mute = false;
            Wrong_answer.mute = false;
            strong_wind.mute = false;
            low_wind.mute = false;
            Narration_End.mute = false;

            if (Scenecontroller != null)
            {
                Narration.mute = false;
            }
        }
    }

    public void Set_effect_sound_volume(float volume)
    {
        Hover.volume = volume;
        Click.volume = volume;
        Intro.volume = volume;
        Intro.volume = volume;
        Error.volume = volume;
        Correct_answer.volume = volume;
        Wrong_answer.volume = volume;
        strong_wind.volume = volume;
        low_wind.volume = volume;
        Narration_End.volume = volume;
    }

    public void Set_narration_volume(float volume)
    {
        if (Scenecontroller != null)
        {
            Narration.volume = volume;
        }
    }
    public void Set_BGM_volume(float volume)
    {
        BGM.volume = volume;
    }

}
