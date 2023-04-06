using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Input_box_act : MonoBehaviour
{
    public GameObject ErrorMsg;
    private GameObject SceneController;
    public string Check_value;
    private string Scene_name;
    // Start is called before the first frame update
    void Start()
    {
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
        Scene_name = SceneManager.GetActiveScene().name;

    }

    public void Check()
    {
        if (gameObject.GetComponent<InputField>().text == Check_value)
        {
            SceneController.GetComponent<Script_controller>().NextBtn();

            if (Scene_name == "(dev)Chapter_3_3")
            {
                SceneController.GetComponent<Scene_3_3_controller>().Clicked(true);
            }

        }
        else
        {
            ErrorMsg.GetComponent<Animation>().Play();
            Manager_audio.instance.Error.PlayDelayed(0.5f);
        }
    }
}
