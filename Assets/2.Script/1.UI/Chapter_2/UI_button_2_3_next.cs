using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_button_2_3_next : MonoBehaviour, IPointerClickHandler
{
    //��ȭ�� ���� ����ȭ�� ��ũ��Ʈ
    //������ ��쿡�� �������� �Ѿ�� �� �ܿ��� �޽����� ���


    private GameObject SceneController;
    public void OnPointerClick(PointerEventData eventData)
    {
        bool answer = SceneController.GetComponent<Scene_1_3_controller>().Get_status_answer();
        if (answer == true)
        {
            SceneController.GetComponent<Scene_1_3_controller>().BtnCount_add();
        }
        else if (answer == false)
        {
            //������ Ŭ���ش޶�� �޽��� ����
            Debug.Log("������ Ŭ�����ּ���");

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Evaluation = GameObject.Find("Evaluation");
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
    }
}
