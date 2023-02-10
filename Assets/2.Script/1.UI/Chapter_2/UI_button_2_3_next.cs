using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_button_2_3_next : MonoBehaviour, IPointerClickHandler
{
    //평가화면 문항 다음화면 버튼 스크립트
    //정답일 경우에만 다음으로 넘어가고 그 외에는 메시지만 출력


    private GameObject SceneController;
    private string Scene_name;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Scene_name == "(dev)Chapter_1_3")
        {
            bool answer = SceneController.GetComponent<Scene_1_3_controller>().Get_status_answer();
            if (answer == true)
            {
                SceneController.GetComponent<Scene_1_3_controller>().BtnCount_add();
            }
            else if (answer == false)
            {
                //정답을 클릭해달라고 메시지 띄우기
                Debug.Log("정답을 클릭해주세요");

            }
        }
        else if (Scene_name == "(dev)Chapter_2_3")
        {
            bool answer = SceneController.GetComponent<Scene_2_3_controller>().Get_status_answer();
            if (answer == true)
            {
                SceneController.GetComponent<Scene_2_3_controller>().BtnCount_add();
                Debug.Log("2_3next");

            }
            else if (answer == false)
            {
                //정답을 클릭해달라고 메시지 띄우기
                Debug.Log("정답을 클릭해주세요");

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Evaluation = GameObject.Find("Evaluation");
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
        Scene_name = SceneManager.GetActiveScene().name;
    }
}
