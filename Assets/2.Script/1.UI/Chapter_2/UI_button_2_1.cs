using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_button_2_1 : MonoBehaviour, IPointerClickHandler
{
    private string Object_name;
    private GameObject SceneController;
    private string Scene_name;
    public void OnPointerClick(PointerEventData eventData)
    {
        //2_1에서 쓰는 버튼용 공용 스크립트 
        // 2_3에서 동일 기능하기 때문에 추가함
        //제어 +-, 시작, 정비 버튼용
        if (Scene_name == "(dev)Chapter_2_1")
        {
            if (Object_name == "Button_+")
            {
                SceneController.GetComponent<Scene_2_1_controller>().Set_add_pitch();
            }
            else if (Object_name == "Button_-")
            {
                SceneController.GetComponent<Scene_2_1_controller>().Set_reduce_pitch();
            }
            else if (Object_name == "Button_Stop")
            {
                SceneController.GetComponent<Scene_2_1_controller>().Stop();
            }
            else if (Object_name == "Button_Start")
            {
                SceneController.GetComponent<Script_controller>().NextBtn();
            }
        }
        else if (Scene_name == "(dev)Chapter_2_3")
        {
            if (Object_name == "Button_+")
            {
                SceneController.GetComponent<Scene_2_3_controller>().Set_add_pitch('p');
            }
            else if (Object_name == "Button_-")
            {
                SceneController.GetComponent<Scene_2_3_controller>().Set_reduce_pitch('p');
            }
            else if (Object_name == "Button_Stop")
            {
                SceneController.GetComponent<Scene_2_3_controller>().Stop();
            }
            else if (Object_name == "Button_Start")
            {
                SceneController.GetComponent<Script_controller>().NextBtn();
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Object_name = this.gameObject.name;
        
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
        Scene_name = SceneManager.GetActiveScene().name;
    }
}
