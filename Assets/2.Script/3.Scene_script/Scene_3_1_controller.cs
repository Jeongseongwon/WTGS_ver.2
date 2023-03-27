using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_1_controller : MonoBehaviour
{
    public GameObject[] PC_Image_Array;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Intro_2;
    int PostCount;

    private bool flag = false;
    private bool Prev_Status = false;
    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        PostCount = -1;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
   
    IEnumerator Startact()
    {
        camera.GetComponent<Animation>().Play();
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        yield return new WaitForSeconds(2f);
        Intro_2.SetActive(true);
        yield return new WaitForSeconds(2f);
        yield break;
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

            Scriptbox.GetComponent<Animation>().Play("banner_o");
            if (BtnCount == 0)
            {
                StartCoroutine(Startact());
            }
            if (BtnCount == 1)
            {
                Intro_2.SetActive(false);
            }
            if (Prev_Status==true)
            {
                //이전 버튼 클릭시
                PC_Image_Array[BtnCount + 1].SetActive(false);
                Prev_Status = false;
            }

            if (BtnCount > 0)
            {
                //첫 번째 이미지는 애니메이션 재생?
                PC_Image_Array[BtnCount - 1].SetActive(false);
                PC_Image_Array[BtnCount].SetActive(true);
            }
            PostCount = BtnCount;
            flag = false;
            //Debug.Log("Image check");
        }
    }
}
