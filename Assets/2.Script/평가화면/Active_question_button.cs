using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Active_question_button : MonoBehaviour
{
    public GameObject top_study_position;
    public GameObject questions;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void  active_object_event()
    {
        foreach (Transform child in top_study_position.transform)
        {
            child.GetComponent<EventTrigger>().enabled = true;
        }
        foreach (Transform child in questions.transform)
        {
            child.GetComponent<EventTrigger>().enabled = true;
        }
    }

    public void inactive_object_event()
    {
        foreach (Transform child in top_study_position.transform)
        {
            child.GetComponent<EventTrigger>().enabled = false;
        }
        foreach (Transform child in questions.transform)
        {
            child.GetComponent<EventTrigger>().enabled = false;
        }
    }
}
