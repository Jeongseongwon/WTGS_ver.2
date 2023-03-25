using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help_OBJ_controller : MonoBehaviour
{
    public GameObject MainOBJ;
    public Camera Camera;


    public float speed = 3f;
    public float minFov = 25f;
    public float maxFov = 70f;
    public float zOffset = 1f;

    float zoom = 0f;
    public float MouseX = 0f, MouseY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Camera.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {

        ScrollZoom();
        DragRotate();
        ClickPosition();
    }

    void DragRotate()
    {

        {
            if (Input.GetMouseButton(0))
            {
                MainOBJ.transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
                MainOBJ.transform.Rotate(Input.GetAxis("Mouse Y") * speed, 0f, 0f);
            }
        }
    }
    void ScrollZoom()
    {
        //float distance = Input.GetAxis("Mouse ScrollWheel") * (-5*speed);
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            zoom += 1f * Time.deltaTime * speed;
            Invoke("ZeroZoom", 0.5f);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            zoom -= 1f * Time.deltaTime * speed;
            Invoke("ZeroZoom", 0.5f);
        }

        if (Camera.fieldOfView < minFov)
            Camera.fieldOfView = minFov;
        else if (Camera.fieldOfView > maxFov)
            Camera.fieldOfView = maxFov;
        else
            Camera.fieldOfView += zoom;

    }
    void ClickPosition()
    {
        if (Input.GetMouseButton(2))
        {
            //Camera.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);
            Vector3 mousePosition = new Vector3(Input.mousePosition.x - (Screen.width / 2) - 200, Input.mousePosition.y - (Screen.height / 2) + 150, zOffset);
            Vector3 transPos = Camera.ScreenToWorldPoint(mousePosition);

            //Camera.ScreenToWorldPoint

            MainOBJ.transform.position = Vector3.Lerp(MainOBJ.transform.position, transPos, 3 * Time.deltaTime);
        }
    }
    void ZeroZoom()
    {
        zoom = 0;
    }
}
