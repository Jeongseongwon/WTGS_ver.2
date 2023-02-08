using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_act : MonoBehaviour
{

    //순차적으로 오브젝트 활성화
    // obj 0 활성화 상태로 준비
    // obj 1 비활성화
    // obj 2 비활성화
    //
    // 진행 순서
    // 0 비활/ 1활성화
    // 1 비활/ 2활성화
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
            //전환 하기 위해서 사용
            Frame_text_set[i].SetActive(false);
            Frame_text_set[i+1].SetActive(true);
            Debug.Log(i);
        }
        yield break;

    }
    //가능하면 마지막 설정은 페이드아웃으로 사라지기



}
