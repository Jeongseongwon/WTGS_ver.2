using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_button_2_3_next : MonoBehaviour, IPointerClickHandler
{
    //��ȭ�� ���� ����ȭ�� ��ư ��ũ��Ʈ
    //������ ��쿡�� �������� �Ѿ�� �� �ܿ��� �޽����� ���


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
                //������ Ŭ���ش޶�� �޽��� ����
                Debug.Log("������ Ŭ�����ּ���");

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
                //������ Ŭ���ش޶�� �޽��� ����
                Debug.Log("������ Ŭ�����ּ���");

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
