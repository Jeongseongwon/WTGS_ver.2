using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;

public class Object_mouseover_withouthighlight : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Tooltip;
    public string Tooltip_text;

    void Start()
    {
        Tooltip = GameObject.FindGameObjectWithTag("Tooltip");
    }
    private void OnMouseEnter()
    {
        //Debug.Log(this.gameObject.name);
        Tooltip.transform.GetChild(0).gameObject.SetActive(true);
        Tooltip.GetComponent<Tooltip>().Change_text(Tooltip_text);
        this.gameObject.GetComponent<HighlightEffect>().highlighted = true;
    }

    private void OnMouseExit()
    {
        Tooltip.transform.GetChild(0).gameObject.SetActive(false);
        Tooltip.GetComponent<Tooltip>().Change_text(" ");
        this.gameObject.GetComponent<HighlightEffect>().highlighted = false;
        //this.gameObject.layer = 7;
    }
}
