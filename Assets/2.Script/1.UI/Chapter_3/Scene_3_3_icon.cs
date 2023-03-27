using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scene_3_3_icon : MonoBehaviour, IPointerClickHandler
{
    private GameObject SceneController;
    public bool Answer = false;
    //해당 스텝에서 클릭해야할 것은 True값으로 변경

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Answer == true)
        {
            SceneController.GetComponent<Script_controller>().NextBtn();
            SceneController.GetComponent<Scene_3_3_controller>().Clicked(true);
            Debug.Log("정답");

        }
        else if (Answer == false)
        {
            SceneController.GetComponent<Scene_3_3_controller>().Clicked(false);
        }
    }
    void Start()
    {
        //Evaluation = GameObject.Find("Evaluation");
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
    }
}
