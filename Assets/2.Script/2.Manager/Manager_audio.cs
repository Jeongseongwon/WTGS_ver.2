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
        
    private GameObject Scenecontroller;
    // Start is called before the first frame update
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
        if (GameObject.FindGameObjectWithTag("Scene_controller")!=null)
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
        Debug.Log("씬 전환시 호출 확인");
    }
    public void Set_all_sound_volume(float volume)
    {
        Hover.volume = volume;
        Click.volume = volume;
        BGM.volume = volume;
        if (Scenecontroller != null)
        {
            Narration.volume = volume;
        }
        Intro.volume = volume;
        Error.volume = volume;
        Correct_answer.volume = volume;
        strong_wind.volume = volume;
        low_wind.volume = volume;
        Narration_End.volume = volume;
    }

    public void Set_effect_sound_volume(float volume)
    {
        Hover.volume = volume;
        Click.volume = volume;
        Intro.volume = volume;
        Intro.volume = volume;
        Error.volume = volume;
        Correct_answer.volume = volume;
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
