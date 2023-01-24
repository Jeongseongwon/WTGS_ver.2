using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_intro_controller : MonoBehaviour
{
    //intro Gameobject
    [Header("===== Gameobject =====")]
    public GameObject Camera_1;
    public GameObject Camera_2;
    public GameObject Windturbine;
    public GameObject Loading;      //로딩화면
    public GameObject Button_skip;

    //intro image, text
    [Header("===== Image, Text =====")]
    public Text text_Loading;
    public GameObject Windturbine_text;
    public GameObject Monitoring_room_text;

    //public Image image_fill;
    private float time_loading = 3;
    private float time_current;
    private float time_start;
    private bool isEnded = true;

    // Start is called before the first frame update
    void Start()
    {
        Reset_Loading();
    }

    void Update()
    {
        if (isEnded)
            return;
        Check_Loading();
    }

    private void Check_Loading()
    {
        time_current = Time.time - time_start;
        if (time_current < time_loading)
        {
            Set_FillAmount(time_current / time_loading);
        }
        else if (!isEnded)
        {
            End_Loading();
        }
    }

    private void End_Loading()
    {
        Set_FillAmount(1);
        isEnded = true;
        Loading.SetActive(false);
        StartCoroutine(Camera_animation());
        
        Debug.Log("END");
    }

    private void Reset_Loading()
    {
        time_current = time_loading;
        time_start = Time.time;
        Set_FillAmount(0);
        isEnded = false;
    }
    private void Set_FillAmount(float _value)
    {
        //image_fill.fillAmount = _value;
        string txt = ((_value)).ToString("P0");
        text_Loading.text = txt;
        Debug.Log(txt);
    }

    public void Change_scene()
    {
        SceneManager.LoadSceneAsync("(dev)_Main");    //화면 접고 애니메이션 재생
    }

    IEnumerator Camera_animation()
    {
        Button_skip.SetActive(true);
        Windturbine_text.SetActive(true);
        Camera_1.GetComponent<Animation>().Play("Camera_move(intro)");
        yield return new WaitForSeconds(9.0f);
        Camera_1.SetActive(false);
        Windturbine_text.SetActive(false);

        //페이드인 효과
        Camera_2.SetActive(true);
        Monitoring_room_text.SetActive(true);
        Camera_2.GetComponent<Animation>().Play("Camera_move(intro_2)");
        yield return new WaitForSeconds(11.0f);
        Change_scene();
        //끝나면 신 전환

        yield break;
    }
}
