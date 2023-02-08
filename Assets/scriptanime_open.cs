using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptanime_open : MonoBehaviour
{
    public Animation bannerdown_open;

    public void animestart()
    {
        bannerdown_open.GetComponent<Animation>().Play("banner_o");
    }
}
