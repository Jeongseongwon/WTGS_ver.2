using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorHover : MonoBehaviour
{
    public Text text;
    public Image image;

    Color Text_OriginColor;
    Color Image_OriginColor;
    // Start is called before the first frame update
    void Start()
    {
        Image_OriginColor = image.color;
        Text_OriginColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enter()
    {
        text.color = new Color(1, 0.7f, 0, 1);
        image.color= new Color(0.1f, 0.3f, 0.5f, 1);
    }
    public void Exit()
    {
        text.color = Text_OriginColor;
        image.color = Image_OriginColor;
    }
}
