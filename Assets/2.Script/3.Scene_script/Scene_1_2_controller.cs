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
    public GameObject Study_title_Intro_2;

    private Text text;
    bool toggle = true;
    int nowCount;
    int postCount;
    bool Prev_Status = false;
    private int phase = 0;

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
    public GameObject Object_13_Gearbox;
    public GameObject Object_14_Generator;


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

    IEnumerator Arrow_on_off()
    {
        Arrow_a2.SetActive(true);
        Arrow_b2.SetActive(true);
        Arrow_c2.SetActive(true);
        yield return new WaitForSeconds(2.5f);
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
        yield break;
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

            Arrow_off();


            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_6_Rotor));

            //애니메이션
            Wind_particle.SetActive(true);
            Camera.GetComponent<Camera_movement>().act2();
            //Anim.Stop();
            StartCoroutine(Animation_play(2.1));    //재조립 및 회전
            Debug.Log("act5");
        }
        else if (count == 6)
        {
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_6_Rotor);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_6_Rotor));

            //애니메이션
            //Anim.Play("5_WTG_rotor_move");
            StartCoroutine(Animation_play(5));

            Debug.Log("act6");
        }
        else if (count == 7)
        {
            
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_6_Rotor);
            Object_Col_On(Object_8_Hub);
            Object_Col_On(Object_9_Pitch_bearing);
            Object_Col_On(Object_10_Spinner);
            Object_Col_On(Object_9_1_Pitch_sytem_1);
            Object_Col_On(Object_9_1_Pitch_sytem_2);
            Object_Col_On(Object_9_1_Pitch_sytem_3);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_6_Rotor));
            StartCoroutine(Highlight_onoff(Object_8_Hub));
            StartCoroutine(Highlight_onoff(Object_9_Pitch_bearing));
            StartCoroutine(Highlight_onoff(Object_10_Spinner));
            StartCoroutine(Highlight_onoff(Object_9_1_Pitch_sytem_1));

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
            Object_Col_On(Object_8_Hub);
            Object_Col_On(Object_11_Mainshaft);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_8_Hub));
            StartCoroutine(Highlight_onoff(Object_11_Mainshaft));

            //애니메이션
            Camera.GetComponent<Camera_movement>().act3_1();
            StartCoroutine(Animation_play(5.2));
            //주축 회전

            newmodel.GetComponent<Animation>().Play("NM_mainshaft_rotation");

            Debug.Log("act8");
        }
        else if (count == 9)
        {
            if (Prev_Status == true)
            {
               
                Prev_Status = false;
            }
            newmodel.GetComponent<Animation>().Stop();

            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
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

            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_8_Hub);
            Object_Col_On(Object_11_Mainshaft);

            StartCoroutine(Highlight_onoff(Object_1_blade1));
            StartCoroutine(Highlight_onoff(Object_1_blade2));
            StartCoroutine(Highlight_onoff(Object_1_blade3));

            Camera.GetComponent<Camera_movement>().act7();
            //0213_화살표 추가
            StartCoroutine(Animation_play(7.1));
            Debug.Log("act10");
        }
        else if (count == 11)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }
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
            //5.2로 변경
            StartCoroutine(Animation_play(6));
            Debug.Log("act11");
        }
        else if (count == 12)
        {
            Debug.Log("act12");
        }
        else if (count == 13)
        {
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_11_Mainshaft);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_11_Mainshaft));
            StartCoroutine(Animation_play(8));

            Camera.GetComponent<Camera_movement>().act7();
            Debug.Log("act13");
        }
        else if (count == 14)
        {
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_13_Gearbox);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_13_Gearbox));
            Camera.GetComponent<Camera_movement>().act5();
            Debug.Log("act14");

        }
        else if (count == 15)
        {
            Debug.Log("act 15 스킵 추후 애니메이션 추가");
            //텍스트 추가 및 양옆에 회전하는 애니메이션 추가하기
        }
        else if (count == 16)
        {
            //카메라 시점 변환 요 제어 시스템 하이라이트
            Object_Col_Off_ALL();
            Object_Col_On(Object_12_1_Yaw_system_1);
            Object_Col_On(Object_12_1_Yaw_system_2);
            Object_Col_On(Object_12_1_Yaw_system_3);
            Object_Col_On(Object_12_1_Yaw_system_4);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_1));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_2));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_3));
            StartCoroutine(Highlight_onoff(Object_12_1_Yaw_system_4));
            Camera.GetComponent<Camera_movement>().act6();
            Debug.Log("act16");
        }
        else if (count == 17)
        {
            //카메라 시점 변환 요 제어 시스템 구성요소 하이라이트
            Object_Col_On(Object_12_1_Yaw_system_1);
            Object_Col_On(Object_12_1_Yaw_system_2);
            Object_Col_On(Object_12_1_Yaw_system_3);
            Object_Col_On(Object_12_1_Yaw_system_4);
            Object_Col_On(Object_12_Yaw);


            StartCoroutine(Highlight_onoff(Object_12_Yaw));
            Debug.Log("act17");
        }
        else if (count == 18)
        {
            //요 제어 애니메이션
            StartCoroutine(Animation_play(6.1));
            Debug.Log("act18");
        }
        else if (count == 19)
        {
            Debug.Log("act 19 스킵 추후 애니메이션 추가");
        }
        else if (count == 20)
        {
            
            //피치 줌인 및 이전 상태에서 피치 분리된 상태로 돌아가기

            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_9_1_Pitch_sytem_1);
            Object_Col_On(Object_9_Pitch_bearing);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_9_1_Pitch_sytem_1));
            StartCoroutine(Highlight_onoff(Object_9_Pitch_bearing));

            StartCoroutine(Animation_play(5));
            Camera.GetComponent<Camera_movement>().act4();
            Debug.Log("act 20");
        }
        else if (count == 21)
        {
            StartCoroutine(Animation_play(7));
            //피치 제어 애니메이션 재생
        }
        else if (count == 22)
        {
            if (Prev_Status == true)
            {
                for (int i = 0; i <= 12; i++)
                {
                    turnoffthis[i].gameObject.SetActive(true);
                    newmodel.SetActive(false);
                }
                Prev_Status = false;
            }
            //블레이드 각도 변경하기 및 가능하면 텍스트 추가
        }
        else if (count == 23)
        {  for(int i = 0;i<=12;i++)
            {
                turnoffthis[i].gameObject.SetActive(false);
                newmodel.SetActive(true);
            }

            //주축 잠금 장치, 브레이크, 요 브레이크 하이라이트, 카메라 이동
            Camera.GetComponent<Camera_movement>().act5();
        }
        else if (count == 24)
        {
            StartCoroutine(Highlight_onoff(higligt[0]));
            newmodel.GetComponent<Animation>().Play("yo_break");

            //주축 잠금 장치
        }
        else if (count == 25)
        {

            newmodel.GetComponent<Animation>().Play("nacel_break");
            //core_break.Play("main_break_down");
            //주축용 브레이크
        }
        else if (count == 26)
        {
            newmodel.GetComponent<Animation>().Stop("nacel_break");
            newmodel.GetComponent<Animation>().Play("main_lockup");
            //요 브레이크
            Camera.GetComponent<Camera_movement>().act6();
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
    }

    private void Object_Col_On(GameObject obj)
    {
        obj.GetComponent<MeshCollider>().enabled = true;
    }

    IEnumerator Animation_play(double num)
    {
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
        else if (num == 10)
        {
            Anim.Play("6_1_WTG_Nacelle_rotation");
        }
        else if (num == 10)
        {
            Anim.Play("6_1_WTG_Nacelle_rotation");
        }
        yield break;
    }

    IEnumerator Highlight_onoff(GameObject obj)
    {
        obj.GetComponent<HighlightEffect>().highlighted = true;
        yield return new WaitForSeconds(3.0f);
        obj.GetComponent<HighlightEffect>().highlighted = false;
        yield break;
    }

    //애니메이션 재생하면서 오브젝트 물리엔진 일시정지 및 활성화
    //void KineticDisable()
    //{
    //    Transform AllMetalball = Metalball.GetComponentInChildren<Transform>();
    //    foreach (Transform child in AllMetalball)
    //    {
    //        child.GetComponent<Rigidbody>().isKinematic = true;
    //    }
    //}
    //void KineticEnable()
    //{
    //    Transform AllMetalball = Metalball.GetComponentInChildren<Transform>();
    //    foreach (Transform child in AllMetalball)
    //    {
    //        child.GetComponent<Rigidbody>().isKinematic = false;
    //    }
    //}

}

