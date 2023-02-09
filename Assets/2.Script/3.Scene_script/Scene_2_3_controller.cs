using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_2_3_controller : MonoBehaviour
{
    public GameObject PC_Image;
    public GameObject[] PC_Image_Array;
    public GameObject Scriptbox;
    public GameObject Top_navigation;

    //2-3 Gameobject
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

    //2-3 panel
    [Header("===== Panel obejct =====")]
    public GameObject Green_button_1;
    public GameObject Green_button_2;
    public GameObject red_button_1;
    public GameObject red_button_2;
    public GameObject Emergency;
    public GameObject Alert_message_caution;
    public GameObject Alert_message_danger;
    public GameObject Graph_velocity;
    public GameObject Graph_power;
    public GameObject Data_velocity;
    public GameObject Data_power;
    public GameObject Gauge_pin;
    public GameObject Wind_direction_pin;
    public GameObject Wind_direction_pin_target;
    public GameObject Add_button_p;
    public GameObject Reduce_button_p;
    public GameObject Add_button_y;
    public GameObject Reduce_button_y;


    //2-3 Text
    [Header("===== Text =====")]
    public GameObject Angle_yaw_target;
    public GameObject Angle_yaw;
    public GameObject Angle_pitch_target;
    public GameObject Angle_pitch;
    public GameObject Velocity_wind;
    public GameObject Power;

    //Value
    private float Value_Angle_yaw;
    private float Value_Angle_yaw_target;
    private float Value_Angle_pitch;
    private float Value_Angle_pitch_target;
    private float Value_Velocity_wind;
    private float Value_Power;

    private float Value_max = 0;

    //2-3 Text
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
    private int[] Score = new int[4];
    private bool Clicked_question;
    private bool Answer;
    private int Answer_count = 0;

    //�� 2����
    private GameObject Question_panel_0;
    private GameObject Question_panel_1;

    private int BtnCount = 0;

    private int Question_num = 0;

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
        Question_panel_0 = Question.GetComponent<Transform>().GetChild(0).gameObject;
        Question_panel_1 = Question.GetComponent<Transform>().GetChild(1).gameObject;
        Value_Angle_yaw = 0;
        Value_Angle_yaw_target = 0;
        Value_Angle_pitch = 0;
        Value_Angle_pitch_target = 0;
        Value_Velocity_wind = 100;
        Value_Power = 100;

    }
    // Update is called once per frame
    void Update()
    {
        BtnCount = gameObject.GetComponent<Script_controller>().btnCount;   //�� �κ� ��ü �ʿ�

        if (Clicked_question == true && BtnCount <= Question_num)
        {
            Set_score();
            Clicked_question = false;
        }
        if (PostCount != BtnCount)
        {
            flag = true;
            Debug.Log("TRUE");
        }

        if (flag == true)
        {
            Answer = false;

            if (BtnCount == 0)
            {
                StartCoroutine(Startact());
                Debug.Log("btncount0");
            }

            if (BtnCount == 1)
            {
                Debug.Log("btncount1");
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
            //0. ���� ��ư
            //1. �극��ũ ����
            //3. ��ġ ����
            //4. �� ����
            //5. ��ġ �� ���� ����

            //��Ȳ�� ����
            //�� ���ϴ°� ���� ���ְ�

            else if (BtnCount == 3)
            {
                //�̷� �� �ι��� ȭ�鿡 ��Ÿ����
                //ī�޶� �����̴°�, ���� �г� �ִϸ��̼� �߰�
                //�Ʒ� ��ũ��Ʈ �ڽ��� �ö����

                //��Ȳ ����
                //�ٸ� ��ư ���� ��� ���� ǳ�¹��� ���� �� �극��ũ ������ �ʿ��մϴ� �޽��� ȭ�� ��Ÿ��
                Panel_button_inactive.SetActive(false);
                Question_panel_1.SetActive(false);

                Camera.GetComponent<Animation>().Play("Camera_move(intro,2_1)");
                Subcamera.SetActive(true);
                WTGS_Panel.SetActive(true);
                StartCoroutine(Refresh_text_value());
            }
            else if (BtnCount == 4)
            {
                Emergency.SetActive(true);
                Wind_particle.SetActive(true);
                Graph_velocity.SetActive(true);
                Change_graph_number(Data_velocity, 3);

            }
            else if (BtnCount == 5)
            {
                Green_button_1.SetActive(false);
                Green_button_2.SetActive(false);
                red_button_1.SetActive(true);
                red_button_2.SetActive(true);
                Graph_power.SetActive(true);
                Value_Power = 1800;
                Change_graph_number(Data_power, Value_Power);
            }
            else if (BtnCount == 6)
            {
                //ǳ�� �ٲ����, �����غ��� �޽��� �� �����̼� ����
                //�� ����
                Button_active_off(Add_button_y);
                Button_active_off(Reduce_button_y);
                Button_active_on(Add_button_p);
                Button_active_on(Reduce_button_p);
            }
            else if (BtnCount == 5)
            {
                //ǳ�� �ٲ����, �����غ��� �޽��� �� �����̼� ����
                //�� ����
                Button_active_off(Add_button_p);
                Button_active_off(Reduce_button_p);
                Button_active_on(Add_button_y);
                Button_active_on(Reduce_button_y);
            }
            else if (BtnCount == 7)
            {
                if (Prev_Status == true)
                {
                    Green_button_1.SetActive(true);
                    Green_button_2.SetActive(true);
                    red_button_1.SetActive(false);
                    red_button_2.SetActive(false);

                    Graph_power.SetActive(false);
                    //StopCoroutine(Refresh_pin_value());
                    Change_graph_number(Data_velocity, 12);
                    Prev_Status = false;
                }
                Emergency.SetActive(true);

                Wind_particle.SetActive(true);
                Graph_velocity.SetActive(true);
                Change_graph_number(Data_velocity, 12);

            }
            else if (BtnCount == 8)
            {
                if (Prev_Status == true)
                {
                    //object ����
                    Button_active_off(Add_button_p);
                    Button_active_off(Reduce_button_p);
                    StopCoroutine(Alert_value());

                    //value ����

                    Value_Power = 0;
                    Change_graph_number(Data_power, Value_Power);

                    Change_value(0);
                    StopCoroutine(Alert_value());
                    Prev_Status = false;
                }

                Green_button_1.SetActive(false);
                Green_button_2.SetActive(false);
                red_button_1.SetActive(true);
                red_button_2.SetActive(true);

                Graph_power.SetActive(true);
                Value_Power = 1800;
                Change_graph_number(Data_power, Value_Power);
                //StartCoroutine(Refresh_pin_value());

            }

            PostCount = BtnCount;
            flag = false;
            Debug.Log("FALSE");
        }


        Gauge_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, 0 - 100 * (Value_Power / 2100)));
        Wind_direction_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, -Value_Angle_yaw));
        //��ǥ �䰢��, ǳ��  ����
        if (flag_num == true)
        {
            Value_Angle_yaw_target = Mathf.Lerp(Value_Angle_yaw_target, Value_max, 1.5f * Time.deltaTime);
            Wind_direction_pin_target.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0,
               -1 * Mathf.Lerp(Value_Angle_yaw_target, Value_max, 1.5f * Time.deltaTime)));

            //Change_graph_number(Data_power, Value_Power);
            if (Value_Angle_yaw_target - Value_max <= 0.1 && Value_Angle_yaw_target - Value_max >= -0.1)
            {
                //Debug.Log("Done");
                flag_num = false;
            }

        }

        //������ ���� Ÿ�̸�?
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
            //����
            Panel_button_inactive.SetActive(true);
            Score_add();
            StartCoroutine(Message(true));
            Text_Answer[BtnCount - 1].SetActive(true);
            Score[BtnCount - 1] = 1;
            Score_total += 1;
            Answer_count = 0;           //����� �ʱ�ȭ
            Debug.Log("RIGHT ANSWER");
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
            Text_Answer[BtnCount - 1].SetActive(true);
            Answer_count = 0;
            Answer = true;
            Debug.Log("ENOUGH WRONG TRY");
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
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        gameObject.GetComponent<Script_controller>().NextBtn();
        yield break;
    }


    private void Change_value(float max)
    {
        flag_num = true;
        Value_max = max;
    }

    private void Change_graph_number(GameObject data, float num)
    {
        if (data == Data_velocity)
        {
            data.GetComponent<StreamingGraph>().min = (num - 1f) * 0.05f;
            data.GetComponent<StreamingGraph>().max = (num + 1f) * 0.05f;
        }
        else if (data == Data_power)
        {
            data.GetComponent<StreamingGraph>().min = (num - 100f) * 0.05f;
            data.GetComponent<StreamingGraph>().max = (num + 100f) * 0.05f;

        }
    }
    IEnumerator Alert_value()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("coroutine run");
            //5�� ���� �ð��� ������ ����, Ÿ�̸� ����, Ÿ�̸� ����
            //�������� �ʰ� �ٲٰ� �Ǹ� �������� �Ѿ�� �� �ϵ���?
            if (Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) > 20)
            {
                Alert_message_caution.SetActive(false);
                Alert_message_danger.SetActive(true);
            }
            else if (Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) > 10)
            {
                Alert_message_caution.SetActive(true);
                Alert_message_danger.SetActive(false);
            }
            else if (Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) <= 3)
            {
                //���� �ð� ���� �� ��� �� �ϼ̽��ϴ�.
                //���� �ð� ���� ��� �� �ϸ� ���� �޽��� ���� ���� ������ ����
                //gameObject.GetComponent<Script_controller>().NextBtn();
                Alert_message_caution.SetActive(false);
                Alert_message_danger.SetActive(false);
                Debug.Log("Aleart DEAD");
                yield break;
            }

            //���ѽð� ������ ����
        }
    }
    public void Rotate_blade_up()
    {
        Blade_1.GetComponent<Transform>().Rotate(new Vector3(0, 10, 0));
        Blade_2.GetComponent<Transform>().Rotate(new Vector3(0, 10, 0));
        Blade_3.GetComponent<Transform>().Rotate(new Vector3(0, 10, 0));
    }
    public void Rotate_blade_down()
    {

        Blade_1.GetComponent<Transform>().Rotate(new Vector3(0, -10, 0));
        Blade_2.GetComponent<Transform>().Rotate(new Vector3(0, -10, 0));
        Blade_3.GetComponent<Transform>().Rotate(new Vector3(0, -10, 0));
    }
    public void Rotate_yaw_up()
    {
        Nacelle.GetComponent<Transform>().Rotate(new Vector3(0, 10, 0));
    }
    public void Rotate_yaw_down()
    {
        Nacelle.GetComponent<Transform>().Rotate(new Vector3(0, -10, 0));
    }
    IEnumerator Refresh_text_value()
    {
        while (true)
        {
            Angle_yaw_target.GetComponent<Text>().text = string.Format("{0:0}", Value_Angle_yaw_target);
            Angle_yaw.GetComponent<Text>().text = string.Format("{0:0}", Value_Angle_yaw);
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator Refresh_pin_value()
    {
        while (true)
        {
            // Gauge_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, 0 - 100 * (Value_Power / 2100)));
            Wind_direction_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, -Value_Angle_yaw));
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void Button_active_off(GameObject obj)
    {
        obj.GetComponent<UI_button_2_2>().enabled = false;
        obj.GetComponent<UI_button_audio>().enabled = false;
    }
    private void Button_active_on(GameObject obj)
    {
        obj.GetComponent<UI_button_2_2>().enabled = true;
        obj.GetComponent<UI_button_audio>().enabled = false;
    }
    public void Set_add_pitch()
    {
        Value_Angle_yaw += 5;
        //3�̶� 4�� �� ���� �Ǵ��ؾ���
        if (BtnCount == 9)
        {
            //yaw
            Value_Power = 1900 + ((Value_Angle_yaw) / 30) * 200;
            Change_graph_number(Data_power, Value_Power);
            if (Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) <= 3)
            {
                gameObject.GetComponent<Script_controller>().NextBtn();
            }
        }
        if (BtnCount == 10)
        {
            //pitch
            Value_Power = 400 + ((30 - Value_Angle_pitch) / 30) * 600;
            Change_graph_number(Data_power, Value_Power);
            if (Mathf.Abs(Value_Angle_pitch_target - Value_Angle_pitch) <= 3)
            {
                gameObject.GetComponent<Script_controller>().NextBtn();
                Debug.Log("ACT");
            }
            Debug.Log("CLICK");
        }
    }

    public void Set_reduce_pitch()
    {
        Value_Angle_yaw -= 5;

        if (BtnCount == 15)
        {
            Value_Power = 1000 + ((270 - Value_Angle_yaw) / 270) * 1100;
            Change_graph_number(Data_power, Value_Power);
            if (Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) <= 3)
            {
                gameObject.GetComponent<Script_controller>().NextBtn();
            }
        }
    }

    public void Stop()
    {
        Value_Angle_yaw = 0;
        Value_Angle_yaw_target = 0;
        Value_Velocity_wind = 0;
        Value_Power = 0;
        Wind_particle.SetActive(false);
        Graph_velocity.SetActive(false);
        Graph_power.SetActive(false);
        Data_power.GetComponent<StreamingGraph>().min = 0;
        Data_power.GetComponent<StreamingGraph>().max = 0;
        Data_velocity.GetComponent<StreamingGraph>().min = 0;
        Data_velocity.GetComponent<StreamingGraph>().max = 0;
    }

    public void START()
    {
        Wind_particle.SetActive(true);
        Graph_velocity.SetActive(true);
        Graph_power.SetActive(true);
    }

}
