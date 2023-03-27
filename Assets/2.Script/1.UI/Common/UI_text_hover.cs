using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_text_hover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //평가화면 문항에서 쓰는 스크립트
    //호버 시 텍스트  볼드  및 스크립트 컨트롤러로 데이터 저장
    //answer true = 정답, false = 오답
    

    private GameObject SceneController;

    public bool Answer;
    private string Scene_name;
    public int Q_num=0;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Answer == true)
        {
            //Evaluation.transform.GetChild(0).gameObject.GetComponent<Animation>().Play();
            if (Scene_name == "(dev)Chapter_1_3")
            {
                SceneController.GetComponent<Scene_1_3_controller>().Clicked(true);
            }
            else if (Scene_name == "(dev)Chapter_2_3")
            {
                SceneController.GetComponent<Scene_2_3_controller>().Clicked(true);
            }
            Manager_audio.instance.Get_Correct_answer();
            this.GetComponent<Text>().fontStyle = FontStyle.Bold;
            this.GetComponent<Text>().color = Color.yellow;
            Debug.Log("정답 클릭");
            //정답 활성화
        }
        else if(Answer == false)
        {
            //Evaluation.transform.GetChild(1).gameObject.GetComponent<Animation>().Play();
            if (Scene_name == "(dev)Chapter_1_3")
            {
                SceneController.GetComponent<Scene_1_3_controller>().Clicked(false);
                if(Q_num == 1)
                {
                    SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_1();
                }
                else if (Q_num == 2)
                {
                    SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_2();
                }
                else if (Q_num == 3)
                {
                    SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_3();
                }
                else if (Q_num == 4)
                {
                    SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_4();
                }
            }
            else if (Scene_name == "(dev)Chapter_2_3")
            {
                SceneController.GetComponent<Scene_2_3_controller>().Clicked(false);
            }
            Manager_audio.instance.Get_Wrong_answer();

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Text>().fontStyle = FontStyle.Bold;
        this.GetComponent<Text>().color = Color.yellow;
        if (Scene_name == "(dev)Chapter_1_3")
        {
            if (Q_num == 11)
            {
                SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_2_1();
            }
            else if (Q_num == 12)
            {
                SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_2_2();
            }
            else if (Q_num == 13)
            {
                SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_2_3();
            }
            else if (Q_num == 14)
            {
                SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_2_4();
            }
            else if (Q_num == 15)
            {
                SceneController.GetComponent<Scene_1_3_controller>().Q_hover_animation_2_5();
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Text>().fontStyle = FontStyle.Normal;
        this.GetComponent<Text>().color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Evaluation = GameObject.Find("Evaluation");
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
        Scene_name = SceneManager.GetActiveScene().name;
    }
}
