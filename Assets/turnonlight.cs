using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnonlight : MonoBehaviour
{
    public GameObject[] led;
    private float timeline = 0;
    private int resetcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        int randnum = Random.Range(0, 10);
        led[randnum].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timeline += Time.deltaTime;
        if(timeline>=1)
        {
            if(resetcount==4)
            {
                for(int i = 0; i <=9; i++)
                {
                    led[i].SetActive(false);
                }
            }   
            int randnum = Random.Range(0, 10);
            if (led[randnum].activeSelf == false)

            {
                led[randnum].SetActive(true);
                resetcount++;
                
            }
            timeline = 0;
        }
    }
}
