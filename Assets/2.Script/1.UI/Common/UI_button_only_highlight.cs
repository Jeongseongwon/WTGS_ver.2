using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_button_only_highlight : MonoBehaviour

{

   //��ư ���̶���Ʈ�� ��ũ��Ʈ
   //������ ���̶���Ʈ��
    bool pingPong = false;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        Color c = gameObject.GetComponent<Image>().color;
        if (pingPong)
        {
            c.a += Time.deltaTime * 0.7f;

            if (c.a >= 0.6)
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
   
}
