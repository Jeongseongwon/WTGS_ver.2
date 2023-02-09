using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_TEXT_BUTTON : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //호버시 텍스트 볼드
    //호버시 이미지 색깔변경
    //클릭할 때 동작 설정
    private GameObject SceneController;
    public string SceneName;

    private Text Button_text;
    // Start is called before the first frame update
    void Start()
    {
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
        Button_text = this.transform.GetChild(0).gameObject.GetComponent<Text>();

    }
    private void LoadScene()
    {
        if (SceneName != null)
        {
            SceneManager.LoadSceneAsync(SceneName);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LoadScene();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button_text.fontStyle = FontStyle.Bold;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Button_text.fontStyle = FontStyle.Normal;
    }
}

