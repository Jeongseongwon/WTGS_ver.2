using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HighlightPlus;

public class Scene_1_3_controller : MonoBehaviour
{
    public GameObject PC_Image;
    public GameObject[] PC_Image_Array;
    public GameObject Top_navigation;
    public GameObject Scriptbox;

    //1-3 Gameobject
    //블레이드, 로터, 허브, 주축, 증속기, 피치 드라이브, 요드라이브, 발전기, 컨버터
    [Header("===== Gameobject =====")]
    public GameObject Main_object;
    public GameObject Object_1_blade1;
    public GameObject Object_1_blade2;
    public GameObject Object_1_blade3;
    public GameObject Object_2_Rotor;
    public GameObject Object_3_Shaft;
    public GameObject Object_4_Hub;
    public GameObject Object_5_Pitch_bearing;
    public GameObject Object_6_Yaw;
    public GameObject Object_7_Gearbox;
    public GameObject Object_8_Generator;
    public GameObject Object_9_Converter;

    //2-3 Text
    //Evaluation 찾고, child 0 : correct, child 1 : wrong 메시지 배치
    //Cor, Inc 메시지는 Message 오브젝트 하위 오브젝트 0,1 순으로 배치
    //공통으로 쓰는것은 미리 로드를 할 수는 없나
    // 스크립트 컨트롤러 없이 별개 btncount로 동작
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
    private int[] Score = new int [4];
    private bool Clicked_question;
    private bool Answer;
    private int Answer_count = 0;
    private Animation Anim;

    //총 3문항
    private GameObject Question_panel_0;
    private GameObject Question_panel_1;
    private GameObject Question_panel_2;
    private GameObject Question_panel_3;


    public int BtnCount = 0;

    private int Question_num=0;

    int PostCount;
    private bool flag = true;
    private bool flag_num = false;
    bool Prev_Status = false;
    private bool Check_xAPI = false;

    private List<Dictionary<string, string>> Result_list = new List<Dictionary<string, string>>();
    private Dictionary<string, string> Result_1 = new Dictionary<string, string>();
    private Dictionary<string, string> Result_2 = new Dictionary<string, string>();
    private Dictionary<string, string> Result_3 = new Dictionary<string, string>();
    private Dictionary<string, string> Result_4 = new Dictionary<string, string>();
    //0: name, 1: score

    // Start is called before the first frame update
    void Start()
    {
        GameObject Msg = GameObject.Find("Message");
        Correct_answer_message = Msg.transform.GetChild(0).gameObject;
        Incorrect_answer_message = Msg.transform.GetChild(1).gameObject;

        Score_total = 0;
        Question_panel_0 = Question.GetComponent<Transform>().GetChild(0).gameObject;
        Question_panel_1 = Question.GetComponent<Transform>().GetChild(1).gameObject;
        Question_panel_2 = Question.GetComponent<Transform>().GetChild(2).gameObject;
        Question_panel_3 = Question.GetComponent<Transform>().GetChild(3).gameObject;


        Anim = Main_object.GetComponent<Animation>();
        //문제 갯수 만큼 점수 배열 초기화
        Question_num = Question.gameObject.GetComponent<Transform>().childCount;
        for (int i = 0; i< Question_num; i++)
        {
            Score[i] = 0;
        }

        //xAPI
        if (GameObject.Find("xAPIObject"))
        {
            XAPIApplication.current.SendInitStatement("0");
            XAPIApplication.current.LessonManagerInit("0");
            Check_xAPI = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Clicked_question == true && BtnCount <= Question_num)
        {
            Set_score();
            Clicked_question = false;
        }

        if (PostCount != BtnCount)
        {
            flag = true;
        }

        if (flag == true)
        {
            //각 문항 시작시 정답 상태 초기화
            Answer = false;

            if (BtnCount == 0)
            {
                StartCoroutine(Startact());
            }
            if (BtnCount == 1)
            {
                if (Question_panel_0 != null)
                {
                    Panel_button_inactive.SetActive(false);
                    Question_panel_0.SetActive(true);
                    Anim.Play("Ch1_3_WTG_decompos");
                }
            }
            else if (BtnCount == 2)
            {

                if (Question_panel_1 != null)
                {

                    Panel_button_inactive.SetActive(false);
                    Question_panel_1.SetActive(true);
                    Question_panel_0.SetActive(false);
                    Anim.Play("Ch1_3_WTG_compos");
                }
            }
            else if (BtnCount == 3)
            {
                if (Question_panel_2 != null)
                {
                    Panel_button_inactive.SetActive(false);
                    Question_panel_2.SetActive(true);
                    Question_panel_1.SetActive(false);
                }
            }
            else if (BtnCount == 4)
            {
                if (Question_panel_3 != null)
                {
                    Panel_button_inactive.SetActive(false);
                    Question_panel_3.SetActive(true);
                    Question_panel_2.SetActive(false);
                    Anim.Play("Ch1_3_WTG_decompos");
                }
            }
            else if (BtnCount == 5)
            {
                Question_panel_3.SetActive(false);
                Result_panel.SetActive(true);
                SetResult();
            }

            PostCount = BtnCount;
            flag = false;
            
        }

    }

