using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_panel_onoff : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    /*
     * 2023.03.24
     * 오브젝트 on off 기능
     * 클릭시 now obj 비활성화 후 next obj 활성화
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
