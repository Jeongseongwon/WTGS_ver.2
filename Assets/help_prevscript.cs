using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class help_prevscript : MonoBehaviour, IPointerClickHandler
{
    public Text texthover;

    public GameObject getscript;

    public GameObject page_one;
    public GameObject page_two;
    public GameObject page_three;
    public GameObject page_four;
    private int prenum = 0;

    public void OnPointerClick(PointerEventData eventData)
    {

        if (prenum == 1)
        {
            texthover.text = "1번내용";
            getscript.GetComponent<Help_page>().page1();
          

        }
        else if (prenum == 2)
        {
            
            texthover.text = "2번내용";
            getscript.GetComponent<Help_page>().page2();
           
        }
        else if (prenum == 3)
        {
           
            texthover.text = "3번내용";
            getscript.GetComponent<Help_page>().page3();
           
        }
        else if (prenum == 4)
        {
            
            texthover.text = "4번내용";
            getscript.GetComponent<Help_page>().page4();
            
        }

    }
    public void numcheck()
    {
        prenum++;
        print(prenum);
    }
}
