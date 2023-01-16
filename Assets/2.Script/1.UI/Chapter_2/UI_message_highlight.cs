using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_message_highlight : MonoBehaviour

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

            if (c.a >= 1)
                pingPong = false;
        }
        else
        {
            c.a -= Time.deltaTime * 0.7f;
            if (c.a <= 0.4)
                pingPong = true;
        }

        c.a = Mathf.Clamp01(c.a);
        GetComponent<Image>().color = c;

    }

}
