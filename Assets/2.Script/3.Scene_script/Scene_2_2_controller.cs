using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_2_2_controller : MonoBehaviour
{
    public GameObject PC_Image;
    public GameObject[] PC_Image_Array;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Study_title_Intro_2;

    //2-1 Gameobject
    [Header("===== Gameobject =====")]
    public GameObject Wind_particle;
    public GameObject Nacelle;
    public GameObject Arrow;
    public GameObject WTGS_Panel;
    public GameObject Camera;
    public GameObject Subcamera;
    public GameObject Subcamera_frame;


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
    public GameObject Wind_direction_pin;
    public GameObject Wind_direction_pin_target;
    public GameObject Add_button;
    public GameObject Reduce_button;
    public GameObject Object_2_blade_rotation;


    //2-1 Text
    [Header("===== Text =====")]
    public GameObject Angle_yaw_target;
    public GameObject Angle_yaw;
    public GameObject Velocity_wind;
    public GameObject Power;

    //Value
    private float Value_Angle_yaw;
    private float Value_Angle_yaw_target;
    private float Value_Velocity_wind;
    private float Value_Power;
    private int Limit_angle = 0;
    private int init_angle_limit = 0;
    public float Wind_velocity_for_rot;

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
        Value_Velocity_wind = 100;
        Value_Power = 100;

        StartCoroutine(Startact());
        Manager_audio.instance.Get_intro();
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
        //for (int i = 0; i < PC_Image_Array.Length; i++)
        //{
        //}
        if (flag == true)
        {
            if (BtnCount == 0)
            {


            }
            if (BtnCount == 1)
            {
                if (Prev_Status == true)
                {
                    Subcamera.SetActive(false);
                    WTGS_Panel.SetActive(false);
                    Debug.Log("check_2");
                    StopCoroutine(Refresh_text_value());
                    Prev_Status = false;
                }
                StartCoroutine(Intro_anim());
            }
            else if (BtnCount == 2)
            {
                //카메라 움직이는거, 옆에 패널 애니메이션 추가
                Camera.GetComponent<Animation>().Play("Camera_move(intro,2_1)");
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
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
                    //바꿔야할부분
                    Emergency.SetActive(false);

                    Wind_particle.SetActive(false);
                    Graph_velocity.SetActive(false);
                    Prev_Status = false;
                }
                Subcamera.SetActive(true);
                Subcamera_frame.SetActive(true);

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
                    StopCoroutine(Rotate_turbine());
                }
                Emergency.SetActive(true);

                Wind_particle.SetActive(true);
                Graph_velocity.SetActive(true);
                Change_graph_number(Data_velocity, 12);

            }
            else if (BtnCount == 8)
            {
                Wind_velocity_for_rot = 7;
                if (Prev_Status == true)
                {
                    //object 복구
                    Button_active_off(Add_button);
                    Button_active_off(Reduce_button);
                    StopCoroutine(Alert_value());

                    //value 복구

                    Value_Power = 0;
                    Change_graph_number(Data_power, Value_Power);

                    Change_value(0);
                    StopCoroutine(Alert_value());
                    Prev_Status = false;
                }
                StartCoroutine(Rotate_turbine());
                Green_button_1.SetActive(false);
                Green_button_2.SetActive(false);
                red_button_1.SetActive(true);
                red_button_2.SetActive(true);

                Graph_power.SetActive(true);
                Value_Power = 1800;
                Change_graph_number(Data_power, Value_Power);
                //StartCoroutine(Refresh_pin_value());

            }
            else if (BtnCount == 9)
            {
                Limit_angle = 0;
                init_angle_limit = 0;

                if (Prev_Status == true)
                {
                    //object 복구
                    StopCoroutine(Alert_value());

                    //value 복구
                    Value_Angle_yaw = 0;
                    Wind_velocity_for_rot = 7;
                    Prev_Status = false;
                }

                Button_active_on(Add_button);
                Button_active_on(Reduce_button);
                Value_Power = 1800 + ((Value_Angle_yaw) / 30) * 300;
                Change_graph_number(Data_power, Value_Power);
                Change_value(30);
                StartCoroutine(Alert_value());
            }
            else if (BtnCount == 10)
            {
                Wind_velocity_for_rot = 6;
                if (Prev_Status == true)
                {
                    //object 복구
                   
                    StopCoroutine(Alert_value());

                    //value 복구
                    Value_Power = 1800;
                    Change_graph_number(Data_power, Value_Power);

                    Change_value(30);
                    Prev_Status = false;
                }
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                //value 변경
                Value_Angle_yaw = 30;
                Value_Power = 1800 + ((Value_Angle_yaw) / 30) * 300;
                Change_graph_number(Data_power, Value_Power);
                StopCoroutine(Alert_value());
            }
            else if (BtnCount == 11)
            {

                Limit_angle = 20;
                init_angle_limit = 30;

                if (Prev_Status == true)
                {
                    Wind_velocity_for_rot = 6;
                    //value 복구
                    Value_Angle_yaw = 30;
                    Prev_Status = false;
                }
                Button_active_on(Add_button);
                Button_active_on(Reduce_button);
                Value_Angle_yaw = 30;
                Value_Power = 1500 + ((Value_Angle_yaw - 30) / 90) * 600;
                Change_graph_number(Data_power, Value_Power);
                Change_value(120);
                StartCoroutine(Alert_value());
            }
            else if (BtnCount == 12)
            {
                Wind_velocity_for_rot = 2;
                if (Prev_Status == true)
                { //object 복구
                    
                    StopCoroutine(Alert_value());

                    //value 복구
                    Value_Angle_yaw = 30;
                    Value_Power = 1500;
                    Change_graph_number(Data_power, Value_Power);

                    Change_value(120);

                    Prev_Status = false;
                }
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                //value 변경
                Value_Angle_yaw = 120;
                Value_Power = 1500 + ((Value_Angle_yaw - 30) / 90) * 600;
                Change_graph_number(Data_power, Value_Power);
            }
            else if (BtnCount == 13)
            {
                //여기서 프로그램 죽음

                Limit_angle = 110;
                init_angle_limit = 120;
                if (Prev_Status == true)
                {
                    //value 복구
                    Value_Angle_yaw = 120;
                    //object 복구
                    StopCoroutine(Alert_value());
                    Wind_velocity_for_rot = 2;
                    Prev_Status = false;
                }
                Button_active_on(Add_button);
                Button_active_on(Reduce_button);
                Value_Power = 600 + ((Value_Angle_yaw - 120) / 150) * 1500;
                Change_graph_number(Data_power, Value_Power);
                Change_value(270);
                StartCoroutine(Alert_value());
            }
            else if (BtnCount == 14)
            {
                Wind_velocity_for_rot = 4;
                if (Prev_Status == true)
                { //object 복구
                    
                    StopCoroutine(Alert_value());

                    //value 복구
                    Value_Angle_yaw = 120;
                    Value_Power = 600;
                    Change_graph_number(Data_power, Value_Power);

                    Change_value(270);

                    Prev_Status = false;
                }
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                //value 변경
                Value_Angle_yaw = 270;
                Value_Power = 600 + ((Value_Angle_yaw - 120) / 150) * 1500;
                Change_graph_number(Data_power, Value_Power);
            }
            else if (BtnCount == 15)
            {

                Limit_angle = 280;
                init_angle_limit = 270;
                if (Prev_Status == true)
                { 
                    Change_value(270);
                    Wind_velocity_for_rot = 4;
                    Prev_Status = false;
                }
                Button_active_on(Add_button);
                Button_active_on(Reduce_button);
                Value_Angle_yaw = 270;
                Value_Power = 1000 + ((270 - Value_Angle_yaw) / 270) * 1100;
                Change_graph_number(Data_power, Value_Power);
                Change_value(0);
                StartCoroutine(Alert_value());
            }
            else if (BtnCount == 16)
            {

                //value 변경
                Button_active_off(Add_button);
                Button_active_off(Reduce_button);
                Value_Angle_yaw = 0;
                Change_value(0);
                StartCoroutine(Alert_value());
                Stop();
            }
            PC_Image_Array[BtnCount].SetActive(true);
            PostCount = BtnCount;
            flag = false;
            Debug.Log("FALSE");
        }


        Gauge_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, 0 - 100 * (Value_Power / 2100)));
        Wind_direction_pin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, -Value_Angle_yaw));
        //목표 요각도, 풍향  변경
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

        //데이터 전용 타이머?
    }

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
    }

    IEnumerator Intro_anim()
    {
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");
        yield break;
    }

        IEnumerator Alert_value()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("coroutine run");
            //5초 정도 시간이 지나고 나면, 타이머 설정, 타이머 리셋
            //변경하지 않고 바꾸게 되면 다음으로 넘어가지 못 하도록?
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
        }
    }
    public void Rotate_blade_up()
    {
        Nacelle.GetComponent<Transform>().Rotate(new Vector3(0, 5, 0));
    }
    public void Rotate_blade_down()
    {
        Nacelle.GetComponent<Transform>().Rotate(new Vector3(0, -5, 0));
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
    IEnumerator Rotate_turbine()
    {
        //블레이드 회전, 1,2,3 일경우 해당 값 만큼 빠르게 회전
        while (true)
        {
            yield return new WaitForSeconds(0.03f);
            Object_2_blade_rotation.GetComponent<Transform>().Rotate(new Vector3(10 * Wind_velocity_for_rot * Time.deltaTime, 0, 0));
            Debug.Log("코루틴");
        }
        yield break;
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
        if (Limit_angle > init_angle_limit)
        {
            Debug.Log("+ 클릭 비정상");
            if (Value_Angle_yaw < Limit_angle)
            {
                Value_Angle_yaw += 10;
                Rotate_blade_up();
            }
            else if (Value_Angle_yaw < Limit_angle)
            {
                Debug.Log(" 제어 각도를 확인해주세요 메시지");
                //사운드 재생
            }
        }//+가 정상
        else if (Limit_angle <= init_angle_limit)
        {
            Value_Angle_yaw += 10;
            Rotate_blade_up();
        }
        Change_power_ws();
    }

    public void Set_reduce_pitch()
    {
        //-가 정상
        if (Limit_angle > init_angle_limit)
        {
            Value_Angle_yaw -= 10;
            Rotate_blade_down();
        }
        else if (Limit_angle <= init_angle_limit)
        {
            Debug.Log("- 클릭 비정상");
            if (Value_Angle_yaw > Limit_angle)
            {
                Value_Angle_yaw -= 10;
                Rotate_blade_down();
            }
            else if (Value_Angle_yaw == Limit_angle)
            {
                Debug.Log(" 제어 각도를 확인해주세요 메시지");
            }
        }
        Change_power_ws();

    }

    private void Change_power_ws()
    {
        if (BtnCount == 9)
        {

            Value_Power = 1900 + ((Value_Angle_yaw) / 30) * 200;
            Wind_velocity_for_rot = 7 +  ((Value_Angle_yaw) / 30);
            Change_graph_number(Data_power, Value_Power);
            if (Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) <= 3)
            {
                gameObject.GetComponent<Script_controller>().NextBtn();
            }
        }
        else if (BtnCount == 11)
        {

            Value_Power = 1500 + ((Value_Angle_yaw - 30) / 90) * 600;
            Wind_velocity_for_rot = 6 + 2* ((Value_Angle_yaw - 30) / 90);
            Change_graph_number(Data_power, Value_Power);
            if (Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) <= 3)
            {
                gameObject.GetComponent<Script_controller>().NextBtn();
            }
        }
        else if (BtnCount == 13)
        {

            Value_Power = 600 + ((Value_Angle_yaw - 120) / 150) * 1500;
            Wind_velocity_for_rot = 2 + 6* ((Value_Angle_yaw - 120) / 150);
            Change_graph_number(Data_power, Value_Power);
            if (Mathf.Abs(Value_Angle_yaw_target - Value_Angle_yaw) <= 3)
            {
                gameObject.GetComponent<Script_controller>().NextBtn();
            }
        }

        else if (BtnCount == 15)
        {
            Value_Power = 1000 + ((270 - Value_Angle_yaw) / 270) * 1100;
            Wind_velocity_for_rot = 4 + 4 * ((270 - Value_Angle_yaw) / 270);
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
