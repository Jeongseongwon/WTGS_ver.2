using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_text_hover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //평가화면 문항에서 쓰는 스크립트
    //호버 시 텍스트  볼드  및 스크립트 컨트롤러로 데이터 저장
    //answer true = 정답, false = 오답
    

    private GameObject SceneController;
    private GameObject Evaluation;

    public bool Answer;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Answer == true)
        {
            //Evaluation.transform.GetChild(0).gameObject.GetComponent<Animation>().Play();

            SceneController.GetComponent<Scene_1_3_controller>().Clicked(true);
            Debug.Log("정답 클릭");
            //정답 활성화
        }
        else if(Answer == false)
        {
            //Evaluation.transform.GetChild(1).gameObject.GetComponent<Animation>().Play();

            SceneController.GetComponent<Scene_1_3_controller>().Clicked(false);

           
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
    }
}
