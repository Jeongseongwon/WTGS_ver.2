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
    public GameObject Object_13_Gearbox;
    public GameObject Object_14_Generator;


    private int BtnCount;

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

    void Act1()
    {
        if (Prev_Status == true)
        {
            Prev_Status = false;
            //ī�޶�, ������ ��ġ �缳��

        }

        //�ݶ��̴�(����, ���̶���Ʈ)
        Object_Col_Off_ALL();

        Object_Col_On(Object_1_blade1);
        Object_Col_On(Object_1_blade2);
        Object_Col_On(Object_1_blade3);
        Object_Col_On(Object_4_Nacelle);
        Object_Col_On(Object_5_Tower);
        Object_Col_On(Object_6_Rotor);


        //�ִϸ��̼�
        Camera.GetComponent<Camera_movement>().enabled = true;
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");
        //Anim.Play("1_WTG_rotation");
        StartCoroutine(Animation_play(1));
        Wind_particle.SetActive(true);
        Debug.Log("act1");
    }
    //���̵�
    void Act3()
    {
        if (Prev_Status == true)
        {
            Prev_Status = false;
            //Camera.GetComponent<Camera_movement>().act2();
        }

        //�ݶ��̴�(����, ���̶���Ʈ)
        Object_Col_Off_ALL();
        Object_Col_On(Object_1_blade1);
        Object_Col_On(Object_1_blade2);
        Object_Col_On(Object_1_blade3);


        //���̶���Ʈ ȿ��
        StartCoroutine(Highlight_onoff(Object_1_blade1));
        StartCoroutine(Highlight_onoff(Object_1_blade2));
        StartCoroutine(Highlight_onoff(Object_1_blade3));


        //�ִϸ��̼�
        Wind_particle.SetActive(false);
        Camera.GetComponent<Camera_movement>().act1();
        Anim.Stop();
        //Anim.Play("2_WTG_blade_move");
        StartCoroutine(Animation_play(2));
        Debug.Log("act3");
    }
    void Act4()
    {
        if (Prev_Status == true)
        {
            //

            Prev_Status = false;
        }


        //���̶���Ʈ ȿ��
        StartCoroutine(Highlight_onoff(Object_1_blade1));
        StartCoroutine(Highlight_onoff(Object_1_blade2));
        StartCoroutine(Highlight_onoff(Object_1_blade3));

        //�ִϸ��̼�
        //Anim.Play("3_2_WTG_blade_pitch");
        StartCoroutine(Animation_play(3.2));
        Debug.Log("act4");
    }
    void Act5()
    {
        //�ݶ��̴�(����, ���̶���Ʈ)
        Object_Col_Off_ALL();
        Object_Col_On(Object_6_Rotor);

        //���̶���Ʈ ȿ��
        StartCoroutine(Highlight_onoff(Object_6_Rotor));

        //�ִϸ��̼�
        Wind_particle.SetActive(true);
        Camera.GetComponent<Camera_movement>().act2();
        //Anim.Stop();
        StartCoroutine(Animation_play(2.1));    //������ �� ȸ��
        Debug.Log("act5");

    }
    void Act6()
    {
        //���� ���� �߰�?
        //�ݶ��̴�(����, ���̶���Ʈ)
        Object_Col_Off_ALL();
        Object_Col_On(Object_6_Rotor);

        //���̶���Ʈ ȿ��
        StartCoroutine(Highlight_onoff(Object_6_Rotor));


        //�ִϸ��̼�
        //Anim.Play("5_WTG_rotor_move");
        StartCoroutine(Animation_play(5));

        Debug.Log("act6");
    }
    void Act7()
    {
        //�ݶ��̴�(����, ���̶���Ʈ)
        Object_Col_Off_ALL(); 
        Object_Col_On(Object_6_Rotor);
        Object_Col_On(Object_8_Hub);
        Object_Col_On(Object_9_Pitch_bearing);
        Object_Col_On(Object_10_Spinner);
        Object_Col_On(Object_9_1_Pitch_sytem_1);
        Object_Col_On(Object_9_1_Pitch_sytem_2);
        Object_Col_On(Object_9_1_Pitch_sytem_3);

        //���̶���Ʈ ȿ��
        StartCoroutine(Highlight_onoff(Object_6_Rotor));
        StartCoroutine(Highlight_onoff(Object_8_Hub));
        StartCoroutine(Highlight_onoff(Object_9_Pitch_bearing));
        StartCoroutine(Highlight_onoff(Object_10_Spinner));
        StartCoroutine(Highlight_onoff(Object_9_1_Pitch_sytem_1));

        //�ִϸ��̼�
        Camera.GetComponent<Camera_movement>().act3();
        Anim.Play("5_1_WTG_rotor_move(hub,spinner)");
        StartCoroutine(Animation_play(5.1));
        //StartCoroutine(Animation_play(1));
        //Anim.Play("1_WTG_rotation");
    }
    void Act8()
    {
        //�ݶ��̴�(����, ���̶���Ʈ)
        Object_Col_Off_ALL();
        Object_Col_On(Object_8_Hub);
        Object_Col_On(Object_11_Mainshaft);

        //���̶���Ʈ ȿ��
        StartCoroutine(Highlight_onoff(Object_8_Hub));
        StartCoroutine(Highlight_onoff(Object_11_Mainshaft));

        //�ִϸ��̼�
        Camera.GetComponent<Camera_movement>().act4();
        //5.2�� ����
        StartCoroutine(Animation_play(5.2));
        Debug.Log("act5");
    }
    void Act9()
    {
        Object_Col_Off_ALL();
        //���̵� �и�, ��� ȸ��
        Object_Col_On(Object_9_1_Pitch_sytem_1);
        Object_Col_On(Object_9_Pitch_bearing);

        StartCoroutine(Highlight_onoff(Object_9_1_Pitch_sytem_1));
        StartCoroutine(Highlight_onoff(Object_9_Pitch_bearing));

        Camera.GetComponent<Camera_movement>().act4();
        //5.2�� ����
        StartCoroutine(Animation_play(6));
        Debug.Log("act5");
    }
    void Act10()
    {
        Object_Col_Off_ALL();
        //���̵� ����, ������ ���� ����(������ ������ ����)
        //���̶���Ʈ ����
        Object_Col_On(Object_8_Hub);
        Object_Col_On(Object_11_Mainshaft);

        StartCoroutine(Highlight_onoff(Object_8_Hub));
        StartCoroutine(Highlight_onoff(Object_11_Mainshaft));

        Camera.GetComponent<Camera_movement>().act4();
        //5.2�� ����
        StartCoroutine(Animation_play(6));
        Debug.Log("act5");
    }
    void Act11()
    {
        Object_Col_Off_ALL();
        //���� Ŭ����� �� �и�
        Object_Col_On(Object_8_Hub);
        Object_Col_On(Object_11_Mainshaft);

        StartCoroutine(Highlight_onoff(Object_8_Hub));
        StartCoroutine(Highlight_onoff(Object_11_Mainshaft));

        Camera.GetComponent<Camera_movement>().act4();
        //5.2�� ����
        StartCoroutine(Animation_play(6));
        Debug.Log("act5");
    }
    void Act77()
    {
        Object_Col_Off_ALL();
        Object_9_Pitch_bearing.GetComponent<MeshCollider>().enabled = true;
        Anim.Play("5_WTG_blade_pitch");
        Debug.Log("act6");
    }
    void Act88()
    {
        //���� ���κ�ǰ ���� �߰��ϱ�
        Object_Col_Off_ALL();
        Object_11_Mainshaft.GetComponent<MeshCollider>().enabled = true;
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = true;
        Object_13_Gearbox.GetComponent<MeshCollider>().enabled = true;
        Object_14_Generator.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act5();
        Anim.Play("6_WTG_blade_pitch(return)+nacelle_open");
        Debug.Log("act7");
    }
    void Act19()
    {
        //���� ���κ�ǰ ���� �߰��ϱ�
        Object_Col_Off_ALL();
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act6();
        Anim.Play("7_WTG_Nacelle_rotation");
        Debug.Log("act8");
    }
    // Update is called once per frame
    void Update()
    {
        BtnCountToggle();

        if (nowCount == 0 && toggle)
        {
            
            toggle = false;
        }
        if (nowCount == 1 && toggle)
        {
            Act1();
            toggle = false;
        }
        if (nowCount == 2 && toggle)
        {
            toggle = false;
        }
        if (nowCount == 3 && toggle)
        {
            Act3();
            toggle = false;
        }
        if (nowCount == 4 && toggle)
        {
            Act4();
            toggle = false;
        }
        if (nowCount == 5 && toggle)
        {
            Act5();
            toggle = false;
        }
        if (nowCount == 6 && toggle)
        {
            Act6();
            toggle = false;
        }
        if (nowCount == 7 && toggle)
        {
            Act7();
            toggle = false;
        }
        if (nowCount == 8 && toggle)
        {
            Act8();
            toggle = false;
        }
        if (nowCount == 9 && toggle)
        {
            Act9();
            toggle = false;
        }
        if (nowCount == 10 && toggle)
        {
            Act8();
            toggle = false;
        }
        if (nowCount == 11 && toggle)
        {
            Act8();
            toggle = false;
        }
        if (nowCount == 12 && toggle)
        {
            Act8();
            toggle = false;
        }
        if (nowCount == 13 && toggle)
        {
            Act8();
            toggle = false;
        }
        if (nowCount == 14 && toggle)
        {
            Act8();
            toggle = false;
        }
        if (nowCount == 15 && toggle)
        {
            Act8();
            toggle = false;
        }
        if (nowCount == 16 && toggle)
        {
            Act8();
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
    }

    private void Object_Col_On(GameObject obj)
    {
        obj.GetComponent<MeshCollider>().enabled = true;
    }

    IEnumerator Animation_play(double num)
    {
        if (num == 1)
        {
            //ǳ�¹����� ȸ��
            Anim.Play("1_WTG_rotation");
        }
        else if (num == 2)
        {
            //�� ���̵� �̵�
            Anim.Play("2_WTG_blade_move");
        }
        else if (num == 2.1)
        {
            //�� ���̵� ����ġ �̵�
            Anim.Play("2_1_WTG_blade_move(return)");
        }
        else if (num == 3)
        {
            Anim.Play("3_WTG_blade_pitch(retrurn)");
        }
        else if (num == 3.2)
        {
            //�� ���̵� ��ġ ȸ��
            Anim.Play("3_2_WTG_blade_pitch(rotation)");
        }
        else if (num == 5)
        {
            //���͸� �̵�
            Anim.Play("5_WTG_rotor_move");
        }
        else if (num == 5.1)
        {
            //���� ��� ������ �и� �� �̵�
            Anim.Play("5_1_WTG_rotor_move(hub,spinner)");
        }
        else if (num == 5.2)
        {
            //����, ���ǳ�,��� ������ �� ���� �и�
            Anim.Play("5_2_WTG_rotor_move_(return)+nacelle_open");
        }
        else if (num == 6)
        {
            //���� �и�
            Anim.Play("6_WTG_Nacelle_open");
        }
        else if (num == 6.1)
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

    //�ִϸ��̼� ����ϸ鼭 ������Ʈ �������� �Ͻ����� �� Ȱ��ȭ
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
