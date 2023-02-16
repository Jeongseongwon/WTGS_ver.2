using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_script_auto : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public bool on;
    private GameObject SceneController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (on == true)
            {
                Debug.Log("auto on");
                SceneController.GetComponent<Script_controller>().Script_auto_on();
            }else if (on == false)
            {
                Debug.Log("auto off");
                SceneController.GetComponent<Script_controller>().Script_auto_off();

            }
           
        }
    }
}
