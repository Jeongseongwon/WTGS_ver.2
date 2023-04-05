using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_2_1_controller : MonoBehaviour
{
    public GameObject PC_Image;
    public GameObject[] PC_Image_Array;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Study_title_Intro_2;

    //2-1 Gameobject
    [Header("===== Gameobject =====")]
    public GameObject Blade_1;
    public GameObject Blade_2;
    public GameObject Blade_3;
    public GameObject WTGS_Panel;
    public GameObject Camera;
    public GameObject Subcamera;
    public GameObject Subcamera_frame;
    public GameObject wind_slow;
    public GameObject wind_fast;
    public GameObject Object_2_blade_rotation;

    //2-1 panel
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
    public GameObject Add_button;
    public GameObject Reduce_button;


    //2-1 Text
    [Header("===== Text =====")]
    public GameObject Angle_pitch_target;
    public GameObject Angle_pitch;
    public GameObject Velocity_wind;
    public GameObject Power;

    //Value
    private float Value_Angle_pitch;
    private float Value_Angle_pitch_target;
    private float Value_Velocity_wind;
    private float Value_Power;

    private int BtnCount;
    private float Value_max = 0;
    private int Limit_angle = 0;
    private int init_angle_limit = 0;
    public float Wind_velocity_for_rot;

    int PostCount;
    private bool flag = true;
    private bool flag_num = false;
    bool Prev_Status = false;
    // Start is called before the first frame update
    public ParticleSystem windspeed;

    void Start()
    {
        Value_Angle_pitch = 30;
        Value_Angle_pitch_target = 0;
        Value_Velocity_wind = 100;
        Value_Power = 100;
        StartCoroutine(Startact());
        Manager_audio.instance.Get_intro();
    }
    private void PC_ON()
    {
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");

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
        var ps = windspeed.main;
        var emmisions = windspeed.emission;
        Refresh_text_value();
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
        //for (int i = 0; i < PC_Image_Array.Length; i++)
        //{
        //}
        if (flag == true)
        {
            Scriptbox.GetComponent<Animation>().Play("banner_o");
            if (BtnCount == 0)
            {

            }
            if (BtnCount == 1)
            {
                StartCoroutine(Animation_play(0));
            }
            else if (BtnCount == 2)
            {
                //카메라 움직이는거, 옆에 패널 애니메이션 추가
                Camera.GetComponent<Animation>().Play("Camera_move(intro,2_1)");
                WTGS_Panel.SetActive(true);
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                Debug.Log("check_2");
                StartCoroutine(Refresh_text_value());
            }
            else if (BtnCount == 6)
            {
                if (Prev_Status == true)
                {
                    Manager_audio.instance.Stop_Low_wind();
                    Subcamera.SetActive(false);
                    Subcamera_frame.SetActive(false);

                    Prev_Status = false;
                }

            }
            else if (BtnCount == 7)
            {
                if (Prev_Status == true)
                {
                    //바꿔야할부분
                    Emergency.SetActive(false);

                    wind_slow.SetActive(false);
                    Graph_velocity.SetActive(false);
                    Wind_velocity_for_rot = 1;
                    Change_graph_number(Data_velocity, 0);

                    Prev_Status = false;
                    StopCoroutine(Rotate_turbine());
                }
                
                Manager_audio.instance.Get_Low_wind();

                Subcamera.SetActive(true);
                Subcamera_frame.SetActive(true);

            }
            else if (BtnCount == 8)
            {
                if (Prev_Status == true)
                {
                    Green_button_1.SetActive(true);
                    Green_button_2.SetActive(true);
                    red_button_1.SetActive(false);
                    red_button_2.SetActive(false);

                    Graph_power.SetActive(false);

                    StopCoroutine(Refresh_text_value());

                    Prev_Status = false;
                }

                StartCoroutine(Rotate_turbine());
                Emergency.SetActive(true);

                wind_slow.SetActive(true);
                Graph_velocity.SetActive(true);
                Change_graph_number(Data_velocity, 3);
                Wind_velocity_for_rot=1;
                StartCoroutine(Refresh_pin_value());

            }
            else if (BtnCount == 9)
            {
                if (Prev_Status == true)
                {
                    ps.simulationSpeed = 1f;
                    emmisions.rateOverTime = 1f;
                    Button_active_off(Add_button);
                    Button_active_off(Reduce_button);
                    StopCoroutine(Alert_value());
                    Wind_velocity_for_rot =1;

                    Prev_Status = false;
                }
                Green_button_1.SetActive(false);
                Green_button_2.SetActive(false);
                red_button_1.SetActive(true);
                red_button_2.SetActive(true);

                Graph_power.SetActive(true);
                Change_graph_number(Data_power, 400);

            }
            else if (BtnCount == 10)
            {
                //3m/s
                Limit_angle = 40;
                init_angle_limit = 30;

                if (Prev_Status == true)
                {
                    //object 복구
                    StopCoroutine(Alert_value());
                    wind_fast.SetActive(false);
                    wind_slow.SetActive(true);

                    //value 복구
                    Value_Angle_pitch = 30;
                    Change_graph_number(Data_velocity, 3);
                    Value_Power = 400;
                    Change_graph_number(Data_power, Value_Power);
                    Wind_velocity_for_rot=1;


                    Prev_Status = false;
                }
                ps.simulationSpeed = 1f;
                emmisions.rateOverTime = 1f;

                Button_active_on(Add_button);
                Button_active_on(Reduce_button);
                Value_Power = 400 + ((30 - Value_Angle_pitch) / 30) * 600;
                Change_graph_number(Data_power, Value_Power);
                StartCoroutine(Alert_value());
            }
            else if (BtnCount == 11)
            {

                //12m/s
                ps.simulationSpeed = 2f;
                emmisions.rateOverTime = 1f;
                if (Prev_Status == true)
                {
                    Change_value(0);

                    Prev_Status = false;
                }
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                StopCoroutine(Alert_value());
                Value_Angle_pitch = 0;
                Change_graph_number(Data_velocity, 12);
                Value_Power = 1700;
                Change_graph_number(Data_power, Value_Power);

                Wind_velocity_for_rot=2;
                wind_fast.SetActive(true);
                wind_slow.SetActive(false);
            }
            else if (BtnCount == 12)
            {
                //리미트 0
                Limit_angle = 0;
                init_angle_limit = 0;

                init_angle_limit = 0;
                if (Prev_Status == true)
                {
                    ps.simulationSpeed = 2f;
                    emmisions.rateOverTime = 1f;
                    Wind_velocity_for_rot =4;
                    Manager_audio.instance.Get_Low_wind();
                    Manager_audio.instance.Stop_Strong_wind();
                    //object 복구
                    StopCoroutine(Alert_value());

                    //value 복구
                    Value_Angle_pitch = 0;
                    Change_graph_number(Data_velocity, 12);
                    Value_Power = 1700;
                    Change_graph_number(Data_power, Value_Power);
                    Wind_velocity_for_rot = 2;

                    Prev_Status = false;
                }
                Button_active_on(Add_button);
                Button_active_on(Reduce_button);
                Value_Power = 1700 + ((Value_Angle_pitch) / 45) * 400;
                Change_graph_number(Data_power, Value_Power);
                Change_value(45);
                StartCoroutine(Alert_value());
            }
            else if (BtnCount == 13)
            {
                //20m/s
                ps.simulationSpeed = 4f;
                emmisions.rateOverTime = 2f;
                if (Prev_Status == true)
                {
                    Change_value(45);

                    Prev_Status = false;
                }
                Wind_velocity_for_rot = 8;
                Manager_audio.instance.Stop_Low_wind();
                Manager_audio.instance.Get_Strong_wind();
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                StopCoroutine(Alert_value());
                Value_Angle_pitch = 45;
                Change_graph_number(Data_velocity, 25);
                Value_Power = 2500;
                Change_graph_number(Data_power, Value_Power);
            }
            else if (BtnCount == 14)
            {
                //리미트 35
                Limit_angle = 35;
                init_angle_limit = 45;
                if (Prev_Status == true)
                {
                    ps.simulationSpeed = 4f;
                    emmisions.rateOverTime = 2f;
                    //object 복구
                    StopCoroutine(Alert_value());
                    wind_fast.SetActive(false);

                    //value 복구
                    Value_Angle_pitch = 45;
                    Change_graph_number(Data_velocity, 25);
                    Value_Power = 2500;
                    Change_graph_number(Data_power, Value_Power);
                    Wind_velocity_for_rot = 8;

                    Prev_Status = false;
                }

                Button_active_on(Add_button);
                Button_active_on(Reduce_button);
                Value_Power = 2500 - ((Value_Angle_pitch - 45) / 45) * 400;
                Change_graph_number(Data_power, Value_Power);
                Change_value(90);
                StartCoroutine(Alert_value());
            }
            else if (BtnCount == 15)
            {   //12m/s
                ps.simulationSpeed = 2f;
                emmisions.rateOverTime = 1f;
                if (Prev_Status == true)
                {
                    Change_value(90);

                    Prev_Status = false;
                }

                Manager_audio.instance.Stop_Strong_wind();
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                StopCoroutine(Alert_value());
                Value_Angle_pitch = 90;
                Change_graph_number(Data_velocity, 9);
                Value_Power = 700;
                Change_graph_number(Data_power, Value_Power);
                Wind_velocity_for_rot = 2;
            }
            else if (BtnCount == 16)
            {
                //12m/s
                //리미트 100
                Limit_angle = 100;
                init_angle_limit = 90;
                if (Prev_Status == true)
                {
                    //object 복구
                    StopCoroutine(Alert_value());
                    wind_fast.SetActive(false);

                    //value 복구
                    Value_Angle_pitch = 90;
                    Change_graph_number(Data_velocity, 9);
                    Value_Power = 700;
                    Change_graph_number(Data_power, Value_Power);
                    Wind_velocity_for_rot =2;
                    ps.simulationSpeed = 2f;
                    emmisions.rateOverTime = 1f;

                    Prev_Status = false;
                }

                Button_active_on(Add_button);
                Button_active_on(Reduce_button);
                Value_Power = 700 + ((90 - Value_Angle_pitch) / 60) * 1400;
                Change_graph_number(Data_power, Value_Power);
                Change_value(30);
                StartCoroutine(Alert_value());
            }
            else if (BtnCount == 17)
            {
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                StopCoroutine(Alert_value());
                Stop();
            }



            //이거 주석처리 잘 하기
            PC_Image_Array[BtnCount].SetActive(true);
            PostCount = BtnCount;
            flag = false;
            Debug.Log("FALSE");
        }

        //목표 요각도, 게이지  변경
        if (flag_num == true)
        {
            Value_Angle_pitch_target = Mathf.Lerp(Value_Angle_pitch_target, Value_max, 1.5f * Time.deltaTime);

            //Change_graph_number(Data_power, Value_Power);
            if (Value_Angle_pitch_target - Value_max <= 0.1 && Value_Angle_pitch_target - Value_max >= -0.1)
            {
                //Debug.Log("Done");
                flag_num = false;
            }
        }
    }

    //RPM 조절 얼마나 가까이 가느냐에 따라 회전속도를 조절해줄필요가 있음
    //목표 풍속에서 멀면 속도가 잠시 느려졋다가 제어하는것에 따라서 다시 빨라지게끔

    //강풍에서는 이전보다 더 빨랏다가 다시 평상시 속도로 바뀌게끔


    IEnumerator Startact()
    {
        yield return new WaitForSeconds(2.0f);
        Study_title_Intro_2.SetActive(true);
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(on)");
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
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
        else if (num == 0)
        {
            data.GetComponent<StreamingGraph>().min = 0;
            data.GetComponent<StreamingGraph>().max = 0;

        }
    }
    IEnumerator Animation_play(double num)
    {
        if (num == 0)
        {
            //인트로 off
            Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");
        }

        yield break;
    }
    IEnumerator Alert_value()
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
        Blade_1.GetComponent<Transform>().Rotate(new Vector3(0, 5, 0));
        Blade_2.GetComponent<Transform>().Rotate(new Vector3(0, 5, 0));
        Blade_3.GetComponent<Transform>().Rotate(new Vector3(0, 5, 0));
    }
    public void Rotate_blade_down()
    {
        Blade_1.GetComponent<Transform>().Rotate(new Vector3(0, -5, 0));
        Blade_2.GetComponent<Transform>().Rotate(new Vector3(0, -5, 0));
        Blade_3.GetComponent<Transform>().Rotate(new Vector3(0, -5, 0));
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
    IEnumerator Refresh_text_value()
    {
        while (true)
        {
            Angle_pitch_target.GetComponent<Text>().text = string.Format("{0:0}", Value_Angle_pitch_target);
            Angle_pitch.GetComponent<Text>().text = string.Format("{0:0}", Value_Angle_pitch);
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator Refresh_pin_value()
    {
        while (true)
        {
            Gauge_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, 0 - 100 * (Value_Power / 2100)));
            //Wind_direction_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, -Value_Angle_pitch));
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void Set_add_pitch()
    {

        //+가 비정상
        if (Limit_angle > init_angle_limit)
        {
            Debug.Log("+ 클릭 비정상");
            if (Value_Angle_pitch < Limit_angle)
            {
                Value_Angle_pitch += 5;
                Rotate_blade_up();
            }
            else if (Value_Angle_pitch < Limit_angle)
            {
                Debug.Log(" 제어 각도를 확인해주세요 메시지");
                //사운드 재생
            }
        }//+가 정상
        else if(Limit_angle <= init_angle_limit)
        {
            Value_Angle_pitch += 5;
            Rotate_blade_up();
        }

        Change_power_ws();
       
    }
    public void Set_reduce_pitch()
    {

        //30 -> 0 (40)      //-가 정상, 초기값보다 리미트가 큼
        //0 -> 45 (0)       //-가 비정상, 리미트랑 같거나 큼
        //45 -> 90 (35)     //-가 비정상, 리미트가 큼
        //90 -> 30 (100)    //-가 정상, 초기값보다 리미트가 큼

        //속도 1- 4 - 8
        //RPM  0     -100

        //10. 1, 1 - > 2
        //12. 4, 2 - > 4
        //12. 4, 2 - > 4
        //16. 2, 2 - > 4

        //이번에는 속도랑 RPM이랑 같이 가야함


        //-가 정상
        if (Limit_angle > init_angle_limit)
        {
            Value_Angle_pitch -= 5;
            Rotate_blade_down();
        }
        else if (Limit_angle <= init_angle_limit)
        {
            Debug.Log("- 클릭 비정상");
            if (Value_Angle_pitch > Limit_angle)
            {
                Value_Angle_pitch -= 5;
                Rotate_blade_down();
            }
            else if (Value_Angle_pitch == Limit_angle)
            {
                Debug.Log(" 제어 각도를 확인해주세요 메시지");
            }
        }
        Change_power_ws();
    }

    private void Change_power_ws()
    {
        if (BtnCount == 10)
        {
            Value_Power = 400 + ((30 - Value_Angle_pitch) / 30) * 600;
            Change_graph_number(Data_power, Value_Power);
            Wind_velocity_for_rot = 1 + ((30 - Value_Angle_pitch) / 30);
            //속도를 조절
            
        }
        else if (BtnCount == 12)
        {
            Value_Power = 1700 + ((Value_Angle_pitch) / 45) * 400;
            Change_graph_number(Data_power, Value_Power);
            Wind_velocity_for_rot = 2 + 2 * ((Value_Angle_pitch) / 45);
           
        }
        else if (BtnCount == 14)
        {
            Value_Power = 2500 - ((Value_Angle_pitch - 45) / 45) * 400;
            Change_graph_number(Data_power, Value_Power);
            Wind_velocity_for_rot = 8 - 4 * ((Value_Angle_pitch - 45) / 45);
            
        }
        else if (BtnCount == 16)
        {
            Value_Power = 700 + ((90 - Value_Angle_pitch) / 60) * 1400;
            Change_graph_number(Data_power, Value_Power);
            Wind_velocity_for_rot = 2 + 2 * ((90 - Value_Angle_pitch) / 60);
            
        }
        if (Mathf.Abs(Value_Angle_pitch_target - Value_Angle_pitch) <= 3)
        {
            gameObject.GetComponent<Script_controller>().NextBtn();
            Debug.Log("ACT");
        }
    }
    
    private void Button_active_off(GameObject obj)
    {
        obj.GetComponent<UI_button_2_1>().enabled = false;
        obj.GetComponent<UI_button_audio>().enabled = false;
    }
    private void Button_active_on(GameObject obj)
    {
        obj.GetComponent<UI_button_2_1>().enabled = true;
        obj.GetComponent<UI_button_audio>().enabled = false;
    }
    public void Stop()
    {
        Value_Angle_pitch = 0;
        Value_Angle_pitch_target = 0;
        Value_Velocity_wind = 0;
        Value_Power = 0;
        wind_slow.SetActive(false);
        Graph_velocity.SetActive(false);
        Graph_power.SetActive(false);
        Data_power.GetComponent<StreamingGraph>().min = 0;
        Data_power.GetComponent<StreamingGraph>().max = 0;
        Data_velocity.GetComponent<StreamingGraph>().min = 0;
        Data_velocity.GetComponent<StreamingGraph>().max = 0;
    }

    public void START()
    {
        wind_slow.SetActive(true);
        //Graph_velocity.SetActive(true);
        //Graph_power.SetActive(true);
    }
}
