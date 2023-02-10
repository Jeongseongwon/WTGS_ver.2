using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_box_act : MonoBehaviour
{
    public GameObject ErrorMsg;
    public AudioSource ErrorAudio;
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
            StartCoroutine(Message());
            //ErrorMsg.GetComponent<Animation>().Play("ErrorMessage");
            //ErrorAudio.PlayDelayed(0.5f);

        }
        //Debug.Log("Wrong");
    }
    IEnumerator Message(int num = 0)
    {
        ErrorMsg.SetActive(true);
        yield return new WaitForSeconds(2f);
        ErrorMsg.SetActive(false);
         yield break;
    }
}
