using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UI_button_help_hover : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler

{

    //버튼 하이라이트용 스크립트
    //오로지 하이라이트만
    bool pingPong = false;
    private GameObject guide;
    private bool Check_hover=false;
    private bool check = false;
    // Start is called before the first frame update

    private void Start()
    {
        guide = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Check_hover == false)
            {

                Color c = gameObject.GetComponent<Image>().color;
                if (pingPong)
                {
                    c.a += Time.deltaTime * 0.7f;

                    if (c.a >= 1)
                        pingPong = false;
                }
                else
                {
                    c.a -= Time.deltaTime * 0.7f;
                    if (c.a <= 0)
                        pingPong = true;
                }

                c.a = Mathf.Clamp01(c.a);
                GetComponent<Image>().color = c;
            }
            else if (Check_hover == true)
            {
                if(check == true)
                {
                    Color c = gameObject.GetComponent<Image>().color;
                    c.a = 1;
                    c.a = Mathf.Clamp01(c.a);
                    GetComponent<Image>().color = c;
                check = false;

                }
            }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Manager_audio.instance.Get_hover();
        guide.GetComponent<Animation>().Play("UI_Image_help_guide_on");
        Check_hover = true;
        check = true;
        Debug.Log("IN");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Check_hover = false;
        guide.GetComponent<Animation>().Play("UI_Image_help_guide_off");
        check = true;
        Debug.Log("OUT");
    }

}
