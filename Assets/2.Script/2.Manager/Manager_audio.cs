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
    private AudioSource Intro;

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
        Scenecontroller = GameObject.FindGameObjectWithTag("Scene_controller");
        Hover = this.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        Click = this.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        BGM = this.transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        Narration = Scenecontroller.GetComponent<AudioSource>();
        Intro = this.transform.GetChild(3).gameObject.GetComponent<AudioSource>();
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

    private void OnLevelWasLoaded(int level)
    {
        Scenecontroller = GameObject.FindGameObjectWithTag("Scene_controller");
        Narration = Scenecontroller.GetComponent<AudioSource>();
        Hover = this.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        Click = this.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        BGM = this.transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        Intro = this.transform.GetChild(3).gameObject.GetComponent<AudioSource>();
        Debug.Log("씬 전환시 호출 확인");
    }
    public void Set_all_sound_volume(float volume)
    {
        Debug.Log("Slider_all");
        Hover.volume = volume;
        Click.volume = volume;
        BGM.volume = volume;
        Narration.volume = volume;
        Intro.volume = volume;
    }

    public void Set_effect_sound_volume(float volume)
    {
        Debug.Log("Slider_eff");
        Hover.volume = volume;
        Click.volume = volume;
        Intro.volume = volume;
    }

    public void Set_narration_volume(float volume)
    {
        Debug.Log("Slider_nar");
        Narration.volume = volume;
    }
    public void Set_BGM_volume(float volume)
    {
        BGM.volume = volume;
    }

}
