using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_1_2_controller : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Main_object;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Wind_particle;
    public GameObject Study_title;
   
    private Text text;
    bool toggle = true;
    int nowCount;
    int postCount;
    bool Prev_Status = false;
    private int phase = 0;

    private List<string> anim_list = new List<string>();
    // Start is called before the first frame update

    private Animation Anim;
    public GameObject Object_1_blade1;
    public GameObject Object_2_blade2;
    public GameObject Object_3_blade3;
    public GameObject Object_4_Nacelle;
    public GameObject Object_5_Tower;
    public GameObject Object_6_Rotor;
    public GameObject Object_7_Shaft;
    public GameObject Object_8_Hub;
    public GameObject Object_9_Pitch;
    public GameObject Object_10_Spinner;
    public GameObject Object_11_Mainshaft;
    public GameObject Object_12_Yaw;
    public GameObject Object_13_Gearbox;
    public GameObject Object_14_Generator;

    void Start()
    {
        Anim = Main_object.GetComponent<Animation>();
        
        Camera.GetComponent<Camera_movement>().enabled = false;
        Invoke("StartAct", 3f);
        Object_Col_Off();
    }
    void StartAct()
    {
        //�ϴ� ��ũ��Ʈ, ��Ʈ�� 2 �ִϸ��̼�
        Study_title.SetActive(true);
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
    }
   
    void Act1()
    {
        if (Prev_Status == true)
        {
            Prev_Status = false;
            //ī�޶�, ������ ��ġ �缳��

        }
        Object_Col_Off();
        Object_1_blade1.GetComponent<MeshCollider>().enabled = true;
        Object_2_blade2.GetComponent<MeshCollider>().enabled = true;
        Object_3_blade3.GetComponent<MeshCollider>().enabled = true;
        Object_4_Nacelle.GetComponent<MeshCollider>().enabled = true;
        Object_5_Tower.GetComponent<MeshCollider>().enabled = true;
        Object_6_Rotor.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().enabled = true;
        Study_title.GetComponent<Animation>().Play("Intro_2_animation(off)");
        Anim.Play("1_WTG_rotation");
        Wind_particle.SetActive(true);
        //��Ʈ�� 2
        Debug.Log("act1");
    }
    //���̵�
    void Act2()
    {
        if (Prev_Status == true)
        {
            Prev_Status = false;
            //Camera.GetComponent<Camera_movement>().act2();
        }

        //this.GetComponent<NarrationController>().Audio.clip = this.GetComponent<NarrationController>().AudioFiles[1];

        //Camera.GetComponent<Camera_movement>().act1();

        //�ٶ� ȿ�� ���� �ϰ� ǳ�¹����� ����, �׸��� ���̵常 ������ ��¦ O
        Object_Col_Off();
        Object_1_blade1.GetComponent<MeshCollider>().enabled = true;
        Object_2_blade2.GetComponent<MeshCollider>().enabled = true;
        Object_3_blade3.GetComponent<MeshCollider>().enabled = true;
        Wind_particle.SetActive(false);
        Camera.GetComponent<Camera_movement>().act1();
        Anim.Stop();
        Anim.Play("3_WTG_blade_move");
        Debug.Log("act2");
    }
    void Act3()
    {
        //���̵�, �ٶ� �Ұ� �ٽ� ����ġ, ȸ��
        //Anim.Play("WTG_reset_rotation(3)");
        Wind_particle.SetActive(true);
        Object_6_Rotor.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act2();
        Anim.Play("3_WTG_blade_move(return)");
        Debug.Log("act3");

    }
    void Act4()
    {
        Object_Col_Off();
        Object_6_Rotor.GetComponent<MeshCollider>().enabled = true;
        Object_8_Hub.GetComponent<MeshCollider>().enabled = true;
        Object_9_Pitch.GetComponent<MeshCollider>().enabled = true;
        Object_10_Spinner.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act3();
        Anim.Play("4_WTG_rotor_move");
        
        Debug.Log("act4");
    }
    void Act5()
    {
        Object_Col_Off();
        Object_8_Hub.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act4();
        Debug.Log("act5");
    }
    void Act6()
    {
        Object_Col_Off();
        Object_9_Pitch.GetComponent<MeshCollider>().enabled = true;
        Anim.Play("5_WTG_blade_pitch");
        Debug.Log("act6");
    }
    void Act7()
    {
        //���� ���κ�ǰ ���� �߰��ϱ�
        Object_Col_Off();
        Object_11_Mainshaft.GetComponent<MeshCollider>().enabled = true;
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = true;
        Object_13_Gearbox.GetComponent<MeshCollider>().enabled = true;
        Object_14_Generator.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act5();
        Anim.Play("6_WTG_blade_pitch(return)+nacelle_open");
        Debug.Log("act7");
    }
    void Act8()
    {
        //���� ���κ�ǰ ���� �߰��ϱ�
        Object_Col_Off();
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act6();
        Anim.Play("7_WTG_Nacelle_rotation");
        Debug.Log("act8");
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

    // Update is called once per frame
    void Update()
    {
        BtnCountToggle();
        if (gameObject.GetComponent<Script_controller>().btnCount == 0 && toggle)
        {
            
            toggle = false;
        }
        if (gameObject.GetComponent<Script_controller>().btnCount == 1 && toggle)
        {
            Act1();
            toggle = false;
        }
        if (gameObject.GetComponent<Script_controller>().btnCount == 2 && toggle)
        {
            Act2();
            toggle = false;
        }
        if (gameObject.GetComponent<Script_controller>().btnCount == 3 && toggle)
        {
            Act3();
            toggle = false;
        }
        if (gameObject.GetComponent<Script_controller>().btnCount == 4 && toggle)
        {
            Act4();
            toggle = false;
        }
        if (gameObject.GetComponent<Script_controller>().btnCount == 5 && toggle)
        {
            Act5();
            toggle = false;
        }
        if (gameObject.GetComponent<Script_controller>().btnCount == 6 && toggle)
        {
            Act6();
            toggle = false;
        }
        if (gameObject.GetComponent<Script_controller>().btnCount == 7 && toggle)
        {
            Act7();
            toggle = false;
        }
        if (gameObject.GetComponent<Script_controller>().btnCount == 8 && toggle)
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
    private void Object_Col_Off()
    {
        Object_1_blade1.GetComponent<MeshCollider>().enabled = false;
        Object_2_blade2.GetComponent<MeshCollider>().enabled = false;
        Object_3_blade3.GetComponent<MeshCollider>().enabled = false;
        Object_4_Nacelle.GetComponent<MeshCollider>().enabled = false;
        Object_5_Tower.GetComponent<MeshCollider>().enabled = false;
        Object_6_Rotor.GetComponent<MeshCollider>().enabled = false;
        Object_7_Shaft.GetComponent<MeshCollider>().enabled = false;
        Object_8_Hub.GetComponent<MeshCollider>().enabled = false;
        Object_9_Pitch.GetComponent<MeshCollider>().enabled = false;
        Object_10_Spinner.GetComponent<MeshCollider>().enabled = false;
        Object_11_Mainshaft.GetComponent<MeshCollider>().enabled = false;
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = false;
        Object_13_Gearbox.GetComponent<MeshCollider>().enabled = false;
        Object_14_Generator.GetComponent<MeshCollider>().enabled = false;
    }

    private void Anim_act1()
    {

    }
}
