using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_Ch_1 : MonoBehaviour, IPointerClickHandler
{

    private GameObject SceneController;

    // Start is called before the first frame update
    void Start()
    {
        SceneController = GameObject.FindGameObjectWithTag("MainCamera");
        //�� ���� ��ũ��Ʈ ��Ʈ�ѷ��� �ε带 �ؾ���
    }


    public void OnPointerClick(PointerEventData eventData)
    {

        SceneController.GetComponent<Camera_movement>().Reset_1();

    }
}


