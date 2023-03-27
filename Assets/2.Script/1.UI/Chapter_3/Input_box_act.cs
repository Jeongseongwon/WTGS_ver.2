using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_box_act : MonoBehaviour
{
    public GameObject ErrorMsg;
    private GameObject SceneController;
    public string Check_value;
    // Start is called before the first frame update
    void Start()
    {
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");

    }

    public void Check()
    {
        if (gameObject.GetComponent<InputField>().text == Check_value)
            SceneController.GetComponent<Script_controller>().NextBtn();
        else
        {

            ErrorMsg.GetComponent<Animation>().Play();
            Manager_audio.instance.Error.PlayDelayed(0.5f);
        }
    }
}
