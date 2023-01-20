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
    //Evaluation 찾고, child 0 : correct, child 1 : wrong 메시지 배치
    private string Object_name;
    private GameObject SceneController;
    private GameObject Evaluation;

    public bool Answer;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Answer == true)
        {
            Evaluation.transform.GetChild(0).gameObject.GetComponent<Animation>().Play();
            //정답 애니메이션 재생
            //스크립트 컨트롤러 데이터 전송
        }
        else if(Answer == false)
        {
            Evaluation.transform.GetChild(1).gameObject.GetComponent<Animation>().Play();
            //오답 애니메이션 재생
            //스크립트 컨트롤러 데이터 전송
        }
        //SceneController. 데이터 전송 및 메시지 애니메이션 재생

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
