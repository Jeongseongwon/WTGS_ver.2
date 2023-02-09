using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timertonextpage : MonoBehaviour
{
    public float timercount;
    public GameObject nextpage;
    private float clock = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if (clock >= timercount)
        {
            gameObject.SetActive(false);
            nextpage.SetActive(true);
        }

    }
}
