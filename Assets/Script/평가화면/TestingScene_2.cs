using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestingScene_2 : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Fader;
    public GameObject BoardBox;
    public GameObject ErrorMsg;
    public GameObject CorrectMsg;
    public GameObject SceneLoader;
    public GameObject ResultPanel;
    public GameObject ResultDescription_word;
    public GameObject ResultDescription_description;


    [Header("=============== Result Panel Image ===============")]
    public GameObject Result_x_image_1;
    public GameObject Result_o_image_1;
    public GameObject Result_x_image_2;
    public GameObject Result_o_image_2;
    public GameObject Result_x_image_3;
    public GameObject Result_o_image_3;

    public GameObject Result_level1_image;
    public GameObject Result_level2_image;
    public GameObject Result_level3_image;

    public AudioSource Correct;
    public AudioSource Error;

    [Header("========== Question,Answer Configuration ==========")]
    public Text Question;
    public Text Question_under;
    public Text Question_under_2;

    public Text Answer1;
    public Text Answer2;
    public Text Answer3;
    public Text Answer4;

    [Header("========== Quextion & Answer Text ==========")]
    public string[] QuestionText1;
    public string[] AnswerText1;
    public int AnswerNum1;
    public int AnswerNum_User = 0;

    public string[] QuestionText2;
    public string[] AnswerText2;
    public int AnswerNum2;

    public string[] QuestionText3;
    public string[] AnswerText3;
    public int AnswerNum3;
    int PhaseNum = 0;

    [Header("========== xAPI  ==========")]
    public string[] Phase_inf;
    public int[] Phase_score;

    private int Answer_result_1 = 0;
    private int Answer_result_2 = 0;
    private int Answer_result_3 = 0;

    public GameObject Question_2;

    private Dictionary<string, int> Result = new Dictionary<string, int>();
    private int result_score = 0;

    private bool Check_answer_wrong = false;
    private bool Check_terminated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Intro_BGM") != null)
            GameObject.FindGameObjectWithTag("Intro_BGM").GetComponent<AudioSource>().volume = 0.05f;
        BoardBox.SetActive(false);
        Camera.GetComponent<Animation>().Play("TestScene_Cam");

        Answer_result_1 = 1;
        Answer_result_2 = 1;
        Answer_result_3 = 1;

        Invoke("SetFirstQuestion", 5f);

        //if (GameObject.Find("xAPIObject"))
        //{
        //    //IMRLAB 10-07 씬 로드시 init 문장 전송

        //    XAPIApplication.current.LessonManagerInit();
        //    XAPIApplication.current.SendInitStatementBySceneName();

        //    //IMRLAB 11-04 힌트 텍스트 init
        //    //XAPIApplication.current.nowLessonManager.SetHintCount(0);
        //    //XAPIApplication.current.nowLessonManager.SetHintStatementResultExtensions(SequenceConatiner._sequenceList[0].scoreItems[0].Tip);
        //    //XAPIApplication.current.nowLessonManager.ChangeNewStatement("Hint");
        //}
    }

    /*
     * 
     * 화면상 문제 & 결과 설정함수
     * 
     * 
     */
    void SetFirstQuestion()
    {
        BoardBox.SetActive(true);

        Question.text = QuestionText1[0];
        if (QuestionText1[1] != "null")
        {
            Question_under.text = QuestionText1[1];
        }

        Answer1.text = AnswerText1[0];
        Answer2.text = AnswerText1[1];
        Answer3.text = AnswerText1[2];
        Answer4.text = AnswerText1[3];
    }
    void SetSecondQuestion()
    {
        AnswerNum1 = 0;
        Question.text = QuestionText2[0];
        if (QuestionText2[1] != "null")
        {
            Question_under.text = QuestionText2[1];
        }
        if (QuestionText2[2] != "null")
        {
            Question_under_2.text = QuestionText2[2];
        }

        if (Question_2 != null)
        {
            Question_2.SetActive(true);
        }
        Answer1.text = AnswerText2[0];
        Answer2.text = AnswerText2[1];
        Answer3.text = AnswerText2[2];
        Answer4.text = AnswerText2[3];
    }
    void SetThirdQuestion()
    {
        AnswerNum1 = 0;
        AnswerNum2 = 0;
        Question.text = QuestionText3[0];
        if (QuestionText3[1] != "null")
        {
            Question_under.text = QuestionText3[1];
        }

        Answer1.text = AnswerText3[0];
        Answer2.text = AnswerText3[1];
        Answer3.text = AnswerText3[2];
        Answer4.text = AnswerText3[3];
    }

    void SetResult()
    {
        BoardBox.SetActive(false);
        ResultPanel.SetActive(true);

        if (Answer_result_1 == 0)
        {
            Result_o_image_1.SetActive(false);
            Result_x_image_1.SetActive(true);
        }
        if (Answer_result_2 == 0)
        {
            Result_o_image_2.SetActive(false);
            Result_x_image_2.SetActive(true);
        }
        if (Answer_result_3 == 0)
        {
            Result_o_image_3.SetActive(false);
            Result_x_image_3.SetActive(true);
        }
        if (Answer_result_3 == 1 && Answer_result_2 == 1 && Answer_result_1 == 1)
        {
            Result_x_image_1.SetActive(false);
            Result_x_image_2.SetActive(false);
            Result_x_image_3.SetActive(false);
        }

        int result_sum = Answer_result_1 + Answer_result_2 + Answer_result_3;

        if (result_sum <= 1)
        {
            ResultDescription_word.GetComponent<Text>().text = "<color=white>미흡</color>";
            ResultDescription_description.GetComponent<Text>().text = "<color=white>많은 노력이 필요해요.</color>";
            Result_level1_image.SetActive(true);
        }
        else if (result_sum == 2)
        {
            ResultDescription_word.GetComponent<Text>().text = "<color=yellow>보통</color>";
            ResultDescription_description.GetComponent<Text>().text = "<color=white>조금 더 노력하면 " + "\n" + "될 것 같아요.</color>";
            Result_level2_image.SetActive(true);
        }
        else if (result_sum == 3)
        {
            ResultDescription_word.GetComponent<Text>().text = "<color=green>우수</color>";
            ResultDescription_description.GetComponent<Text>().text = "<color=white>잘 하셨어요.</color>";
            Result_level3_image.SetActive(true);
        }

        //End_XAPI();

    }
    public void SetAnswerNum_User(int a)
    {
        AnswerNum_User = a;
    }

    /*
    * 
    * 씬 & 화면 효과 설정함수
    * 
    * 
    */
    public void NextScene()
    {
        Invoke("FadeOut", 2f);
        SceneLoader.GetComponent<Dual_scene_loader>().LoadNextScene();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainScene()
    {
        SceneManager.LoadScene("S0.2 메인화면");
    }

    public void FadeOut()
    {
        Fader.GetComponent<Fader>().FadeOut(1);
    }
    // Update is called once per frame
    void Update()
    {
        if (PhaseNum == 0)
        {
            if (AnswerNum1 == AnswerNum_User && AnswerNum1 != 0)
            {
                Debug.Log("정답");
                CorrectMsg.GetComponent<Animation>().Play("ErrorMessage");
                Correct.PlayDelayed(0.5f);
                Invoke("SetSecondQuestion", 1f);

                if (Check_answer_wrong == false)
                {
                    //In_Correctanswer_XAPI(Phase_inf[PhaseNum], "selection");
                    Result.Add(Phase_inf[PhaseNum], Phase_score[PhaseNum]);
                }
                else if (Check_answer_wrong == true)
                {
                    //Correctanswer_XAPI(Phase_inf[PhaseNum], "selection");
                    Result.Add(Phase_inf[PhaseNum], 0);
                    Check_answer_wrong = false;
                }
                PhaseNum = 1;
                AnswerNum_User = 0;
            }
            if (AnswerNum1 != AnswerNum_User && AnswerNum_User != 0)
            {
                Debug.Log("오답");
                ErrorMsg.GetComponent<Animation>().Play("ErrorMessage");
                Error.PlayDelayed(0.5f);
                AnswerNum_User = 0;
                Answer_result_1 = 0;
                Check_answer_wrong = true;
            }
        }
        if (PhaseNum == 1)
        {
            if (AnswerNum2 == AnswerNum_User)
            {
                Debug.Log("정답");

                CorrectMsg.GetComponent<Animation>().Play("ErrorMessage");
                Correct.PlayDelayed(0.5f);
                Invoke("SetThirdQuestion", 1f);

                if (Check_answer_wrong == false)
                {
                    //In_Correctanswer_XAPI(Phase_inf[PhaseNum], "selection");
                    Result.Add(Phase_inf[PhaseNum], Phase_score[PhaseNum]);
                }
                else if (Check_answer_wrong == true)
                {
                    //Correctanswer_XAPI(Phase_inf[PhaseNum], "selection");
                    Result.Add(Phase_inf[PhaseNum], 0);
                    Check_answer_wrong = false;
                }
                PhaseNum = 2;
                AnswerNum_User = 0;

            }
            if (AnswerNum2 != AnswerNum_User && AnswerNum_User != 0)
            {
                Debug.Log("오답");
                ErrorMsg.GetComponent<Animation>().Play("ErrorMessage");
                Error.PlayDelayed(0.5f);
                AnswerNum_User = 0;
                Answer_result_2 = 0;
                Check_answer_wrong = true;
            }
        }
        if (PhaseNum == 2)
        {
            if (AnswerNum3 == AnswerNum_User)
            {
                Debug.Log("정답");

                //SetSecondQuestion();
                CorrectMsg.GetComponent<Animation>().Play("ErrorMessage");
                Correct.PlayDelayed(0.5f);

                if (Check_answer_wrong == false)
                {
                    //In_Correctanswer_XAPI(Phase_inf[PhaseNum], "selection");
                    Result.Add(Phase_inf[PhaseNum], Phase_score[PhaseNum]);
                }
                else if (Check_answer_wrong == true)
                {
                    //Correctanswer_XAPI(Phase_inf[PhaseNum], "selection");
                    Result.Add(Phase_inf[PhaseNum], 0);
                    Check_answer_wrong = false;
                }
                PhaseNum = 3;
                AnswerNum_User = 0;

            }
            if (AnswerNum3 != AnswerNum_User && AnswerNum_User != 0)
            {
                Debug.Log("오답");
                ErrorMsg.GetComponent<Animation>().Play("ErrorMessage");
                Error.PlayDelayed(0.5f);
                AnswerNum_User = 0;
                Answer_result_3 = 0;
                Check_answer_wrong = true;
            }
        }
        if (PhaseNum == 3 && Check_terminated == false)
        {
            Invoke("SetResult", 1f);
            Check_answer_wrong = false;
            Check_terminated = true;
        }
    }

    //public void Correctanswer_XAPI(string name, string step)
    //{
    //    if (GameObject.Find("xAPIObject"))
    //    {
    //        //IMRLAB 09-28
    //        //행동 문장 전송
    //        //Debug.Log("Test: " + Checklist.evaluationChecklist[targetSeq][targetStep + 1].Text.text);
    //        //Debug.Log("Test: " + SequenceConatiner._sequenceList[targetSeq].Name);
    //        //Debug.Log("targetSeq: " + targetSeq + "targetStep: " + targetStep);

    //        XAPIApplication.current.nowLessonManager.SetEvaluationItemElement(
    //            name, step, true);
    //        XAPIApplication.current.SendIMRXAPIStatement("Choice");
    //    }
    //}

    //public void In_Correctanswer_XAPI(string name, string step)
    //{
    //    if (GameObject.Find("xAPIObject"))
    //    {
    //        XAPIApplication.current.nowLessonManager.SetEvaluationItemElement(
    //            name, step, false);

    //        XAPIApplication.current.SendIMRXAPIStatement("Choice");
    //    }
    //}

    //public void End_XAPI()
    //{
    //    if (GameObject.Find("xAPIObject"))
    //    {
    //        XAPIApplication.current.GetResultCanvas(Result);
    //        Debug.Log("Terminated send");
    //        XAPIApplication.current.terminatied = true;

    //    }
    //}

    public void Change_menu()
    {
        if (PhaseNum == 0)
        {
            //In_Correctanswer_XAPI(Phase_inf[0], "selection");
            //In_Correctanswer_XAPI(Phase_inf[1], "selection");
            //In_Correctanswer_XAPI(Phase_inf[2], "selection");

        }
        else if (PhaseNum == 1)
        {
            //In_Correctanswer_XAPI(Phase_inf[1], "selection");
            //In_Correctanswer_XAPI(Phase_inf[2], "selection");
        }
        else if (PhaseNum == 2)
        {
            //In_Correctanswer_XAPI(Phase_inf[2], "selection");
        }
       // End_XAPI();
    }
}
