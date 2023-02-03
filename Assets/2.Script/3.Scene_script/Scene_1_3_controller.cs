using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_1_3_controller : MonoBehaviour
{
    public GameObject PC_Image;
    public GameObject[] PC_Image_Array;
    public GameObject Top_navigation;
    public GameObject Scriptbox;

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
    //Evaluation 찾고, child 0 : correct, child 1 : wrong 메시지 배치
    //Cor, Inc 메시지는 Message 오브젝트 하위 오브젝트 0,1 순으로 배치
    //공통으로 쓰는것은 미리 로드를 할 수는 없나
    [Header("===== Evaluation =====")]
    public GameObject Question;
    public GameObject[] Text_Answer;
    public GameObject Result_panel;
    public GameObject Result_description;
    public GameObject Result_icon;
    public GameObject Panel_button_inactive;


    private GameObject Correct_answer_message;
    private GameObject Incorrect_answer_message;
    private int Score_total;
    private int[] Score = new int [3];
    private bool Clicked_question;
    private bool Answer;
    private int Answer_count = 0;

    //총 3문항
    private GameObject Question_panel_0;
    private GameObject Question_panel_1;
    private GameObject Question_panel_2;
    //private GameObject Question_panel_3;


    public int BtnCount = 0;

    int PostCount;
    private bool flag = true;
    private bool flag_num = false;
    bool Prev_Status = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Msg = GameObject.Find("Message");
        Correct_answer_message = Msg.transform.GetChild(0).gameObject;
        Incorrect_answer_message = Msg.transform.GetChild(1).gameObject;

        StartCoroutine(Startact());
        Score_total = 0;
        Question_panel_0 = Question.GetComponent<Transform>().GetChild(0).gameObject;
        Question_panel_1 = Question.GetComponent<Transform>().GetChild(1).gameObject;
        Question_panel_2 = Question.GetComponent<Transform>().GetChild(2).gameObject;
        //Question_panel_3 = Question.GetComponent<Transform>().GetChild(3).gameObject;

        for(int i = 0; i< Question.gameObject.GetComponent<Transform>().childCount; i++)
        {
            Score[i] = 0;
        }
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

        if (Clicked_question == true && BtnCount<4)
        {
            Set_score();
            Clicked_question = false;
        }

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
            //다른 과정과 동일하게 인트로 화면에 나타나느게 좋을듯
            if (BtnCount == 0)
            {
                //정답을 맞춰야지만 무조건 다음으로 넘어갈 수 있고
                //다음을 누를 경우 다음 문제가 활성화
                StartCoroutine(Startact());
                if (Question_panel_0 != null)
                {
                    Question_panel_0.SetActive(true);
                }
            }
            else if (BtnCount == 1)
            {

                if (Question_panel_1 != null)
                {
                    Question_panel_1.SetActive(true);
                    Question_panel_0.SetActive(false);
                }
            }
            else if (BtnCount == 2)
            {
                if (Question_panel_2 != null)
                {
                    Question_panel_2.SetActive(true);
                    Question_panel_1.SetActive(false);
                }
            }
            else if (BtnCount == 3)
            {
                //if (Question_panel_3 != null)
                //{

                //}
                //Question_panel_3.SetActive(false);
                Question_panel_2.SetActive(false);
                Result_panel.SetActive(true);
                SetResult();
            }
            //else if (BtnCount == 4)
            //{
            //    Question_panel_3.SetActive(false);
            //    Result_panel.SetActive(true);
            //    SetResult();
            //}

            //PC_Image_Array[BtnCount].SetActive(true);
            PostCount = BtnCount;
            flag = false;
            Debug.Log("FALSE");
        }

    }

    void SetResult()
    {
        int Question_num = Question.gameObject.GetComponent<Transform>().childCount;
        Debug.Log(Question_num);

        for (int i = 0; i < Question_num; i++)
        {
            Debug.Log("check_result"+ Score[i]);
            //오답일 경우 해당 번호 이미지 활성화
            //result_icon내 위치를 직접 맞춰준 다음에 아래 순서 조절함
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
        else
        {
            Debug.Log(Score_total);
        }
        Debug.Log("check_result");

        //End_XAPI();

    }

    void Set_score()
    {
        if (Answer == true)
        {
            //정답
            Score_add();
            StartCoroutine(Message(true));
            Text_Answer[BtnCount].SetActive(true);
            Score[BtnCount] = 1;
            Score_total += 1;
            Answer_count = 0;           //정답시 초기화
            //Panel_button_inactive.SetActive(true):
        }
        else if (Answer == false)
        {
            //오답
            StartCoroutine(Message(false));
            Answer_count++;
        }
        if (Answer_count == 3)
        {
            Text_Answer[BtnCount].SetActive(true);
            Answer_count = 0;
            //Panel_button_inactive.SetActive(true):
        }
    }

    public void BtnCount_add()
    {
        BtnCount += 1;
    }
    public void Score_add()
    {
        Score_total += 1;
    }
    public void Clicked(bool ans)
    {
        Answer = ans;
        Clicked_question = true;
    }
    public bool Get_status_answer()
    {
        return Answer;
    }

    //문제 종료시 버튼 비활성화



    //변수 활성화 될 경우 메시지 활성화 및 정답 처리 체크

    IEnumerator Message(bool msg)
    {
        //true - correct, false - incorrect
        if (msg == true)
        {
            Correct_answer_message.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            Correct_answer_message.SetActive(false);
            yield break;
        }
        else if (msg == false)
        {
            Incorrect_answer_message.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            Incorrect_answer_message.SetActive(false);
            yield break;
        }
    }
    IEnumerator Startact()
    {
        yield return new WaitForSeconds(2.0f);
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        yield break;
    }

}
