using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HighlightPlus;

public class Scene_1_2_controller : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Main_object;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Wind_particle;
    public ParticleSystem windspeed;

    public GameObject Study_title_Intro_2;

    private Text text;
    bool toggle = true;
    int nowCount;
    int postCount;
    bool Prev_Status = false;
    private int phase = 0;
    private bool Timer_check = false;

    private List<string> anim_list = new List<string>();
    // Start is called before the first frame update

    //2-1 Gameobject
    [Header("===== Gameobject =====")]
    private Animation Anim;
    public GameObject Object_1_blade1;
    public GameObject Object_1_blade2;
    public GameObject Object_1_blade3;
    public GameObject Object_4_Nacelle;
    public GameObject Object_5_Tower;
    public GameObject Object_6_Rotor;
    public GameObject Object_7_Shaft;
    public GameObject Object_8_Hub;
    public GameObject Object_9_Pitch_bearing;
    public GameObject Object_9_1_Pitch_sytem_1;
    public GameObject Object_9_1_Pitch_sytem_2;
    public GameObject Object_9_1_Pitch_sytem_3;
    public GameObject Object_10_Spinner;
    public GameObject Object_11_Mainshaft;
    public GameObject Object_12_Yaw;
    public GameObject Object_12_1_Yaw_system_1;
    public GameObject Object_12_1_Yaw_system_2;
    public GameObject Object_12_1_Yaw_system_3;
    public GameObject Object_12_1_Yaw_system_4;
    public GameObject Object_12_2_Yaw_bearing;
    public GameObject Object_12_3_Yaw_Gearing;
    public GameObject Object_12_4_Brake_disc;
    public GameObject Object_12_5_Brake_cal;
    public GameObject Object_12_6_Brake_cal_2;
    public GameObject Object_13_Gearbox;
    public GameObject Object_14_Generator;

    public GameObject Object_17_shaft_brake_disc;
    public GameObject Object_21_shaft_brake_pad;
    public GameObject Object_22_brake_shaft;



    public GameObject Arrow_a1;
    public GameObject Arrow_b1;
    public GameObject Arrow_c1;

    public GameObject Arrow_a2;
    public GameObject Arrow_b2;
    public GameObject Arrow_c2;

    public GameObject[] pitch;
    public AudioSource windsound;
    public Animation core_break;
    private int BtnCount;
    public GameObject[] turnoffthis;
    public GameObject newmodel;
    public GameObject[] higligt;

    IEnumerator Arrow_on_off(float time_1 = 0f, float time_2 = 4f)
    {
        var ps = windspeed.main;
        var emmisions = windspeed.emission;
        ps.simulationSpeed = 2f;
        emmisions.rateOverTime = 1f;
        yield return new WaitForSeconds(time_1);
        Arrow_a2.SetActive(true);
        Arrow_b2.SetActive(true);
        Arrow_c2.SetActive(true);
        yield return new WaitForSeconds(time_2);
        ps.simulationSpeed = 4f;
        emmisions.rateOverTime = 2f;
        Arrow_a2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_c2.SetActive(false);
        Arrow_a1.SetActive(true);
        Arrow_b1.SetActive(true);
        Arrow_c1.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        Arrow_a1.SetActive(false);
        Arrow_b1.SetActive(false);
        Arrow_c1.SetActive(false);
        ps.simulationSpeed = 2f;
        emmisions.rateOverTime = 1f;
        yield break;
    }
    IEnumerator Arrow_low(float time = 0f)
    {
        yield return new WaitForSeconds(time);
        Arrow_a1.SetActive(true);
        Arrow_b1.SetActive(true);
        Arrow_c1.SetActive(true);
    }

    IEnumerator Arrow_high(float time = 0f)
    {
        yield return new WaitForSeconds(time);
        Arrow_a2.SetActive(true);
        Arrow_b2.SetActive(true);
        Arrow_c2.SetActive(true);
    }

    void Arrow_off()
    {
        Arrow_a2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_c2.SetActive(false);
        Arrow_a1.SetActive(false);
        Arrow_b1.SetActive(false);
        Arrow_c1.SetActive(false);
    }

    void Start()
    {
        Anim = Main_object.GetComponent<Animation>();

        Camera.GetComponent<Camera_movement>().enabled = false;
        StartCoroutine(StartAct());
        Object_Col_Off_ALL();
        Manager_audio.instance.Get_intro();
    }
    IEnumerator StartAct()
    {
        yield return new WaitForSeconds(3.0f);
        Study_title_Intro_2.SetActive(true);
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(on)");
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        yield break;
    }
    void Act(int count)
    {
        Scriptbox.GetComponent<Animation>().Play("banner_o");
        var ps = windspeed.main;
        var emmisions = windspeed.emission;
        if (count == 1)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
                //카메라, 발전기 위치 재설정

            }
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_1_blade1);
            Object_Col_On(Object_1_blade2);
            Object_Col_On(Object_1_blade3);
            Object_Col_On(Object_4_Nacelle);
            Object_Col_On(Object_5_Tower);
            Object_Col_On(Object_6_Rotor);

            //애니메이션
            Camera.GetComponent<Camera_movement>().enabled = true;
            StartCoroutine(Animation_play(0));
            //Anim.Play("1_WTG_rotation");
            StartCoroutine(Animation_play(1));
            Wind_particle.SetActive(true);
            Debug.Log("act1");
        }
        else if (count == 3)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
                //Camera.GetComponent<Camera_movement>().act2();
            }
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_1_blade1);
            Object_Col_On(Object_1_blade2);
            Object_Col_On(Object_1_blade3);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_1_blade1));
            StartCoroutine(Highlight_onoff(Object_1_blade2));
            StartCoroutine(Highlight_onoff(Object_1_blade3));

            //애니메이션
            Wind_particle.SetActive(false);
            Camera.GetComponent<Camera_movement>().act1();
            Anim.Stop();
            //Anim.Play("2_WTG_blade_move");
            StartCoroutine(Animation_play(2));
            Debug.Log("act3");
        }
        else if (count == 4)
        {
            windsound.Play();
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }
            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_1_blade1));
            StartCoroutine(Highlight_onoff(Object_1_blade2));
            StartCoroutine(Highlight_onoff(Object_1_blade3));

            Wind_particle.SetActive(true);
            StartCoroutine(Arrow_on_off());
            //화살표 추가
            //애니메이션
            //Anim.Play("3_2_WTG_blade_pitch");
            StartCoroutine(Animation_play(3.2));
            Debug.Log("act4");
        }
        else if (count == 5)
        {
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_6_Rotor);

            Object_Highlight_Off_ALL();
            StopAllCoroutines();
            Arrow_off();

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_6_Rotor, 3f));

            //애니메이션
            Camera.GetComponent<Camera_movement>().act2();
            //Anim.Stop();
            StartCoroutine(Animation_play(2.1));    //재조립 및 회전
            Debug.Log("act5");
        }
        else if (count == 6)
        {
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Highlight_Off_ALL();
            Object_Col_On(Object_6_Rotor);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_6_Rotor, 1.5f));

            //애니메이션
            //Anim.Play("5_WTG_rotor_move");
           // StartCoroutine(Animation_play(5));

            Debug.Log("act6");
        }
        else if (count == 7)
        {

            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Highlight_Off_ALL();
            Object_Col_On(Object_6_Rotor);
            Object_Col_On(Object_8_Hub);
            Object_Col_On(Object_9_Pitch_bearing);
            Object_Col_On(Object_10_Spinner);
            Object_Col_On(Object_9_1_Pitch_sytem_1);
            Object_Col_On(Object_9_1_Pitch_sytem_2);
            Object_Col_On(Object_9_1_Pitch_sytem_3);

            //하이라이트 효과
            // StartCoroutine(Highlight_onoff(Object_6_Rotor,6f));
            StartCoroutine(Highlight_onoff(Object_8_Hub, 7f));
            StartCoroutine(Highlight_onoff(Object_9_Pitch_bearing, 9f));
            StartCoroutine(Highlight_onoff(Object_10_Spinner, 6f));
            StartCoroutine(Highlight_onoff(Object_9_1_Pitch_sytem_1, 9f));

            //애니메이션
            //Camera.GetComponent<Camera_movement>().act3();
            //Anim.Play("5_1_WTG_rotor_move(hub,spinner)");
            StartCoroutine(Animation_play(5.1));
            //StartCoroutine(Animation_play(1));
            //Anim.Play("1_WTG_rotation");
            Debug.Log("act7");
        }
        else if (count == 8)
        {


            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Highlight_Off_ALL();
            Object_Col_On(Object_8_Hub);
            Object_Col_On(Object_11_Mainshaft);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_8_Hub, 2f));
            //StartCoroutine(Highlight_onoff(Object_11_Mainshaft));

            //애니메이션
            Camera.GetComponent<Camera_movement>().act5();
            StartCoroutine(Animation_play(5.2));
            //주축 회전

            newmodel.GetComponent<Animation>().Play("NM_mainshaft_rotation");

            Debug.Log("act8");
        }
        else if (count == 9)
        {
            if (Prev_Status == true)
            {
                Arrow_off();
                Prev_Status = false;
            }
            newmodel.GetComponent<Animation>().Stop();

            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Highlight_Off_ALL();
            Object_Col_On(Object_9_1_Pitch_sytem_1);
            Object_Col_On(Object_9_Pitch_bearing);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_9_1_Pitch_sytem_1));
            StartCoroutine(Highlight_onoff(Object_9_Pitch_bearing));

            Camera.GetComponent<Camera_movement>().act4();
            StartCoroutine(Animation_play(7));
            Debug.Log("act9");
        }
        else if (count == 10)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }
        }
        else if (count == 11)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }

            //콜라이더(툴팁, 하이라이트)
            Camera.GetComponent<Camera_movement>().act1();
            StartCoroutine(Highlight_onoff(Object_1_blade1, 1f));
            StartCoroutine(Highlight_onoff(Object_1_blade2, 1f));
            StartCoroutine(Highlight_onoff(Object_1_blade3, 1f));


            ps.simulationSpeed = 2f;
            emmisions.rateOverTime = 1f;
            StartCoroutine(Animation_play(22, 0f));
            StartCoroutine(Arrow_high(4f));
            //StartCoroutine(Animation_play(5.3));
            //원상복구하는 애니메이션?

            //카메라 뷰 이동
            Debug.Log("act10");
        }
        else if (count == 12)
        {
            if (Prev_Status == true)
            {
                Wind_particle.SetActive(true);
                Camera.GetComponent<Camera_movement>().act1();
                Prev_Status = false;
            }

            //콜라이더(툴팁, 하이라이트)

            //위로 회전하는 애니메이션
            //화살표 일부 활성화

            //카메라 뷰 이동
            Debug.Log("act10");
            Arrow_off();
            Object_Highlight_Off_ALL();
            ps.simulationSpeed = 4f;
            emmisions.rateOverTime = 2f;
            StartCoroutine(Animation_play(21, 2f));
            StartCoroutine(Arrow_low(2f));
        }
        else if (count == 13)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }

            Wind_particle.SetActive(false);
            Object_Highlight_Off_ALL();
            StopAllCoroutines();
            Arrow_off();

            pitch[0].SetActive(false);
            pitch[1].SetActive(false);
            pitch[2].SetActive(false);
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_4_Nacelle);
            Object_Col_On(Object_13_Gearbox);
            Object_Col_On(Object_11_Mainshaft);
            Object_Col_On(Object_14_Generator);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_4_Nacelle));
            StartCoroutine(Highlight_onoff(Object_13_Gearbox));
            StartCoroutine(Highlight_onoff(Object_11_Mainshaft));
            StartCoroutine(Highlight_onoff(Object_14_Generator));

            Camera.GetComponent<Camera_movement>().act5();
        }
        else if (count == 13)
        {
            Object_Col_Off_ALL();
        }
        else if (count == 14)
        {
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();

            //하이라이트 효과
            StartCoroutine(Animation_play(6));
            newmodel.GetComponent<Animation>().Play("NM_mainshaft_rotation");

            Camera.GetComponent<Camera_movement>().act7();
        }
        else if (count == 15)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_13_Gearbox);
            Object_Col_On(Object_11_Mainshaft);
            Object_Col_On(Object_6_Rotor);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_11_Mainshaft));

            Camera.GetComponent<Camera_movement>().act5();
            newmodel.GetComponent<Animation>().Play("NM_mainshaft_rotation");
        }
        else if (count == 16)
        {
            if (Prev_Status == true)
            {
                Object_13_Gearbox.SetActive(true);
                Prev_Status = false;
            }
            Object_Col_Off_ALL();
            Object_Col_On(Object_13_Gearbox);
            Object_Col_On(Object_11_Mainshaft);

            StartCoroutine(Highlight_onoff(Object_13_Gearbox));
        }
        else if (count == 17)
        {
            if (Prev_Status == true)
            {
                Camera.GetComponent<Camera_movement>().act5();
                Prev_Status = false;
                Object_13_Gearbox.SetActive(false);
            }

            Object_13_Gearbox.SetActive(false);
            Object_Col_Off_ALL();
            Object_11_Mainshaft.GetComponent<Object_mouseover_withouthighlight>().Tooltip_text = "저속-고토크 입력동력";
            Object_Col_On(Object_11_Mainshaft);
            Object_Col_On(Object_17_shaft_brake_disc);
            StartCoroutine(Highlight_onoff(Object_11_Mainshaft));
            StartCoroutine(Highlight_onoff(Object_17_shaft_brake_disc));
            newmodel.GetComponent<Animation>().Play("NM_gear,shaft_rotation");
            StartCoroutine(Animation_play(17));

        }
        else if (count == 18)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }
            Object_Col_Off_ALL();
            newmodel.GetComponent<Animation>().Stop();
            Anim.Stop();
            Camera.GetComponent<Camera_movement>().act18();
            //StartCoroutine(Animation_play(6.2));
            Object_13_Gearbox.SetActive(true);
            Object_4_Nacelle.SetActive(false);
            
        }
        else if (count == 19)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }
            Object_Col_Off_ALL();
            Object_Col_On(Object_12_1_Yaw_system_1);
            Object_Col_On(Object_12_1_Yaw_system_2);
            Object_Col_On(Object_12_1_Yaw_system_3);
            Object_Col_On(Object_12_1_Yaw_system_4);
            Object_Col_On(Object_12_2_Yaw_bearing);
            Object_Col_On(Object_12_3_Yaw_Gearing);
            Object_Col_On(Object_12_4_Brake_disc);
            Object_Col_On(Object_12_5_Brake_cal);
            Object_Col_On(Object_12_6_Brake_cal_2);
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_1, 1f));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_2, 1f));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_3, 1f));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_4, 1f));
            StartCoroutine(Highlight_onoff(Object_12_2_Yaw_bearing, 2.5f));
            StartCoroutine(Highlight_onoff(Object_12_3_Yaw_Gearing, 4f));
            StartCoroutine(Highlight_onoff(Object_12_4_Brake_disc, 5.5f));
            StartCoroutine(Highlight_onoff(Object_12_5_Brake_cal, 7f));
            StartCoroutine(Highlight_onoff(Object_12_6_Brake_cal_2, 7f));
        }
        else if (count == 20)
        {
            Object_Col_Off_ALL();
            Object_Col_On(Object_12_1_Yaw_system_1);
            Object_Col_On(Object_12_1_Yaw_system_2);
            Object_Col_On(Object_12_1_Yaw_system_3);
            Object_Col_On(Object_12_1_Yaw_system_4);
            Object_Col_On(Object_12_3_Yaw_Gearing);
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_1, 1f));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_2, 1f));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_3, 1f));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_4, 1f));
            StartCoroutine(Highlight_onoff(Object_12_3_Yaw_Gearing, 4f));

            //애니메이션 자체 대기시간 추가함, 4f
            StartCoroutine(Animation_play(6.1));
        }
        else if (count == 21)
        {

            if (Prev_Status == true)
            {

                Prev_Status = false;
            }


            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_12_5_Brake_cal);
            Object_Col_On(Object_12_4_Brake_disc);
            Object_Col_On(Object_12_6_Brake_cal_2);
            StartCoroutine(Highlight_onoff(Object_12_4_Brake_disc));
            StartCoroutine(Highlight_onoff(Object_12_5_Brake_cal, 2f));
            StartCoroutine(Highlight_onoff(Object_12_6_Brake_cal_2, 2f));

            //애니메이션 자체 대기시간 추가함, 4f
            StartCoroutine(Animation_play(51));

            Camera.GetComponent<Camera_movement>().act18();
        }
        else if (count == 22)
        {

            if (Prev_Status == true)
            {

                Prev_Status = false;
            }
            Camera.GetComponent<Camera_movement>().act22();
            Object_17_shaft_brake_disc.GetComponent<Object_mouseover_withouthighlight>().Tooltip_text = "주축용 브레이크 디스크";
            Object_Col_Off_ALL();
            Object_Col_On(Object_22_brake_shaft);
            Object_Col_On(Object_17_shaft_brake_disc);
            Object_Col_On(Object_12_4_Brake_disc);
            StartCoroutine(Highlight_onoff(Object_22_brake_shaft, 6f));
            StartCoroutine(Highlight_onoff(Object_17_shaft_brake_disc, 4f));
            StartCoroutine(Highlight_onoff(Object_12_5_Brake_cal, 2f));
        }
        else if (count == 23)
        {
            if (Prev_Status == true)
            {
                Object_13_Gearbox.SetActive(true);
                Prev_Status = false;
            }
            Camera.GetComponent<Camera_movement>().act23();
            Camera.GetComponent<Camera_movement>().distance = 5f;
            Object_Col_Off_ALL();
            Object_Col_On(Object_22_brake_shaft);
            newmodel.GetComponent<Animation>().Play("NM_gear,shaft_rotation");
            StartCoroutine(Animation_play(17));
            StartCoroutine(Highlight_onoff(Object_22_brake_shaft, 1f));

            //애니메이션 자체 대기시간 추가함, 4f
            StartCoroutine(Animation_play(52));

        }
        else if (count == 24)
        {
            if (Prev_Status == true)
            {

                Prev_Status = false;
            }
            Camera.GetComponent<Camera_movement>().act24();
            Object_Col_Off_ALL();
            Object_Col_On(Object_21_shaft_brake_pad);
            StartCoroutine(Highlight_onoff(Object_21_shaft_brake_pad, 1f));


            Object_13_Gearbox.SetActive(false);
            newmodel.GetComponent<Animation>().Play("NM_gear,shaft_rotation");
            StartCoroutine(Animation_play(17));


            //애니메이션 자체 대기시간 추가함, 4f
            StartCoroutine(Animation_play(24));//주축, 패드 작동 후 정지
            StartCoroutine(Animation_play(53));//기어 정지
            

        }
        else if (count == 25)
        {
            if (Prev_Status == true)
            {

                Prev_Status = false;
            }
            Object_13_Gearbox.SetActive(true);
            Anim.Stop();
            Camera.GetComponent<Camera_movement>().act18();
            Object_Col_On(Object_12_5_Brake_cal);
            Object_Col_On(Object_12_4_Brake_disc);
            Object_Col_On(Object_12_6_Brake_cal_2);
            StartCoroutine(Highlight_onoff(Object_12_4_Brake_disc));
            StartCoroutine(Highlight_onoff(Object_12_5_Brake_cal, 2f));
            StartCoroutine(Highlight_onoff(Object_12_6_Brake_cal_2, 2f));

            //애니메이션 자체 대기시간 추가함, 4f
            StartCoroutine(Animation_play(51));
            StartCoroutine(Animation_play(25));
        }
        else if (count == 26)
        {
            //최종 애니메이션 추가 부분
        }
    }


    // Update is called once per frame
    void Update()
    {
        BtnCountToggle();

        if (toggle)
        {
            Act(nowCount);
            toggle = false;
        }
    }
    void BtnCountToggle()
    {
        nowCount = gameObject.GetComponent<Script_controller>().btnCount;
        if (nowCount != postCount)
        {
            toggle = true;

            if (nowCount < postCount)
            {
                Prev_Status = true;
            }

        }
        postCount = nowCount;
    }
   
    private void Object_Col_On(GameObject obj)
    {
        obj.GetComponent<MeshCollider>().enabled = true;
    }

    IEnumerator Animation_play(double num, float time = 0f)
    {
        yield return new WaitForSeconds(time);
        if (num == 0)
        {
            //인트로 off
            Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");
        }
        if (num == 1)
        {
            //풍력발전기 회전
            Anim.Play("1_WTG_rotation");
            Debug.Log("anim1");
        }
        else if (num == 2)
        {
            //각 블레이드 이동
            Anim.Play("2_WTG_blade_move");
            Debug.Log("anim2");
        }
        else if (num == 2.1)
        {
            //각 블레이드 원위치 이동
            Anim.Play("2_1_WTG_blade_move(return)");
        }
        else if (num == 3)
        {
            Anim.Play("3_WTG_blade_pitch(retrurn)");
        }
        else if (num == 3.2)
        {
            //각 블레이드 피치 회전
            Anim.Play("3_2_WTG_blade_pitch(rotation)");
        }
        else if (num == 5)
        {
            //로터만 이동
            Anim.Play("5_WTG_rotor_move");
        }
        else if (num == 5.1)
        {
            //로터 허브 스피터 분리 및 이동
            Anim.Play("5_1_WTG_rotor_move(hub,spinner)");
        }
        else if (num == 5.2)
        {
            //로터, 스피너,허브 재조립 및 나셀 분리
            Anim.Play("5_2_WTG_rotor_move_(return)+nacelle_open");
        }
        else if (num == 5.3)
        {
            //로터, 스피너,허브 재조립 및 나셀 분리
            Anim.Play("5_3_WTG_rotor_move_(return)+no_nacelle");
        }
        else if (num == 6)
        {
            //나셀 분리
            Anim.Play("6_WTG_Nacelle_open");
        }
        else if (num == 6.1)
        {
            //나셀 회전
            Anim.Play("6_1_WTG_Nacelle_rotation");
        }
        else if (num == 6.2)
        {
            //나셀 회전
            Anim.Play("6_2_WTG_Nacelle(return)");
        }
        else if (num == 7)
        {
            //로터, 블레이드 분리 후 피치 베어링 회전
            Anim.Play("7_WTG_pitch_bearing(rotation)");
        }
        else if (num == 7.1)
        {
            //블레이드 결합 및 피치 회전
            Anim.Play("7_1_WTG_pitch_bearing,pitch(Rotation)");
        }
        else if (num == 8)
        {
            //블레이드 주축 회전
            Anim.Play("8_WTG_mainshaft,rotor(Rotation)");
        }
        else if (num == 10)
        {
            Anim.Play("6_1_WTG_Nacelle_rotation");

        }
        else if (num == 14)
        {
            Anim.Play("14_WTG_nacelle_close");

        }
        else if (num == 21)
        {
            Anim.Play("A10_WTG_pitch_high");
        }
        else if (num == 22)
        {
            Anim.Play("A10_WTG_pitch_low");
        }

        else if (num == 17)
        {
            Anim.Play("17_WTG_Gearbox_rotation");
        }

        else if (num == 24)
        {
            Anim.Play("24_WTG_Gearbox_stop");

        }

        else if (num == 25)
        {
            Anim.Play("25_WTG_Nacelle_rotation");

        }

        else if (num == 51)
        {//New model exception
            newmodel.GetComponent<Animation>().Play("NM_break_yaw");
        }
        else if (num == 52)
        {//New model exception
            newmodel.GetComponent<Animation>().Play("NM_break_shaft_hold");
        }
        else if (num == 53)
        {//New model exception
            newmodel.GetComponent<Animation>().Play("NM_gear,shaft_stop");
        }
        yield break;
    }

    IEnumerator Highlight_onoff(GameObject obj, float time = 0f)
    {
        yield return new WaitForSeconds(time);
        obj.GetComponent<HighlightEffect>().highlighted = true;
        yield return new WaitForSeconds(3.0f);
        obj.GetComponent<HighlightEffect>().highlighted = false;
        yield break;
        //3초마다 시간 바꿔주는거
    }

    private void Object_Col_Off_ALL()
    {
        Object_1_blade1.GetComponent<MeshCollider>().enabled = false;
        Object_1_blade2.GetComponent<MeshCollider>().enabled = false;
        Object_1_blade3.GetComponent<MeshCollider>().enabled = false;
        Object_4_Nacelle.GetComponent<MeshCollider>().enabled = false;
        Object_5_Tower.GetComponent<MeshCollider>().enabled = false;
        Object_6_Rotor.GetComponent<MeshCollider>().enabled = false;
        Object_7_Shaft.GetComponent<MeshCollider>().enabled = false;
        Object_8_Hub.GetComponent<MeshCollider>().enabled = false;
        Object_9_Pitch_bearing.GetComponent<MeshCollider>().enabled = false;
        Object_10_Spinner.GetComponent<MeshCollider>().enabled = false;
        Object_11_Mainshaft.GetComponent<MeshCollider>().enabled = false;
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = false;
        Object_13_Gearbox.GetComponent<MeshCollider>().enabled = false;
        Object_14_Generator.GetComponent<MeshCollider>().enabled = false;

        Object_9_1_Pitch_sytem_1.GetComponent<MeshCollider>().enabled = false;
        Object_9_1_Pitch_sytem_2.GetComponent<MeshCollider>().enabled = false;
        Object_9_1_Pitch_sytem_3.GetComponent<MeshCollider>().enabled = false;

        Object_12_1_Yaw_system_1.GetComponent<MeshCollider>().enabled = false;
        Object_12_1_Yaw_system_2.GetComponent<MeshCollider>().enabled = false;
        Object_12_1_Yaw_system_3.GetComponent<MeshCollider>().enabled = false;
        Object_12_1_Yaw_system_4.GetComponent<MeshCollider>().enabled = false;

        Object_17_shaft_brake_disc.GetComponent<MeshCollider>().enabled = false;

        Object_12_2_Yaw_bearing.GetComponent<MeshCollider>().enabled = false;
        Object_12_3_Yaw_Gearing.GetComponent<MeshCollider>().enabled = false;
        Object_12_4_Brake_disc.GetComponent<MeshCollider>().enabled = false;
        Object_12_5_Brake_cal.GetComponent<MeshCollider>().enabled = false;
        Object_12_6_Brake_cal_2.GetComponent<MeshCollider>().enabled = false;
        Object_22_brake_shaft.GetComponent<MeshCollider>().enabled = false;
        Object_21_shaft_brake_pad.GetComponent<MeshCollider>().enabled = false;
    }
    private void Object_Highlight_Off_ALL()
    {
        Object_1_blade1.GetComponent<HighlightEffect>().highlighted = false;
        Object_1_blade2.GetComponent<HighlightEffect>().highlighted = false;
        Object_1_blade3.GetComponent<HighlightEffect>().highlighted = false;
        Object_4_Nacelle.GetComponent<HighlightEffect>().highlighted = false;
        Object_5_Tower.GetComponent<HighlightEffect>().highlighted = false;
        Object_6_Rotor.GetComponent<HighlightEffect>().highlighted = false;
        Object_7_Shaft.GetComponent<HighlightEffect>().highlighted = false;
        Object_8_Hub.GetComponent<HighlightEffect>().highlighted = false;
        Object_9_Pitch_bearing.GetComponent<HighlightEffect>().highlighted = false;
        Object_10_Spinner.GetComponent<HighlightEffect>().highlighted = false;
        Object_11_Mainshaft.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_Yaw.GetComponent<HighlightEffect>().highlighted = false;
        Object_13_Gearbox.GetComponent<HighlightEffect>().highlighted = false;
        Object_14_Generator.GetComponent<HighlightEffect>().highlighted = false;

        Object_9_1_Pitch_sytem_1.GetComponent<HighlightEffect>().highlighted = false;
        Object_9_1_Pitch_sytem_2.GetComponent<HighlightEffect>().highlighted = false;
        Object_9_1_Pitch_sytem_3.GetComponent<HighlightEffect>().highlighted = false;

        Object_12_1_Yaw_system_1.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_1_Yaw_system_2.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_1_Yaw_system_3.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_1_Yaw_system_4.GetComponent<HighlightEffect>().highlighted = false;

        Object_17_shaft_brake_disc.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_2_Yaw_bearing.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_3_Yaw_Gearing.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_4_Brake_disc.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_5_Brake_cal.GetComponent<HighlightEffect>().highlighted = false;
        Object_12_6_Brake_cal_2.GetComponent<HighlightEffect>().highlighted = false;
        Object_22_brake_shaft.GetComponent<HighlightEffect>().highlighted = false;
        Object_21_shaft_brake_pad.GetComponent<HighlightEffect>().highlighted = false;
    }
}

