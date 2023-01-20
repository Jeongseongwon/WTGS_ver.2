using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_text_hover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //��ȭ�� ���׿��� ���� ��ũ��Ʈ
    //ȣ�� �� �ؽ�Ʈ  ����  �� ��ũ��Ʈ ��Ʈ�ѷ��� ������ ����
    //answer true = ����, false = ����
    //Evaluation ã��, child 0 : correct, child 1 : wrong �޽��� ��ġ
    private string Object_name;
    private GameObject SceneController;
    private GameObject Evaluation;

    public bool Answer;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Answer == true)
        {
            Evaluation.transform.GetChild(0).gameObject.GetComponent<Animation>().Play();
            //���� �ִϸ��̼� ���
            //��ũ��Ʈ ��Ʈ�ѷ� ������ ����
        }
        else if(Answer == false)
        {
            Evaluation.transform.GetChild(1).gameObject.GetComponent<Animation>().Play();
            //���� �ִϸ��̼� ���
            //��ũ��Ʈ ��Ʈ�ѷ� ������ ����
        }
        //SceneController. ������ ���� �� �޽��� �ִϸ��̼� ���

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Text>().fontStyle = FontStyle.Normal;
    }

    // Start is called before the first frame update
    void Start()
    {
        Object_name = this.gameObject.name;

        Evaluation = GameObject.Find("Evaluation");
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
    }
}
