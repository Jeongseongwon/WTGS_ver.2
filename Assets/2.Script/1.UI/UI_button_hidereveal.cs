using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_hidereveal : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    /*
     * 2022.12.21
     * UI ��� �׺���̼ǹ� �����, ��Ÿ���� ���
     * ��ư Ŭ���� �ִϸ��̼� ��� �� ��Ÿ����, ����� ��ư Ȱ��ȭ
     * 
     */
    public GameObject Banner_movepanel;


    private bool UI_Move_End = false;
    private bool UI_Move_Hide = false;
    private bool UI_Move_Reveal = false;

    private bool flag = false;

    void Start()
    {
        if (this.gameObject.name == "UI_reveal_button")
        {
            flag = true;
        }
        else if (this.gameObject.name == "UI_hide_button")
        {
            flag = false;
        }

        //Manager_scene.instance.Checkvalue_Check_UI_hide();

        //bool status_UI_hide;
        //status_UI_hide = Manager_scene.instance.Status_Check_UI_hide();
        //if (status_UI_hide == true)
        //{
        //    Active_revealbutton();
        //}

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (flag == true)
        {
            //��Ÿ���� �ִϸ��̼�
            Banner_movepanel.GetComponent<Animation>().Play("TN_down");
        }

        if (flag == false)
        {
            //����� �ִϸ��̼�
            Banner_movepanel.GetComponent<Animation>().Play("TN_up");
        }
    }



    public void UI_Hide_func()
    {
        UI_Move_Hide = true;
       // UI_title.GetComponent<Animator>().enabled = false;
    }

    public void UI_Reveal_func()
    {
        UI_Move_Reveal = true;
       // UI_title.GetComponent<Animator>().enabled = false;
    }

}
