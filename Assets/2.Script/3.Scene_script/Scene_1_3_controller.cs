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
    //[Header("===== Gameobject =====")]
    //public GameObject Wind_particle;
    //public GameObject Blade_1;
    //public GameObject Blade_2;
    //public GameObject Blade_3;
    //public GameObject Nacelle;
    //public GameObject Arrow;
    //public GameObject WTGS_Panel;
    //public GameObject Camera;
    //public GameObject Subcamera;

    //2-3 Text
    //Evaluation ã��, child 0 : correct, child 1 : wrong �޽��� ��ġ
    //Cor, Inc �޽����� Message ������Ʈ ���� ������Ʈ 0,1 ������ ��ġ
    //�������� ���°��� �̸� �ε带 �� ���� ����
    // ��ũ��Ʈ ��Ʈ�ѷ� ���� ���� btncount�� ����
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

    //�� 3����
    private GameObject Question_panel_0;
    private GameObject Question_panel_1;
    private GameObject Question_panel_2;
    private GameObject Question_panel_3;
    //private GameObject Question_panel_3;


    private int BtnCount = 0;

    private int Question_num=0;

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

        Score_total = 0;
        Question_panel_0 = Question.GetComponent<Transform>().GetChild(0).gameObject;
        Question_panel_1 = Question.GetComponent<Transform>().GetChild(1).gameObject;
        Question_panel_2 = Question.GetComponent<Transform>().GetChild(2).gameObject;
        Question_panel_3 = Question.GetComponent<Transform>().GetChild(3).gameObject;


        //���� ���� ��ŭ ���� �迭 �ʱ�ȭ
        Question_num = Question.gameObject.GetComponent<Transform>().childCount;
        for (int i = 0; i< Question_num; i++)
        {
            Score[i] = 0;
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
            //�� ���� ���۽� ���� ���� �ʱ�ȭ
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
                }
            }
            else if (BtnCount == 2)
            {

                if (Question_panel_1 != null)
                {

                    Panel_button_inactive.SetActive(false);
                    Question_panel_1.SetActive(true);
                    Question_panel_0.SetActive(false);
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
            Debug.Log("check_result"+ Score[i]);
            //������ ��� �ش� ��ȣ �̹��� Ȱ��ȭ
            //result_icon�� ��ġ�� ���� ������ ������ �Ʒ� ���� ������
            if (Score[i] == 0)
            {
                Result_icon.transform.GetChild(i + 5).gameObject.SetActive(true);
            }
        }

        //0 : ����, 1 : ����, 2 : ���
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
            //Debug.Log(Score_total);
        }

        //End_XAPI();

    }

    void Set_score()
    {
        if (Answer == true)
        {
            //����
            Panel_button_inactive.SetActive(true);
           // Score_add();
            StartCoroutine(Message(true));
            Text_Answer[BtnCount-1].SetActive(true);
            Score[BtnCount-1] = 1;
            Score_total += 1;
            Answer_count = 0;           //����� �ʱ�ȭ
           
        }
        else if (Answer == false)
        {
            //����
            StartCoroutine(Message(false));
            Answer_count++;
        }
        if (Answer_count == 3)
        {
            Panel_button_inactive.SetActive(true);
            Text_Answer[BtnCount-1].SetActive(true);
            Answer_count = 0;
            Answer = true;
           
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
        Manager_audio.instance.Get_intro();
        yield return new WaitForSeconds(2.0f);
        //Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        BtnCount_add();
        yield break;
    }

}
