using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestingScene : MonoBehaviour
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
    public int AnswerNum_User=0;

    public string[] QuestionText2;
    public string[] AnswerText2;
    public int AnswerNum2;
    int PhaseNum = 0;

    [Header("========== xAPI  ==========")]
    public string[] Phase_inf;
    public int[] Phase_score;

    private int Answer_result_1 = 0;
    private int Answer_result_2 = 0;

    public GameObject Question_2;

    private Dictionary<string, int> Result = new Dictionary<string, int>();
    private int result_score = 0;

    private bool Check_answer_wrong = false;
    private bool Check_terminated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Intro_BGM") != null)
            GameObject.FindGameObjectWithTag("Intro_BGM").GetComponent<AudioSource>().volume=0.05f;
        BoardBox.SetActive(false);
        Camera.GetComponent<Animation>().Play("TestScene_Cam");

        Answer_result_1 = 1;
        Answer_result_2 = 1;

        Invoke("SetFirstQuestion", 5f);

    }

    /*
     * 
     * ȭ��� ���� & ��� �����Լ�
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

    void SetResult()
    {
        BoardBox.SetActive(false);
        ResultPanel.SetActive(true);
        
        //OX �̹��� ����
        //���۽ÿ� O�� Ȱ��ȭ �Ǿ������Ƿ� X�� ��ȯ�ϴ� ����
        if(Answer_result_1 == 0)
        {         
            Result_o_image_1.SetActive(false);
            Result_x_image_1.SetActive(true);
        }
        if(Answer_result_2 == 0)
        {
            Result_o_image_2.SetActive(false);
            Result_x_image_2.SetActive(true);
        }
        if(Answer_result_2==1&& Answer_result_1 == 1)
        {
            Result_x_image_1.SetActive(false);
            Result_x_image_2.SetActive(false);
        }

        int result_sum = Answer_result_1 + Answer_result_2;

        if (result_sum == 0)
        {
            ResultDescription_word.GetComponent<Text>().text= "<color=white>����</color>";
            ResultDescription_description.GetComponent<Text>().text = "<color=white>���� ����� �ʿ��ؿ�.</color>";
            Result_level1_image.SetActive(true);
        }
        else if (result_sum == 1)
        {
            ResultDescription_word.GetComponent<Text>().text = "<color=yellow>����</color>";
            ResultDescription_description.GetComponent<Text>().text = "<color=white>���� �� ����ϸ� "+"\n"+"�� �� ���ƿ�.</color>";
            Result_level2_image.SetActive(true);
        }
        else if (result_sum == 2)
        {
            ResultDescription_word.GetComponent<Text>().text = "<color=green>���</color>";
            ResultDescription_description.GetComponent<Text>().text = "<color=white>�� �ϼ̾��.</color>";
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
    * �� & ȭ�� ȿ�� �����Լ�
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
        SceneManager.LoadScene("S0.2 ����ȭ��");
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
                Debug.Log("����");
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
                   // Correctanswer_XAPI(Phase_inf[PhaseNum], "selection");
                    Result.Add(Phase_inf[PhaseNum], 0);
                    Check_answer_wrong = false;
                }
                PhaseNum = 1;
                AnswerNum_User = 0;
            }
            if (AnswerNum1 != AnswerNum_User && AnswerNum_User != 0)
            {
                Debug.Log("����");
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
                Debug.Log("����");

                //SetSecondQuestion();
                CorrectMsg.GetComponent<Animation>().Play("ErrorMessage");
                Correct.PlayDelayed(0.5f);
                
                if (Check_answer_wrong == false)
                {
                    //In_Correctanswer_XAPI(Phase_inf[PhaseNum], "selection");
                    Result.Add(Phase_inf[PhaseNum], Phase_score[PhaseNum]);
                }else if(Check_answer_wrong == true)
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
                Debug.Log("����");
                ErrorMsg.GetComponent<Animation>().Play("ErrorMessage");
                Error.PlayDelayed(0.5f);
                AnswerNum_User = 0;
                Answer_result_2 = 0;
                Check_answer_wrong = true;
            }
        }
        if (PhaseNum == 2 && Check_terminated == false)
        {
            Invoke("SetResult", 1f);
            Check_answer_wrong = false;
            Check_terminated = true;
        }
    }


    public void Change_menu()
    {
        if (PhaseNum == 0)
        {
            //In_Correctanswer_XAPI(Phase_inf[0], "selection");
            //In_Correctanswer_XAPI(Phase_inf[1], "selection");
           
        }else if(PhaseNum == 1)
        {
            //In_Correctanswer_XAPI(Phase_inf[1], "selection");
        }
       // End_XAPI();
    }
}
