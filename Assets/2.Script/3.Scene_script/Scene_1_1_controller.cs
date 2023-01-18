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


    private int BtnCount;
    private float turbine_speed;

    void Start()
    {
        Anim = Main_object.GetComponent<Animation>();

        Camera.GetComponent<Camera_movement>().enabled = false;
        StartCoroutine(StartAct());
        Object_Col_Off_ALL();
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

            //애니메이션
            Camera.GetComponent<Camera_movement>().enabled = true;
            Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");
            Camera.GetComponent<Camera_movement>().act0();
            Debug.Log("act1");
        }
        else if (count == 2)
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
            StartCoroutine(Rotate_turbine(1));
            Wind_particle.SetActive(true);

            Debug.Log("act3");
        }
        else if (count == 3)
        {
            if (Prev_Status == true)
            {
                Prev_Status = false;
            }
            //하이라이트 효과

            //애니메이션
            StartCoroutine(Rotate_turbine(2));

            Debug.Log("act4");
        }
        else if (count == 5)
        {
            //콜라이더(툴팁, 하이라이트)
         

            //하이라이트 효과
          
            //애니메이션
        
            //Anim.Stop();
         
            Debug.Log("act5");
        }
        else if (count == 6)
        {
            //주축 내용 추가?
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
         

            //하이라이트 효과
         

            //애니메이션
            Camera.GetComponent<Camera_movement>().act3();
            Anim.Play("5_1_WTG_rotor_move(hub,spinner)");
            StartCoroutine(Animation_play(5.1));
            //StartCoroutine(Animation_play(1));
            //Anim.Play("1_WTG_rotation");
            Debug.Log("act7");
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
    IEnumerator Rotate_turbine(int num=0)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Object_2_blade_rotation.GetComponent<Transform>().Rotate(new Vector3(20 * num * Time.deltaTime, 0, 0));
            
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

