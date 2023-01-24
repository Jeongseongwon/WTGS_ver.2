using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HighlightPlus;

public class Scene_1_1_controller : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Main_object;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Wind_particle;
    public GameObject Arrow_object_slow;
    public GameObject Arrow_object_fast;
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
    public GameObject Object_2_blade_rotation;
    public GameObject Object_4_Nacelle;
    public GameObject Object_5_Tower;
    public GameObject Object_6_Rotor;
    public GameObject Object_7_Shaft;
    public GameObject Object_11_Mainshaft;
    public GameObject Object_13_Gearbox;
    public GameObject Object_14_Generator;
    public GameObject Object_15_Power_grid;

    public GameObject Object_p_line;

    public GameObject Text_1;
    public GameObject Text_2;

    private Material tower_material;
    public Material test_mat;

    private int BtnCount;
    private float turbine_speed;
    private bool flag_num;
    private float Value_alpha = 0;
    private Color tower_alpha;

    void Start()
    {
        Anim = Main_object.GetComponent<Animation>();

        Camera.GetComponent<Camera_movement>().enabled = false;
        tower_material = Object_5_Tower.gameObject.GetComponent<MeshRenderer>().material;
        tower_alpha = tower_material.color;
        Value_alpha = tower_alpha.a;
        Manager_audio.instance.Get_intro();
    }
    IEnumerator StartAct()
    {
        if (Prev_Status == false)
        {
            yield return new WaitForSeconds(3.0f);

        }
        Study_title_Intro_2.SetActive(true);
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(on)");
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        yield break;
    }
    void Act(int count)
    {
        if (count == 0)
        {
            StartCoroutine(StartAct());
            Object_Col_Off_ALL();
        }
        if (count == 1)
        {



            if (Prev_Status == true)
            {
                StopCoroutine(Rotate_turbine());
                Object_Col_Off_ALL();
                Wind_particle.SetActive(false);
                Arrow_object_slow.SetActive(false);
                Prev_Status = false;
            }

            //애니메이션
            Camera.GetComponent<Camera_movement>().enabled = true;
            StartCoroutine(Intro_anim());
            Camera.GetComponent<Camera_movement>().act0();
            Debug.Log("act1");
        }
        else if (count == 2)
        {
            if (Prev_Status == true)
            {
                Arrow_object_fast.SetActive(false);
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
            StartCoroutine(Rotate_turbine(1));
            Wind_particle.SetActive(true);
            Arrow_object_slow.SetActive(true);
            Debug.Log("act3");
        }
        else if (count == 3)
        {
            if (Prev_Status == true)
            {
                StartCoroutine(Animation_play(6.2));
                Camera.GetComponent<Camera_movement>().act0();
                //나셀 원상복구
                Prev_Status = false;
            }
            //하이라이트 효과
            Object_Col_Off_ALL();
            Object_Col_On(Object_6_Rotor);

            StartCoroutine(Highlight_onoff(Object_6_Rotor));

            //애니메이션
            StartCoroutine(Rotate_turbine(4));
            Arrow_object_slow.SetActive(false);
            Arrow_object_fast.SetActive(true);

            Debug.Log("act4");
        }
        else if (count == 4)
        {
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_6_Rotor);
            Object_Col_On(Object_11_Mainshaft);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_6_Rotor));
            StartCoroutine(Highlight_onoff(Object_11_Mainshaft));

            //애니메이션
            StartCoroutine(Animation_play(6));
            StartCoroutine(Mainshaft_turbine(4));
            Arrow_object_fast.SetActive(false);
            //주축 클로즈업
            Camera.GetComponent<Camera_movement>().Change_position();
            Debug.Log("act5");
        }
        else if (count == 5)
        {
            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_13_Gearbox);
            Object_Col_On(Object_11_Mainshaft);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_13_Gearbox));
            StartCoroutine(Highlight_onoff(Object_11_Mainshaft));


            //애니메이션
            StartCoroutine(Animation_play(11));
            Camera.GetComponent<Camera_movement>().act5();

            //텍스트 추가 
            Text_1.SetActive(true);
            Text_2.SetActive(true);
            Debug.Log("act5");
        }
        else if (count == 6)
        {
            if (Prev_Status == true)
            {

                Color c = Object_5_Tower.gameObject.GetComponent<MeshRenderer>().material.color;
                c.a = 1;
                Object_5_Tower.gameObject.GetComponent<MeshRenderer>().material.color = c;
                Prev_Status = false;
                Camera.GetComponent<Camera_movement>().Change_position();
            }
            Text_2.SetActive(false);
            Text_1.SetActive(false);

            //콜라이더(툴팁, 하이라이트)
            Object_Col_Off_ALL();
            Object_Col_On(Object_14_Generator);

            //하이라이트 효과
            StartCoroutine(Highlight_onoff(Object_14_Generator));

            //애니메이션
            Camera.GetComponent<Camera_movement>().act8();
            StartCoroutine(Animation_play(6.2));
            Debug.Log("act7");
        }
        else if (count == 7)
        {
            //StartCoroutine(Change_alpha(60));
            Color c = Object_5_Tower.gameObject.GetComponent<MeshRenderer>().material.color;
            c.a = 0.3f;
            Object_5_Tower.gameObject.GetComponent<MeshRenderer>().material.color = c;

            Object_Col_On(Object_15_Power_grid);

            StartCoroutine(Highlight_onoff_line(Object_p_line));
            StartCoroutine(Highlight_onoff(Object_15_Power_grid));
            StartCoroutine(Highlight_onoff(Object_5_Tower));

            Camera.GetComponent<Camera_movement>().Change_position_1();

        }
        else if (count == 8)
        {
            Object_Col_Off_ALL();
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

    IEnumerator Intro_anim()
    {
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");
        yield break;
    }

    IEnumerator Rotate_turbine(int num = 0)
    {
        //블레이드 회전, 1,2,3 일경우 해당 값 만큼 빠르게 회전
        while (true)
        {
            yield return new WaitForSeconds(0.03f);
            Object_2_blade_rotation.GetComponent<Transform>().Rotate(new Vector3(10 * num * Time.deltaTime, 0, 0));

            if (num == 3)
            {
                yield break;
            }
        }
        yield break;
    }

    IEnumerator Mainshaft_turbine(int num = 0)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.03f);
            Object_7_Shaft.GetComponent<Transform>().Rotate(new Vector3(10 * num * Time.deltaTime, 0, 0));

            if (num == 3)
            {
                yield break;
            }
        }
        yield break;
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

        Object_11_Mainshaft.GetComponent<MeshCollider>().enabled = false;

        Object_13_Gearbox.GetComponent<MeshCollider>().enabled = false;
        Object_14_Generator.GetComponent<MeshCollider>().enabled = false;

    }

    private void Object_Col_On(GameObject obj)
    {
        obj.GetComponent<MeshCollider>().enabled = true;
    }
    IEnumerator Change_alpha(int num)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.03f);
            if (num == 60)
            {
                Value_alpha = Mathf.Lerp(Value_alpha, 0, 1.5f * Time.deltaTime);
                //Change_graph_number(Data_power, Value_Power);
                if (Value_alpha < 61)
                {
                    tower_alpha.a = Value_alpha;
                    tower_material.color = tower_alpha;
                    yield break;
                }
            }else if (num == 255)
            {
                Value_alpha = Mathf.Lerp(Value_alpha, 255, 1.5f * Time.deltaTime);
                //Change_graph_number(Data_power, Value_Power);
                if (Value_alpha > 254)
                {
                    tower_alpha.a = Value_alpha;
                    tower_material.color = tower_alpha;
                    yield break;
                }

            }
            else
            {
                Debug.Log("alpha value is wrong");
                yield break;
            }
        }
    }


    IEnumerator Animation_play(double num)
    {
        if (num == 1)
        {
            //풍력발전기 회전
            Anim.Play("1_WTG_rotation");
        }
        if (num == 1.1)
        {
            //풍력발전기 회전
            Anim.Play("1_1_WTG_rotation(slow)");
        }
        else if (num == 2)
        {
            //각 블레이드 이동
            Anim.Play("2_WTG_blade_move");
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
        else if (num == 6.2)
        {
            //나셀 결합
            Anim.Play("6_2_WTG_Nacelle(return)");
        }
        else if (num == 7)
        {
            //로터, 블레이드 분리 후 피치 베어링 회전
            Anim.Play("7_WTG_pitch_bearing(Rotation)");
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
        else if (num == 11)
        {
            //나셀 분리 후 주축 회전
            Anim.Play("11_WTG_nacelle,mainshaft(Rotation)");
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
    IEnumerator Highlight_onoff_line(GameObject obj)
    {
        for(int i = 0; i < obj.transform.childCount ; i++)
        {
            obj.transform.GetChild(i).gameObject.GetComponent<HighlightEffect>().highlighted = true;
        }
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            obj.transform.GetChild(i).gameObject.GetComponent<HighlightEffect>().highlighted = false;
        }
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

