using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_2_controller : MonoBehaviour
{
    public GameObject[] PC_Image_Array;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Intro_2;
    int PostCount;

    private bool flag = false;
    private bool Prev_Status = false;

    // Start is called before the first frame update
    void Start()
    {
        PostCount = -1;
        //PC_Image_Array = PC_Image.gameObject.GetComponentsInChildren<Transform>();
        // PC_Image_Array = GameObject.FindGameObjectsWithTag("PC_Sprite");
        

        //Invoke("Startact", 2f);    // 5초 뒤에 해당 오브젝트 화면에 투사
        //Invoke("PC_ON", 10f);    // 5초 뒤에 해당 오브젝트 화면에 투사
    }
    private void Startact() //중간 평가용으로 수정
    {
        Intro_2.SetActive(true);
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
    }
    private void PC_ON()
    {
        Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");

        for (int i = 0; i < PC_Image_Array.Length; i++)
        {
            PC_Image_Array[i].gameObject.SetActive(false);
        }
        PC_Image_Array[0].gameObject.SetActive(true);
        
    }
    // Update is called once per frame
    void Update()
    {
        int BtnCount = gameObject.GetComponent<Script_controller>().btnCount;
        if (PostCount != BtnCount)
        {
            if (BtnCount < PostCount)
            {
                Prev_Status = true;
            }
            //PC_Image_Array[PostCount].gameObject.SetActive(false);
            flag = true;
        }

        if (flag == true)
        {

            if (BtnCount == 0)
            {
                Startact();
            }
            else if (BtnCount == 1)
            {
                Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");
                Debug.Log("check_2");

            }
            if (Prev_Status==true)
            {
                //이전 버튼 클릭시
                PC_Image_Array[BtnCount + 1].SetActive(false);
                Prev_Status = false;
            }

            if (BtnCount > 0)
            {
                PC_Image_Array[BtnCount - 1].SetActive(false);
            }
            PC_Image_Array[BtnCount].SetActive(true);
            PostCount = BtnCount;
            flag = false;
            Debug.Log("Image check");
        }
    }
}
