using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_text_hover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //��ȭ�� ���׿��� ���� ��ũ��Ʈ
    //ȣ�� �� �ؽ�Ʈ  ����  �� ��ũ��Ʈ ��Ʈ�ѷ��� ������ ����
    //answer true = ����, false = ����
    

    private GameObject SceneController;

    public bool Answer;
    private string Scene_name;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Answer == true)
        {
            //Evaluation.transform.GetChild(0).gameObject.GetComponent<Animation>().Play();
            if (Scene_name == "(dev)_Chapter_1_3")
            {
                SceneController.GetComponent<Scene_1_3_controller>().Clicked(true);
            }
            else if (Scene_name == "(dev)_Chapter_2_3")
            {
                SceneController.GetComponent<Scene_2_3_controller>().Clicked(true);
            }
            this.GetComponent<Text>().fontStyle = FontStyle.Bold;
            this.GetComponent<Text>().color = Color.yellow;
            Debug.Log("���� Ŭ��");
            //���� Ȱ��ȭ
        }
        else if(Answer == false)
        {
            //Evaluation.transform.GetChild(1).gameObject.GetComponent<Animation>().Play();
            if (Scene_name == "(dev)_Chapter_1_3")
            {
                SceneController.GetComponent<Scene_1_3_controller>().Clicked(false);
            }
            else if (Scene_name == "(dev)_Chapter_2_3")
            {
                SceneController.GetComponent<Scene_2_3_controller>().Clicked(false);
            }

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Text>().fontStyle = FontStyle.Bold;
        this.GetComponent<Text>().color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Text>().fontStyle = FontStyle.Normal;
        this.GetComponent<Text>().color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Evaluation = GameObject.Find("Evaluation");
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
        Scene_name = SceneManager.GetActiveScene().name;
    }
}
