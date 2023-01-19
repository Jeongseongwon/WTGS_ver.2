using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMenu : MonoBehaviour
{

    public GameObject quizPanel;
    
    public Text quizNumText;
    public int quizNum;

    public Text quizText;
    public string questionText;

    public List<string> textList = new List<string>();
    public Text chooseText1;
    public Text chooseText2;
    public Text chooseText3;
    public Text chooseText4;

    public int answerNum;
    public int chooseNum;

    public GameObject correctScreen;
    public GameObject wrongScreen;

    // Start is called before the first frame update
    void Start()
    {
        quizNumText.text = quizNum.ToString();
        if(quizNum==1)
        {
            Invoke("PanelEnable", 3.5f);
        }
        quizText.text = questionText;

        chooseText1.text = textList[0];
        chooseText2.text = textList[1];
        chooseText3.text = textList[2];
        chooseText4.text = textList[3];

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void CheckAnswer(int chooseNum)
    {
        if (chooseNum == answerNum)
        {
            Debug.Log("정답입니다");
            correctScreen.SetActive(true);
        }
        else
        {
            Debug.Log("오답입니다");
            wrongScreen.SetActive(true);
        }
            
    }
    void PanelEnable()
    {
        if(quizPanel!=null)
        quizPanel.SetActive(true);
    }
}