    void SetResult()
    {
        for (int i = 0; i < Question_num; i++)
        {
            if (Score[i] == 0)
            {
                Result_icon.transform.GetChild(i + 5).gameObject.SetActive(true);
            }
        }

        //0 : 미흡, 1 : 보통, 2 : 우수
        if (Score_total == 0)
        {
            Result_description.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Score_total<=2)
        {
            Result_description.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Score_total==3)
        {
            Result_description.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {

        }
        if (Check_xAPI == true)
        {
            XAPIApplication.current.SendTerminateStatement("0", Result_list, Score_total, true);
        }

    }

    void Set_score()
    {
        if (Answer == true)
        {
            Panel_button_inactive.SetActive(true);
           // Score_add();
            Message(true);
            Text_Answer[BtnCount-1].SetActive(true);
            Score[BtnCount-1] = 1;
            Score_total += 1;
            Answer_count = 0;           //정답시 초기화
            if (Check_xAPI == true)
            {
                Send_Correct_statement();
            }
        }
        else if (Answer == false)
        {
            Message(false);
            Answer_count++;
        }

        if (Answer_count == 3)
        {
            Panel_button_inactive.SetActive(true);
            Text_Answer[BtnCount-1].SetActive(true);
            Answer_count = 0;
            Answer = true;
            //오답 choice statement 전송
            if (Check_xAPI == true)
            {
                Send_Incorrect_statement();
            }
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


    void Message(bool msg)
    {
        if (msg == true)
        {
            Correct_answer_message.GetComponent<Animation>().Play();
        }
        else if (msg == false)
        {
            Incorrect_answer_message.GetComponent<Animation>().Play();
        }
    }

    IEnumerator Startact()
    {
        Manager_audio.instance.Get_intro();
        yield return new WaitForSeconds(2.0f);
        //Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        BtnCount_add();
        yield break;
    }

    private void Object_Highlight_Off_ALL()
    {
        Object_1_blade1.GetComponent<HighlightEffect>().highlighted = false;
        Object_1_blade2.GetComponent<HighlightEffect>().highlighted = false;
        Object_1_blade3.GetComponent<HighlightEffect>().highlighted = false;
        Object_2_Rotor.GetComponent<HighlightEffect>().highlighted = false;
        Object_3_Shaft.GetComponent<HighlightEffect>().highlighted = false;
        Object_4_Hub.GetComponent<HighlightEffect>().highlighted = false;
        Object_5_Pitch_bearing.GetComponent<HighlightEffect>().highlighted = false;
        Object_6_Yaw.GetComponent<HighlightEffect>().highlighted = false;
        Object_7_Gearbox.GetComponent<HighlightEffect>().highlighted = false;
        Object_8_Generator.GetComponent<HighlightEffect>().highlighted = false;
        Object_9_Converter.GetComponent<HighlightEffect>().highlighted = false;
    }
    //문제 풀 때는 애니멩션 하지 말고 끝나고 나면 애니멩션 하느 ㄴ걸로
    public void Q_hover_animation_1()
    {
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_1_blade1, 0f));
        StartCoroutine(Highlight_onoff(Object_1_blade2, 0f));
        StartCoroutine(Highlight_onoff(Object_1_blade3, 0f));
    }
    public void Q_hover_animation_2()
    {
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_3_Shaft, 0f));
    }
    public void Q_hover_animation_3()
    {
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_4_Hub, 0f));
    }
    public void Q_hover_animation_4()
    {
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_5_Pitch_bearing, 0f));
    }
    public void Q_hover_animation_2_1()
    {
        //로터, 주축, 증속기, 발전기, 컨버터
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_2_Rotor, 0f));
        StartCoroutine(Highlight_onoff(Object_3_Shaft, 1f));
        StartCoroutine(Highlight_onoff(Object_7_Gearbox, 2f));
        StartCoroutine(Highlight_onoff(Object_8_Generator, 3f));
        StartCoroutine(Highlight_onoff(Object_9_Converter, 4f));
    }
    public void Q_hover_animation_2_2()
    {
        //블레이드 로터 피치 요 발전기
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_1_blade1, 0f));
        StartCoroutine(Highlight_onoff(Object_1_blade2, 0f));
        StartCoroutine(Highlight_onoff(Object_1_blade3, 0f));
        StartCoroutine(Highlight_onoff(Object_2_Rotor, 1f));
        StartCoroutine(Highlight_onoff(Object_5_Pitch_bearing, 2f));
        StartCoroutine(Highlight_onoff(Object_6_Yaw, 3f));
        StartCoroutine(Highlight_onoff(Object_8_Generator, 4f));
    }
    public void Q_hover_animation_2_3()
    {
        //블레이드 로터 주축 증속기 발전기
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_1_blade1, 0f));
        StartCoroutine(Highlight_onoff(Object_1_blade2, 0f));
        StartCoroutine(Highlight_onoff(Object_1_blade3, 0f));
        StartCoroutine(Highlight_onoff(Object_2_Rotor, 1f));
        StartCoroutine(Highlight_onoff(Object_3_Shaft, 2f));
        StartCoroutine(Highlight_onoff(Object_7_Gearbox, 3f));
        StartCoroutine(Highlight_onoff(Object_8_Generator, 4f));
    }
    public void Q_hover_animation_2_4()
    {
        //로터 주축 피치 요 발전기
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_2_Rotor, 0f));
        StartCoroutine(Highlight_onoff(Object_3_Shaft, 1f));
        StartCoroutine(Highlight_onoff(Object_5_Pitch_bearing, 2f));
        StartCoroutine(Highlight_onoff(Object_6_Yaw, 3f));
        StartCoroutine(Highlight_onoff(Object_8_Generator, 4f));
    }
    public void Q_hover_animation_2_5()
    {
        //블레이드 주축 피치 증속기 컨버터
        Object_Highlight_Off_ALL();
        StopAllCoroutines();
        StartCoroutine(Highlight_onoff(Object_1_blade1, 0f));
        StartCoroutine(Highlight_onoff(Object_1_blade2, 0f));
        StartCoroutine(Highlight_onoff(Object_1_blade3, 0f));
        StartCoroutine(Highlight_onoff(Object_3_Shaft, 1f));
        StartCoroutine(Highlight_onoff(Object_5_Pitch_bearing, 2f));
        StartCoroutine(Highlight_onoff(Object_7_Gearbox, 3f));
        StartCoroutine(Highlight_onoff(Object_9_Converter, 4f));
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

    /// <summary>
    /// xAPI
    /// </summary>

    void Send_Correct_statement()
    {
        if (BtnCount == 1)
        {
            XAPIApplication.current.SendChoiceStatement("0", "풍력발전_구조", "1", true);
            Result_1.Add("evaluation-item", "풍력발전_구조");
            Result_1.Add("evaluation-score", "1");
            Result_list.Add(Result_1);
        }
        else if (BtnCount == 2)
        {
            XAPIApplication.current.SendChoiceStatement("0", "증속기이해", "2", true);
            Result_2.Add("evaluation-item", "증속기이해");
            Result_2.Add("evaluation-score", "1");
            Result_list.Add(Result_2);
        }
        else if (BtnCount == 3)
        {
            XAPIApplication.current.SendChoiceStatement("0", "피치시스템이해", "3", true);
            Result_3.Add("evaluation-item", "피치시스템이해");
            Result_3.Add("evaluation-score", "1");
            Result_list.Add(Result_3);
        }
        else if (BtnCount == 4)
        {
            XAPIApplication.current.SendChoiceStatement("0", "에너지전달순서이해", "4", true);
            Result_4.Add("evaluation-item", "에너지전달순서이해");
            Result_4.Add("evaluation-score", "1");
            Result_list.Add(Result_4);
        }
    }

    void Send_Incorrect_statement()
    {
        if (BtnCount == 1)
        {
            XAPIApplication.current.SendChoiceStatement("0", "풍력발전_구조", "1", false);
            Result_1.Add("evaluation-item", "풍력발전_구조");
            Result_1.Add("evaluation-score", "0");
            Result_list.Add(Result_1);
        }
        else if (BtnCount == 2)
        {
            XAPIApplication.current.SendChoiceStatement("0", "증속기이해", "2", false);
            Result_2.Add("evaluation-item", "증속기이해");
            Result_2.Add("evaluation-score", "0");
            Result_list.Add(Result_2);
        }
        else if (BtnCount == 3)
        {
            XAPIApplication.current.SendChoiceStatement("0", "피치시스템이해", "3", false);
            Result_3.Add("evaluation-item", "피치시스템이해");
            Result_3.Add("evaluation-score", "0");
            Result_list.Add(Result_3);
        }
        else if (BtnCount == 4)
        {
            XAPIApplication.current.SendChoiceStatement("0", "에너지전달순서이해", "4", false);
            Result_4.Add("evaluation-item", "에너지전달순서이해");
            Result_4.Add("evaluation-score", "0");
            Result_list.Add(Result_4);
        }
    }

    public void Send_Terminated_statement_unfinished()
    {
        XAPIApplication.current.SendTerminateStatement("0", Result_list, Score_total, false);
    }
}
