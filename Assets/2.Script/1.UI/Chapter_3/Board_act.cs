using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_act : MonoBehaviour
{

    //���������� ������Ʈ Ȱ��ȭ
    // obj 0 Ȱ��ȭ ���·� �غ�
    // obj 1 ��Ȱ��ȭ
    // obj 2 ��Ȱ��ȭ
    //
    // ���� ����
    // 0 ��Ȱ/ 1Ȱ��ȭ
    // 1 ��Ȱ/ 2Ȱ��ȭ
    //

    public GameObject[] Frame_text_set;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(Act());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Act()
    {
        for (int i=0;i< Frame_text_set.Length-1;i++)
        {
            yield return new WaitForSeconds(3.0f);
            //��ȯ �ϱ� ���ؼ� ���
            Frame_text_set[i].SetActive(false);
            Frame_text_set[i+1].SetActive(true);
            Debug.Log(i);
        }
        yield break;

    }
    //�����ϸ� ������ ������ ���̵�ƿ����� �������



}
