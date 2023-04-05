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
    public GameObject[] Seq_array;
    public GameObject[] Hihglight;
    

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
    public GameObject Subcamera_frame;
    public GameObject Object_2_blade_rotation;

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
    public GameObject brake_button_1;
    public GameObject brake_button_2;


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

    private float Value_max_p = 0;
    private float Value_max_y = 0;
    private int Limit_angle_p = 0;
    private int init_angle_limit_p = 0;
    private int Limit_angle_y = 0;
    private int init_angle_limit_y = 0;

    //2-3 Evaluation
    [Header("===== Evaluation =====")]
    public GameObject Question;
    //public GameObject[] Text_Answer;
    public GameObject Result_panel;
    public GameObject Result_description;
    public GameObject Result_icon;
    public GameObject Panel_button_inactive;


    private GameObject Correct_answer_message;
    private GameObject Incorrect_answer_message;
    private GameObject Retry_answer_message;
    private int Score_total;
    private int[] Score = new int[5];
    private bool Clicked_question;
    private bool Answer;
    private int Answer_count = 0;
    public float Wind_velocity_for_rot;

    private int BtnCount = 0;

    private int Question_num = 0;

    int PostCount;
    private bool flag = true;
    private bool flag_num_p = false;
    private bool flag_num_y = false;
    bool Prev_Status = false;
    private bool flag_p = false;
    private bool flag_y = false;
    private bool Check_finished = false;

    private bool Check_xAPI=false;

    private List<Dictionary<string, string>> Result_list;
    private new Dictionary<string, string> Result_dictionary;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Msg = GameObject.Find("Message");
        Correct_answer_message = Msg.transform.GetChild(0).gameObject;
        Incorrect_answer_message = Msg.transform.GetChild(1).gameObject;
        Retry_answer_message = Msg.transform.GetChild(2).gameObject;
        Question_num = Question.gameObject.GetComponent<Transform>().childCount;
        Value_Angle_yaw = 0;
        Value_Angle_yaw_target = 0;
        Value_Angle_pitch = 0;
        Value_Angle_pitch_target = 0;
        Value_Velocity_wind = 100;
        Value_Power = 100;
        //xAPI
        if (GameObject.Find("xAPIObject"))
        {
            XAPIApplication.current.SendInitStatement("1");
            XAPIApplication.current.LessonManagerInit("1");
            Check_xAPI = true;
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (Clicked_question == true && BtnCount==2)
        {
            Set_score();
            Clicked_question = false;
        }
        BtnCount = gameObject.GetComponent<Script_controller>().btnCount;   //이 부분 대체 필요

        
        if (PostCount != BtnCount)
        {
            flag = true;
        }

        if (flag == true)
        {
            if (BtnCount == 0)
            {
                StartCoroutine(Startact());
                Button_All_active_off();
            }
            if (BtnCount == 1)
            {
                PC_Image_Array[0].SetActive(false);
                PC_Image_Array[1].SetActive(true);
            }
            else if (BtnCount == 2)
            {
                PC_Image_Array[1].SetActive(false);
                Scriptbox.SetActive(true);
                Panel_button_inactive.SetActive(false);

                Camera.GetComponent<Animation>().Play("Camera_move(intro,2_1)");
                Subcamera.SetActive(true);
                Subcamera_frame.SetActive(true);
                WTGS_Panel.SetActive(true);
                StartCoroutine(Refresh_text_value());


                Wind_particle.SetActive(true);
                Graph_velocity.SetActive(true);
                Change_graph_number(Data_velocity, 12);
                //시작버튼 클릭 유도

            }
            else if (BtnCount == 3)
            {

                Hihglight[0].SetActive(false);
                Emergency.SetActive(true);
                //시작 버튼 활성화, 브레이크 버튼 클릭유도

            }
            else if (BtnCount == 4)
            {
                Button_All_active_on();
                Hihglight[1].SetActive(false);
                Seq_array[0].SetActive(true);
                Manager_audio.instance.Get_Low_wind();

                Limit_angle_p = 0;
                init_angle_limit_p = 0;

                StartCoroutine(Rotate_turbine());
                Wind_velocity_for_rot = 4;
                Green_button_1.SetActive(false);
                Green_button_2.SetActive(false);
                red_button_1.SetActive(true);
                red_button_2.SetActive(true);
                Graph_power.SetActive(true);

                Value_Power = 1700 + ((Value_Angle_pitch) / 45) * 400;
                Change_graph_number(Data_power, Value_Power);
                Change_value(45, 'p');
                StartCoroutine(Alert_value_p());

                Wind_velocity_for_rot = 1;


            }
            else if (BtnCount == 5)
            {
                Hihglight[1].SetActive(false);
                Manager_audio.instance.Stop_Low_wind();
                Manager_audio.instance.Get_Strong_wind();
                Seq_array[1].SetActive(true);
                Wind_velocity_for_rot = 11;

                Limit_angle_p = 35;
                init_angle_limit_p = 45;

                //풍속 변경
                Value_Power = 2500 - ((Value_Angle_pitch - 45) / 45) * 400;
                Change_graph_number(Data_power, Value_Power);
                Change_value(90, 'p');
                Change_graph_number(Data_velocity, 25);
                StartCoroutine(Alert_value_p());
            }
            else if (BtnCount == 6)
            {
                Manager_audio.instance.Stop_Strong_wind();
                Manager_audio.instance.Get_Low_wind();
                Seq_array[2].SetActive(true);
                Wind_velocity_for_rot = 2;

                Limit_angle_p = 100;
                init_angle_limit_p = 90;
                Limit_angle_y = 0;
                init_angle_limit_y = 0;

                //풍속 변경
                Value_Power = 600;
                Change_graph_number(Data_power, Value_Power);
                Change_value(45, 'p');
                Change_graph_number(Data_velocity, 12);
                Change_value(270, 'y');
            }
            else if (BtnCount == 7)
            {
                Seq_array[3].SetActive(true);
                Wind_velocity_for_rot = 2;

                Limit_angle_p = 55;
                init_angle_limit_p = 45;
                Limit_angle_y = 280;
                init_angle_limit_y = 270;

                //풍속 변경
                Value_Power = 600;
                Change_graph_number(Data_power, Value_Power);
                Change_graph_number(Data_velocity, 9);
                Change_value(30, 'p');
                Change_value(10, 'y');
            }
            else if (BtnCount == 8)
            {
                Seq_array[4].SetActive(true);
                Result_panel.SetActive(true);
                SetResult();
                if (Check_xAPI == true)
                {
                    XAPIApplication.current.SendTerminateStatement("1", Result_list, Score_total, true);
                }
            }
            PostCount = BtnCount;
            flag = false;
        }


        Gauge_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, 0 - 100 * (Value_Power / 2100)));
        Wind_direction_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, -Value_Angle_yaw));
        //목표 요 각도, 풍향  변경
        //목표 피치 각도, RPM 변경

        Change_angle_value();

    }
    void Change_angle_value()
    {
        if (flag_num_y == true)
        {
            if (flag_y == true)
            {
                Value_Angle_yaw_target = Mathf.Lerp(Value_Angle_yaw_target, Value_max_y, 1.5f * Time.deltaTime);
                Wind_direction_pin_target.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0,
                   -1 * Mathf.Lerp(Value_Angle_yaw_target, Value_max_y, 1.5f * Time.deltaTime)));

                //Change_graph_number(Data_power, Value_Power);
                if (Value_Angle_yaw_target - Value_max_y <= 0.1 && Value_Angle_yaw_target - Value_max_y >= -0.1)
                {
                    //Debug.Log("Done");
                    flag_num_y = false;
                    flag_y = false;
                }
            }
        }
        if (flag_num_p == true)
        {
            if (flag_p == true)
            {
                Value_Angle_pitch_target = Mathf.Lerp(Value_Angle_pitch_target, Value_max_p, 1.5f * Time.deltaTime);

                //Change_graph_number(Data_power, Value_Power);
                if (Value_Angle_pitch_target - Value_max_p <= 0.1 && Value_Angle_pitch_target - Value_max_p >= -0.1)
                {
                    //Debug.Log("Done");
                    flag_num_p = false;
                    flag_p = false;
                }
            }
        }

    }

    IEnumerator Rotate_turbine()
    {
        //블레이드 회전, 1,2,3 일경우 해당 값 만큼 빠르게 회전
        while (true)
        {
            yield return new WaitForSeconds(0.03f);
            Object_2_blade_rotation.GetComponent<Transform>().Rotate(new Vector3(10 * Wind_velocity_for_rot * Time.deltaTime, 0, 0));

        }
        yield break;
    }
    void SetResult()
    {
        for (int i = 0; i < Question_num; i++)
        {
            if (Score[i] == 0)
            {
                Result_icon.transform.GetChild(i + 4).gameObject.SetActive(true);
            }

        }
        Debug.Log("check_result" + Score_total);
        //범위 재설정 필요
        //0 : 미흡, 1 : 보통, 2 : 우수
        if (Score_total <3)
        {
            Result_description.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Score_total == 3 || Score_total == 3)
        {
            Result_description.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Score_total == 5)
        {
            Result_description.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {

        }

    }
    void Set_score()
    {

        if (Answer == true)
        {
            //정답
            Panel_button_inactive.SetActive(true);
            //Text_Answer[BtnCount - 1].SetActive(true);
            Score[BtnCount - 1] = 1;
            Score_total += 1;
            Answer_count = 0;           //정답시 초기화
            if (Check_xAPI == true)
            {
                Send_Correct_statement();
            }
        }
        else if (Answer == false)
        {
            //오답
            Message(false);
            Answer_count++;
        }

        if (Answer_count == 3)
        {
            if (BtnCount==2)
            {
                Hihglight[BtnCount-2].SetActive(true);
            }else if (BtnCount == 3)
            {
                Hihglight[BtnCount-2].SetActive(true);
            }

            Panel_button_inactive.SetActive(true);
           // Text_Answer[BtnCount - 1].SetActive(true);
            Answer_count = 0;
            Answer = true;
            if (Check_xAPI == true)
            {
                Send_Incorrect_statement();
            }
        }
    }
    public void BtnCount_add()
    {
        gameObject.GetComponent<Script_controller>().NextBtn();
    }
    public void Score_add()
    {
        Score_total += 1;
    }
    public void Clicked(bool ans)
    {
        Debug.Log("answer"+BtnCount);
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

        }
        else if (msg == false)
        {
            Retry_answer_message.GetComponent<Animation>().Play();
        }
    }

    IEnumerator Startact()
    {
        Manager_audio.instance.Get_intro();
        yield return new WaitForSeconds(2.0f);
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        PC_Image_Array[0].SetActive(true);
        yield break;
    }


    private void Change_value(float max, char mode)
    {
        if (mode == 'p')
        {
            flag_p = true;
            flag_num_p = true;
            Value_max_p = max;
        }
        else if (mode == 'y')
        {
            flag_y = true;
            flag_num_y = true;
            Value_max_y = max;
        }
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
    IEnumerator Alert_value_y()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
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
                //gameObject.GetComponent<Script_controller>().NextBtn();
                Alert_message_caution.SetActive(false);
                Alert_message_danger.SetActive(false);
                Debug.Log("Aleart DEAD");
                yield break;
            }

            //제한시간 지나면 종료
        }
    }
    IEnumerator Alert_value_p()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            //5초 정도 시간이 지나고 나면, 타이머 설정, 타이머 리셋
            if (Mathf.Abs(Value_Angle_pitch_target - Value_Angle_pitch) > 20)
            {
                Alert_message_caution.SetActive(false);
                Alert_message_danger.SetActive(true);
            }
            else if (Mathf.Abs(Value_Angle_pitch_target - Value_Angle_pitch) > 10)
            {
                Alert_message_caution.SetActive(true);
                Alert_message_danger.SetActive(false);
            }
            else if (Mathf.Abs(Value_Angle_pitch_target - Value_Angle_pitch) <= 3)
            {
                Alert_message_caution.SetActive(false);
                Alert_message_danger.SetActive(false);
                yield break;
            }
        }
    }
    public void Rotate_blade_up()
    {
        Blade_1.GetComponent<Transform>().Rotate(new Vector3(0, 2.5f, 0));
        Blade_2.GetComponent<Transform>().Rotate(new Vector3(0, 2.5f, 0));
        Blade_3.GetComponent<Transform>().Rotate(new Vector3(0, 2.5f, 0));
    }
    public void Rotate_blade_down()
    {

        Blade_1.GetComponent<Transform>().Rotate(new Vector3(0, -2.5f, 0));
        Blade_2.GetComponent<Transform>().Rotate(new Vector3(0, -2.5f, 0));
        Blade_3.GetComponent<Transform>().Rotate(new Vector3(0, -2.5f, 0));
    }
    public void Rotate_yaw_up()
    {
        Nacelle.GetComponent<Transform>().Rotate(new Vector3(0, 5, 0));
    }
    public void Rotate_yaw_down()
    {
        Nacelle.GetComponent<Transform>().Rotate(new Vector3(0, -5, 0));
    }
    IEnumerator Refresh_text_value()
    {
        while (true)
        {
            Angle_yaw_target.GetComponent<Text>().text = string.Format("{0:0}", Value_Angle_yaw_target);
            Angle_yaw.GetComponent<Text>().text = string.Format("{0:0}", Value_Angle_yaw);
            Angle_pitch_target.GetComponent<Text>().text = string.Format("{0:0}", Value_Angle_pitch_target);
            Angle_pitch.GetComponent<Text>().text = string.Format("{0:0}", Value_Angle_pitch);
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

    public void Set_add_pitch(char mode)
    {
        if (mode == 'p')
        {
            if (Limit_angle_p > init_angle_limit_p)
            {
                if (Value_Angle_pitch < Limit_angle_p)
                {
                    Value_Angle_pitch += 5;
                    Rotate_blade_up();
                }
                else if (Value_Angle_pitch < Limit_angle_p)
                {
                    Debug.Log(" 제어 각도를 확인해주세요 메시지");
                    
                }
            }
            else if (Limit_angle_p <= init_angle_limit_p)
            {
                Value_Angle_pitch += 5;
                Rotate_blade_up();
            }
        }
        else if (mode == 'y')
        {
            
            if (Limit_angle_y > init_angle_limit_y)
            {
                
                if (Value_Angle_yaw < Limit_angle_y)
                {
                    Value_Angle_yaw += 10;
                    Rotate_yaw_up();
                }
                else if (Value_Angle_yaw < Limit_angle_y)
                {
                    Debug.Log(" 제어 각도를 확인해주세요 메시지");
                    
                }
            }
            else if (Limit_angle_y <= init_angle_limit_y)
            {
                Value_Angle_yaw += 10;
                Rotate_yaw_up();
            }
        }

        Change_power_ws();
    }

    public void Set_reduce_pitch(char mode)
    {
        if (mode == 'p')
        {
            if (Limit_angle_p > init_angle_limit_p)
            {
                Value_Angle_pitch -= 5;
                Rotate_blade_down();
            }
            else if (Limit_angle_p <= init_angle_limit_p)
            {
                if (Value_Angle_pitch > Limit_angle_p)
                {
                    Value_Angle_pitch -= 5;
                    Rotate_blade_down();
                }
                else if (Value_Angle_pitch == Limit_angle_p)
                {
                    Debug.Log(" 제어 각도를 확인해주세요 메시지");
                }
            }
        }
        else if (mode == 'y')
        {
            if (Limit_angle_y > init_angle_limit_y)
            {
                Value_Angle_yaw -= 5;
                Rotate_yaw_down();
            }
            else if (Limit_angle_y <= init_angle_limit_y)
            {
                Debug.Log("- 클릭 비정상");
                if (Value_Angle_yaw > Limit_angle_y)
                {
                    Value_Angle_yaw -= 5;
                    Rotate_yaw_down();
                }
                else if (Value_Angle_yaw == Limit_angle_y)
                {
                    Debug.Log(" 제어 각도를 확인해주세요 메시지");
                }
            }
        }
        else if (mode == 'y')
        {
            if (Limit_angle_y > init_angle_limit_y)
            {
                Value_Angle_yaw -= 10;
                Rotate_yaw_down();
            }
            else if (Limit_angle_y <= init_angle_limit_y)
            {
                Debug.Log("- 클릭 비정상");
                if (Value_Angle_yaw > Limit_angle_y)
                {
                    Value_Angle_yaw -= 10;
                    Rotate_yaw_down();
                }
                else if (Value_Angle_yaw == Limit_angle_y)
                {
                    Debug.Log(" 제어 각도를 확인해주세요 메시지");
                }
            }
        }
        Change_power_ws();
    }

    private void Change_power_ws()
    {
        if (BtnCount == 4)
        {
            Value_Power = 1700 + ((Value_Angle_pitch) / 45) * 400;
            Change_graph_number(Data_power, Value_Power);
            Wind_velocity_for_rot = 1 + 4 * ((Value_Angle_pitch) / 45);
        }
        else if (BtnCount == 5)
        {
            Value_Power = 2500 - ((Value_Angle_pitch - 45) / 45) * 400;
            Change_graph_number(Data_power, Value_Power);
            Wind_velocity_for_rot = 11 - 6 * ((Value_Angle_pitch - 45) / 45);

        }
        else if (BtnCount == 6)
        {
            Value_Power = 600 + (((90 - Value_Angle_pitch) / 45) * 900) + (((Value_Angle_pitch) / 270) * 600);
            Change_graph_number(Data_power, Value_Power);
            Wind_velocity_for_rot = 2 + 2 * ((90 - Value_Angle_pitch) / 45) + ((Value_Angle_pitch) / 270);
        }
        else if (BtnCount == 7)
        {
            Value_Power = 600 + (((45 - Value_Angle_pitch) / 15) * 900) + (((270 - Value_Angle_pitch) / 260) * 600);
            Change_graph_number(Data_power, Value_Power);
            Wind_velocity_for_rot = 2 + 2 * ((45 - Value_Angle_pitch) / 15) + ((270 - Value_Angle_pitch) / 260);
        }
        if ((Mathf.Abs(Value_Angle_pitch_target - Value_Angle_pitch) <= 3 && Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) <= 3))
        {
            gameObject.GetComponent<Script_controller>().NextBtn();
            Send_Correct_statement();
            Score[BtnCount - 4] = 1;
            Score_total += 1;

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

    private void Button_All_active_off()
    {
        Add_button_p.GetComponent<UI_button_2_1>().enabled = false;
        Reduce_button_p.GetComponent<UI_button_2_1>().enabled = false;
        Add_button_y.GetComponent<UI_button_2_2>().enabled = false;
        Reduce_button_y.GetComponent<UI_button_2_2>().enabled = false;
        brake_button_1.GetComponent<UI_button_next>().enabled = false;
        brake_button_2.GetComponent<UI_button_next>().enabled = false;
    }
    private void Button_All_active_on()
    {
        Add_button_p.GetComponent<UI_button_2_1>().enabled = true;
        Reduce_button_p.GetComponent<UI_button_2_1>().enabled = true;
        Add_button_y.GetComponent<UI_button_2_2>().enabled = true;
        Reduce_button_y.GetComponent<UI_button_2_2>().enabled = true;
        brake_button_1.GetComponent<UI_button_next>().enabled = true;
        brake_button_2.GetComponent<UI_button_next>().enabled = true;
    }
    private void Button_active_off(GameObject obj)
    {
        obj.GetComponent<UI_button_2_1>().enabled = false;
        //obj.GetComponent<UI_button_audio>().enabled = false;
    }
    private void Button_active_on(GameObject obj)
    {
        obj.GetComponent<UI_button_2_1>().enabled = true;
        //obj.GetComponent<UI_button_audio>().enabled = false;
    }

    /// <summary>
    /// xAPI
    /// </summary>
    void Send_Correct_statement()
    {
        //2_3은 구조상 기능들을 이안에 포함시킴
        if (BtnCount == 3)
        {
            XAPIApplication.current.SendChoiceStatement("1", "풍력발전기가동", "1", true);
        }
        else if (BtnCount == 4)
        {
            XAPIApplication.current.SendChoiceStatement("1", "블레이드피치제어_정격", "2", true);
        }
        else if (BtnCount == 5)
        {
            XAPIApplication.current.SendChoiceStatement("1", "블레이드피치제어_강풍", "3", true);
        }
        else if (BtnCount == 6)
        {
            XAPIApplication.current.SendChoiceStatement("1", "피치요제어_정격", "4", true);
        }
        else if (BtnCount == 7)
        {
            XAPIApplication.current.SendChoiceStatement("1", "블레이드피치제어_시동", "5", true);
        }
    }
    void Send_Incorrect_statement()
    {
        if (BtnCount == 3)
        {
            XAPIApplication.current.SendChoiceStatement("1", "풍력발전기가동", "1", false);
        }
        else if (BtnCount == 4)
        {
            XAPIApplication.current.SendChoiceStatement("1", "블레이드피치제어_정격", "2", false);
        }
        else if (BtnCount == 5)
        {
            XAPIApplication.current.SendChoiceStatement("1", "블레이드피치제어_강풍", "3", false);
        }
        else if (BtnCount == 6)
        {
            XAPIApplication.current.SendChoiceStatement("1", "피치요제어_정격", "4", false);
        }
        else if (BtnCount == 7)
        {
            XAPIApplication.current.SendChoiceStatement("1", "블레이드피치제어_시동", "5", false);
        }
    }

    public void Send_Terminated_statement_unfinished()
    {
        XAPIApplication.current.SendTerminateStatement("1",Result_list, Score_total, false);
    }
}
