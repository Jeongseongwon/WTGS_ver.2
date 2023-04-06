using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicSetting : MonoBehaviour
{
    public GameObject Dial;
    // Start is called before the first frame update
    public void AutoGraphic()
    {
        Dial.transform.rotation = Quaternion.Euler(0, 0, 0);
        QualitySettings.SetQualityLevel(5, true);
    }
    public void LowGraphic()
    {
        Dial.transform.rotation = Quaternion.Euler(0, 0, -70);
        QualitySettings.SetQualityLevel(0, true);
    }
    public void MedGraphic()
    {
        Dial.transform.rotation = Quaternion.Euler(0, 0, -180);
        QualitySettings.SetQualityLevel(2, true);
    }
    public void HighGraphic()
    {
        Dial.transform.rotation = Quaternion.Euler(0, 0, -250);
        QualitySettings.SetQualityLevel(4, true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
