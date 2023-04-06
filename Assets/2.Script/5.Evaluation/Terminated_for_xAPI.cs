using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Terminated_for_xAPI : MonoBehaviour, IPointerClickHandler
{
    private GameObject SceneController;
    private string Scene_name;
    private bool Check_xAPI = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        //평가하기에서 쓰는 xAPI terminated 예외처리용
        //평가 정상 종료 하지 않는 예외처리
        //전체메뉴, 다른 씬이동 버튼용
        if (Check_xAPI==true)
        {
            if (Scene_name == "(dev)Chapter_1_3")
            {
                int btncount = SceneController.GetComponent<Scene_1_3_controller>().BtnCount;
                if (btncount < 5)
                {
                    SceneController.GetComponent<Scene_1_3_controller>().Send_Terminated_statement_unfinished();
                }
            }
            else if (Scene_name == "(dev)Chapter_2_3")
            {
                int btncount = SceneController.GetComponent<Script_controller>().btnCount;
                if (btncount < 8)
                {
                    SceneController.GetComponent<Scene_2_3_controller>().Send_Terminated_statement_unfinished();
                }
            }
            else if (Scene_name == "(dev)Chapter_3_3")
            {
                int btncount = SceneController.GetComponent<Script_controller>().btnCount;
                if (btncount < 14)
                {
                    SceneController.GetComponent<Scene_3_3_controller>().Send_Terminated_statement_unfinished();
                }
            }

        }

    }

    void Start()
    {
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
        Scene_name = SceneManager.GetActiveScene().name; if (GameObject.Find("xAPIObject"))
        {
            Check_xAPI = true;
        }
    }
}
