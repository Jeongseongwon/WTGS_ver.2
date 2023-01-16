using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_button_2_1 : MonoBehaviour, IPointerClickHandler
{
    private string Object_name;
    private GameObject SceneController;
    public void OnPointerClick(PointerEventData eventData)
    {
        //2_1에서 쓰는 버튼용 공용 스크립트
        //제어 +-, 시작, 정비 버튼용

        if (Object_name == "Button_+")
        {
            SceneController.GetComponent<Scene_2_1_controller>().Set_add_pitch();
            SceneController.GetComponent<Scene_2_1_controller>().Rotate_blade_up();
            Debug.Log("이거");
        }
        else if (Object_name == "Button_-")
        {
            SceneController.GetComponent<Scene_2_1_controller>().Set_reduce_pitch();
            SceneController.GetComponent<Scene_2_1_controller>().Rotate_blade_down();
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

    // Start is called before the first frame update
    void Start()
    {
        Object_name = this.gameObject.name;
        
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
    }
}
