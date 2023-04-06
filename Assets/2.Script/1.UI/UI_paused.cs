using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UI_paused : MonoBehaviour, IPointerClickHandler
{
    public bool Paused = true;
    public bool Closed = false;
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //if (Closed == true)
            //{
            //    //Manager_scene.instance.Paused_on();
            //}
            //else if (Paused == false)
            //{
            //    //Manager_scene.instance.Paused_off();

            //}


            if (camera.GetComponent<Camera_movement>())
            {
                if (Closed == true)
                {
                    //Debug.Log("ī�޶� ���콺 �ٽ� Ȱ��ȭ");
                    camera.GetComponent<Camera_movement>().check_meunu_disabled();
                }else if (Closed == false)
                {//ī�޶� ���콺 ��Ȱ��ȭ
                    camera.GetComponent<Camera_movement>().check_meunu_enabled();
                }
            }
        }
    }
}
