using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_panel_onoff : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    /*
     * 2023.03.24
     * ������Ʈ on off ���
     * Ŭ���� now obj ��Ȱ��ȭ �� next obj Ȱ��ȭ
     */
    public GameObject Now_obj;
    public GameObject Next_obj;

    private bool flag = false;

    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Now_obj.SetActive(false);
        Next_obj.SetActive(true);
    }



}
