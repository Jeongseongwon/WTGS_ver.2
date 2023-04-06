using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Script_controller : MonoBehaviour
{
    
    public int btnCount = 0;
    public string Scene_number; //해단 씬 스크립트 파일 불러오기 예)1_2

    public Text text;           //스크립트 나타는 박스
    //public GameObject TextPanel;  //애니메이션 용, 추가 필요 

    public bool FadeOut = false;
    GameObject Fader;



    float script_time_now;
    private float Time_limit;
    private bool status_UI_script_auto;


    private int Max_num_script=0;
    private int Num_script;

    public List<string> textList = new List<string>();
    public GameObject scene_controller;

    //평가하기 나레이션 삭제시 true
    public bool check_Narration_controller = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Scene_number != null)
        {
            Read_txt();
        }

        status_UI_script_auto = false;

        Time_limit = 15f;
        script_time_now = Time_limit;

    }

    // Update is called once per frame
    void Update()
    {
        if (status_UI_script_auto == true)
        {
            script_time_now -= Time.deltaTime;
            if (script_time_now < 0)
            {
                NextBtn();
                //Debug.Log("timer done");
            }
        }
    }

    public void NextBtn()
    {
        if (status_UI_script_auto == true)
        {
            Timer_set();
        }
        btnCount++;
        ScriptCount();

        if (check_Narration_controller == false)
        {
            this.GetComponent<Narration_controller>().EffectReset();
        }
        
       
    }
    public void PrevBtn()
    {
        if (status_UI_script_auto == true)
        {
            Timer_set();
        }
        if (btnCount > 0)
        {
            btnCount--;
        }
        ScriptCount();
        
    }
    public void ScriptCount()
    {
        if (btnCount >= Max_num_script)
        {
            if (Fader != null && FadeOut == true)
            {
                Fader.GetComponent<Fader>().FadeOut(1);
                Invoke("InvokeNextScene", 1f);
            }
            else
                this.GetComponent<Dual_scene_loader>().LoadNextScene();
        }
        else if (btnCount < 0)
        {
            
            //this.GetComponent<Dual_scene_loader>().LoadPrevScene();
        }
        else
        {
            Invoke("InvokeAct", 0.2f);
        }
    }
    void Timer_set()
    {
        script_time_now = Time_limit;
        Debug.Log("timer start" + script_time_now);
    }
     void Read_txt()
    {
        //TextAsset Script_file = Resources.Load(Scene_number) as TextAsset;
        TextAsset Script_file = Resources.Load<TextAsset>(Scene_number);
        StringReader sr = new StringReader(Script_file.text);
        textList.Clear();

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if(data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split('\n');
            for(int i = 0; i < data_values.Length; i++)
            {
                textList.Add(data_values[i]);                
                Max_num_script++;
                //Debug.Log(textList[i]);
            }
        }
        //첫번째 스크립트 텍스트 연결
        text.text = textList[0];
        //Debug.Log(Max_num_script);
    }

    void InvokeAct()
    {
        text.text = textList[btnCount];
    }
    void InvokeNextScene()
    {
        this.GetComponent<Dual_scene_loader>().LoadNextScene();
    }
    public void Script_auto_on()
    {
        status_UI_script_auto = true;
    }
    public void Script_auto_off()
    {
        status_UI_script_auto = false;
    }

}
