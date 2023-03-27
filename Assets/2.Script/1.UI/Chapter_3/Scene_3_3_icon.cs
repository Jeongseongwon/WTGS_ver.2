using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scene_3_3_icon : MonoBehaviour, IPointerClickHandler
{
    private GameObject SceneController;
    public bool Answer = false;
    //�ش� ���ܿ��� Ŭ���ؾ��� ���� True������ ����

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Answer == true)
        {
            SceneController.GetComponent<Script_controller>().NextBtn();
            SceneController.GetComponent<Scene_3_3_controller>().Clicked(true);
            Debug.Log("����");

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
