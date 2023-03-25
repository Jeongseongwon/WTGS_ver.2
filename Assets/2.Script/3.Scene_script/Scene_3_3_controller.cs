using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_3_controller : MonoBehaviour
{
    public GameObject PC_Image_Array;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject[] Seq_array;
    public GameObject[] Hihglight;
    int PostCount;

    private bool flag = false;
    private bool Prev_Status = false;
    private GameObject camera;
    private int BtnCount = 0;

    [Header("===== Evaluation =====")]
    public GameObject[] Text_Answer;
    public GameObject Result_panel;
    public GameObject Result_description;
    public GameObject Result_icon;


    private GameObject Correct_answer_message;
    private GameObject Incorrect_answer_message;
    private GameObject Retry_answer_message;
    private int Score_total;
    private int[] Score = new int[4];
    private bool Clicked_question;
    private bool Answer;
    private int Answer_count = 0;
    private int Question_num = 0;

    // Start is called before the first frame update

    void Start()
    {
        PostCount = -1;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject Msg = GameObject.Find("Message");
        Correct_answer_message = Msg.transform.GetChild(0).gameObject;
        Incorrect_answer_message = Msg.transform.GetChild(1).gameObject;
        Retry_answer_message = Msg.transform.GetChild(2).gameObject;

        Score_total = 0;

        //���� ���� ��ŭ ���� �迭 �ʱ�ȭ
        Question_num = 4;
        for (int i = 0; i < Question_num; i++)
        {
            Score[i] = 0;
        }
    }
    //��������
    //3��°���� �ð� ������ �ؽ�Ʈ �ٲ�Բ�


    IEnumerator Startact()
    {
        camera.GetComponent<Animation>().Play();
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        yield return new WaitForSeconds(2f);

        PC_Image_Array.transform.GetChild(BtnCount).gameObject.SetActive(true);
        yield break;
    }
    IEnumerator Act_16()
    {
        yield return new WaitForSeconds(3f);
        Result_panel.SetActive(true);
        yield break;
    }
    // Update is called once per frame
    void Update()
    {
        if (Clicked_question == true)
        {
            Set_score();
            Clicked_question = false;
        }

        BtnCount = gameObject.GetComponent<Script_controller>().btnCount;
        
        if (PostCount != BtnCount)
        {
            if (BtnCount < PostCount)
            {
                Prev_Status = true;
            }
            //PC_Image_Array[PostCount].gameObject.SetActive(false);
            flag = true;
        }

        if (flag == true)
        {

            if (BtnCount == 0)
            {
                StartCoroutine(Startact());
            }
            if (BtnCount == 2)
            {
                Seq_array[0].SetActive(true);
            }
            else if (BtnCount == 5)
            {
                Seq_array[1].SetActive(true);
            }
            else if (BtnCount == 11)
            {
                Seq_array[2].SetActive(true);
            }
            if (BtnCount == 14)
            {
                StartCoroutine(Act_16());
                SetResult();
                Seq_array[3].SetActive(true);
            }
            if (BtnCount > 0)
            {
                PC_Image_Array.transform.GetChild(BtnCount - 1).gameObject.SetActive(false);
                PC_Image_Array.transform.GetChild(BtnCount).gameObject.SetActive(true);
            }
            PostCount = BtnCount;
            flag = false;
        }
    }
    void Set_score()
    {
        if (Answer == true)
        {
            // Score_add();
           // StartCoroutine(Message(true));
            Answer_count = 0;           //����� �ʱ�ȭ

            if (BtnCount == 1)
            {
                Score[0] = 1;
                Score_total += 1;
            }
            else if (BtnCount == 5)
            {
                Score[1] = 1;
                Score_total += 1;
            }
            else if (BtnCount == 11)
            {
                Score[2] = 1;
                Score_total += 1;
            }
            else if (BtnCount == 14)
            {
                Score[3] = 1;
                Score_total += 1;
            }
        }
        else if (Answer == false)
        {
            //����
            Message(false);
            //�޽���
            Answer_count++;
        }
        if (Answer_count == 3)
        {
            //�ش��ϴ� ��ư ���̶���Ʈ Ȱ��ȭ ��Ű��
            //Answer = true;
            Hihglight[BtnCount].SetActive(true);
            Answer_count = 0;
        }
    }
    public void Clicked(bool ans)
    {
        Answer = ans;
        Clicked_question = true;
    }
    void SetResult()
    {
        for (int i = 0; i < Question_num; i++)
        {
            Debug.Log("check_result" + Score[i]);
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
        else if (Score_total <= 2)
        {
            Result_description.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Score_total == 3)
        {
            Result_description.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            //Debug.Log(Score_total);
        }

        //End_XAPI();

    }
    void Message(bool msg)
    {
        if (msg == true)
        {

        }else if (msg == false)
        {
            Retry_answer_message.GetComponent<Animation>().Play();
        }
    }
}
