using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_1_3_controller : MonoBehaviour
{
    public GameObject PC_Image;
    public GameObject[] PC_Image_Array;
    public GameObject Top_navigation;

    //1-3 Gameobject
    [Header("===== Gameobject =====")]
    public GameObject Wind_particle;
    public GameObject Blade_1;
    public GameObject Blade_2;
    public GameObject Blade_3;
    public GameObject Nacelle;
    public GameObject Arrow;
    public GameObject WTGS_Panel;
    public GameObject Camera;
    public GameObject Subcamera;


    //2-3 Text
    [Header("===== Evaluation =====")]
    public GameObject[] Question_panel;
    public GameObject Result_panel;
    public GameObject Result_description;
    public GameObject Result_icon;
    private int Score_total;
    private int[] Score;


    private int BtnCount;
    private float Value_max = 0;

    int PostCount;
    private bool flag = true;
    private bool flag_num = false;
    bool Prev_Status = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Startact());
    }

    private void PC_ON()
    {

        PC_Image.SetActive(true);
        for (int i = 0; i < PC_Image_Array.Length; i++)
        {
            PC_Image_Array[i].gameObject.SetActive(false);
        }
        PC_Image_Array[0].gameObject.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        BtnCount = gameObject.GetComponent<Script_controller>().btnCount;

        if (PostCount != BtnCount)
        {
            if (BtnCount < PostCount)
            {
                Prev_Status = true;
            }
            //PC_Image_Array[PostCount].gameObject.SetActive(false);
            flag = true;
            Debug.Log("TRUE");
        }

        if (flag == true)
        {

            //���� ���߰� �� ��� ���� ��Ȱ��ȭ
            //�ǽ� ���� ���� �����ϰ� ���� �� �޽��� ���� �� �ǽ� ���� �ϱ�

            if (BtnCount == 0)
            {
                //�н��򰡿� ���� ��⸦ �ϴ°� �³�?
                //�켱�� start act���� �������� �ٷ� �ѱ�
                StartCoroutine(Startact());
            }
            else if (BtnCount == 1)
            {
                //���� ���߰� �� ��� ���� ��Ȱ��ȭ
                if (Question_panel[0] != null)
                {
                    Question_panel[0].SetActive(true);
                }
            }
            else if (BtnCount == 2)
            {

                if (Question_panel[1] != null)
                {
                    Question_panel[1].SetActive(true);
                    Question_panel[0].SetActive(false);
                }
            }
            else if (BtnCount == 3)
            {
                if (Question_panel[2] != null)
                {
                    Question_panel[2].SetActive(true);
                    Question_panel[1].SetActive(false);
                }
            }
            else if (BtnCount == 4)
            {
                if (Question_panel[3] != null)
                {
                    Question_panel[3].SetActive(true);
                    Question_panel[2].SetActive(false);
                }

            }
            else if (BtnCount == 5)
            {
                Question_panel[3].SetActive(false);
                Result_panel.SetActive(true);
                SetResult();
            }


            //PC_Image_Array[BtnCount].SetActive(true);
            PostCount = BtnCount;
            flag = false;
            Debug.Log("FALSE");
        }

    }

    void SetResult()
    {
        for (int i = 0; i < Question_panel.Length; i++)
        {
            //������ ��� �ش� ��ȣ �̹��� Ȱ��ȭ
            if (Score[i] == 0)
            {
                Result_icon.transform.GetChild(i + 4).gameObject.SetActive(true);
            }
        }

        //0 : ����, 1 : ����, 2 : ���
        if (Score_total == 0)
        {
            Result_description.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Score_total == 1)
        {
            Result_description.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Score_total == 2)
        {
            Result_description.transform.GetChild(2).gameObject.SetActive(true);
        }

        //End_XAPI();

    }
    IEnumerator Startact()
    {
        yield return new WaitForSeconds(2.0f);
        //Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        gameObject.GetComponent<Script_controller>().NextBtn();
        yield break;
    }

}
