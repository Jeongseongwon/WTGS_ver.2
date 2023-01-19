using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Navigation_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("=============== UI title configuration ===============")]
    public string UI_title_color_Enter;
    public string UI_title_color_Exit;
    public string UI_Scene_name;

    private Animator UI_Animator;

    [Header("=============== Popup object, object text ===============")]
    public GameObject Message;
    public GameObject Object_Text;

    

    void Start()
    {
        UI_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Title_Start()
    {
        UI_Animator.SetBool("Exit_check", true);
    }
    public void Title_End()
    {
        UI_Animator.SetBool("Exit_check",false);
    }

    public void Change_Word_Color_Enter()
    {
        Object_Text.GetComponent<Text>().text = UI_title_color_Enter;
    }

    public void Change_Word_Color_Exit()
    {
        Object_Text.GetComponent<Text>().text = UI_title_color_Exit;
    }

    public void Popup_Message()
    {
        Message.SetActive(true);
    }

    public void Change_Scene()
    {
        //해당하는 씬 바꾸기
        SceneManager.LoadScene(UI_Scene_name);
    }
}
