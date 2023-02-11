using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_button_active : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
