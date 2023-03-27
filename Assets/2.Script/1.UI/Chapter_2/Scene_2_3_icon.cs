using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scene_2_3_icon : MonoBehaviour, IPointerClickHandler
{
    private GameObject SceneController;
    public bool Answer = false;
    private string Object_name;
    //해당 스텝에서 클릭해야할 것은 True값으로 변경

    //btncount 2, 3번에 각각 시작, 브레이크 버튼
    public void OnPointerClick(PointerEventData eventData)
    {
        int btncount = SceneController.GetComponent<Script_controller>().btnCount;
        if (btncount == 3)
        {
            if (Object_name == "Green_button_1")
            {
                SceneController.GetComponent<Script_controller>().NextBtn();
                SceneController.GetComponent<Scene_2_3_controller>().Clicked(true);
            }
            else if (Object_name == "Green_button_2")
            {
                SceneController.GetComponent<Script_controller>().NextBtn();
                SceneController.GetComponent<Scene_2_3_controller>().Clicked(true);
            }
            else 
            {
                SceneController.GetComponent<Scene_2_3_controller>().Clicked(false);
            }
        }
        else if (btncount == 2)
        {
            if (Object_name == "Button_Start")
            {
                SceneController.GetComponent<Scene_2_3_controller>().Clicked(true);
                SceneController.GetComponent<Script_controller>().NextBtn();

            }else
            {
              SceneController.GetComponent<Scene_2_3_controller>().Clicked(false);
            }
        }
    }
    void Start()
    {
        Object_name = this.gameObject.name;
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
    }
}
