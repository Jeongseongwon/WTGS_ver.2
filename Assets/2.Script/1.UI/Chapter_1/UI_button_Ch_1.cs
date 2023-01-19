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
        //각 씬의 스크립트 컨트롤러를 로드를 해야함
    }


    public void OnPointerClick(PointerEventData eventData)
    {

        SceneController.GetComponent<Camera_movement>().Reset_1();

    }
}


