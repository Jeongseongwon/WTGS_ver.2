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

    //2-3 Text
    [Header("===== Evaluation =====")]
    public GameObject[] Question_panel;
    public GameObject Result_panel;
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
        Value_Angle_yaw = 0;
        Value_Angle_yaw_target = 0;
        Value_Angle_pitch = 0;
        Value_Angle_pitch_target = 0;
        Value_Velocity_wind = 100;
        Value_Power = 100;

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
            PC_Image_Array[PostCount].gameObject.SetActive(false);
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
                Question_panel[1].SetActive(false);
                Question_panel[0].SetActive(false);
                //�޽��� ȭ�鿡 ��Ÿ��, �гο� ��Ÿ���� ǳ�� �� ǳ���� ���� ǳ�¹����⸦ �����ϼ���
                //�����̼� ���
                //��ġ ���� �ǽ�
                WTGS_Panel.SetActive(true);
                StartCoroutine(Refresh_text_value());
            }
            else if (BtnCount == 4)
            {
                //�� ���� �ǽ�

            }
            else if (BtnCount == 5)
            {
                Result_panel.SetActive(true);
                SetResult();
            }




            if (BtnCount == 1)
            {
                //�̷� �� �ϳ� ȭ�鿡 ��Ÿ����
                //�ִϸ��̼� ���

                if (Prev_Status == true)
                {
                    Subcamera.SetActive(false);
                    WTGS_Panel.SetActive(false);
                    StartCoroutine(Refresh_text_value());
                    Prev_Status = false;
                }
                //StartCoroutine(Intro_anim());
            }
            else if (BtnCount == 2)
            {
                //�̷� �� �ι��� ȭ�鿡 ��Ÿ����
                //ī�޶� �����̴°�, ���� �г� �ִϸ��̼� �߰�

                Camera.GetComponent<Animation>().Play("Camera_move(intro,2_1)");
                Button_active_off(Add_button_p);
                Button_active_off(Reduce_button_p);
                Subcamera.SetActive(true);
                WTGS_Panel.SetActive(true);
                Debug.Log("check_2");
                StartCoroutine(Refresh_text_value());
                Subcamera.SetActive(false);
            }
            else if (BtnCount == 6)
            {
                if (Prev_Status == true)
                {
                    //�ٲ���Һκ�
                    Emergency.SetActive(false);

                    Wind_particle.SetActive(false);
                    Graph_velocity.SetActive(false);
                    Prev_Status = false;
                    Subcamera.SetActive(true);
                }


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
           
            PC_Image_Array[BtnCount].SetActive(true);
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
            Result_panel.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Score_total == 1)
        {
            Result_panel.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Score_total == 2)
        {
            Result_panel.transform.GetChild(2).gameObject.SetActive(true);
        }

        //End_XAPI();

    }
    IEnumerator Startact()
    {
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
