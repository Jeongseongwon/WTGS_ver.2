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

            //정답 맞추게 될 경우 문항 비활성화
            //실습 시작 전에 간단하게 설명 및 메시지 전시 후 실습 시작 하기

            if (BtnCount == 0)
            {
                //학습평가에 대한 얘기를 하는게 맞나?
                //우선은 start act에서 다음으로 바로 넘김
                StartCoroutine(Startact());
            }
            else if (BtnCount == 1)
            {
                //정답 맞추게 될 경우 문항 비활성화
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
            //오답일 경우 해당 번호 이미지 활성화
            if (Score[i] == 0)
            {
                Result_icon.transform.GetChild(i + 4).gameObject.SetActive(true);
            }
        }

        //0 : 미흡, 1 : 보통, 2 : 우수
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
