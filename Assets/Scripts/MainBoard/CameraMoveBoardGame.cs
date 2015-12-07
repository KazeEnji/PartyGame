using UnityEngine;
using System.Collections;

public class CameraMoveBoardGame : MonoBehaviour
{
    //Variables for moving and targetting.
    public GameObject target;
    public GameObject mainCam;

    //Calculating screen size and when to start moving camera.
    private float screenW;
    private float screenH;
    private float boundry = 50.0f;
    private float speed = 25.0f;

    //Changes between free movement and target tracking mode.
    private bool freeMove = true;

    private float camXOffset = 0.0f;
    private float camYOffset = 15.0f;
    private float camZOffset = -10.0f;

    //Variables for zooming the camera.
    private float camSpeed = 10.0f;

    //Grabs current screen size.
    void Awake()
    {
        screenW = Screen.width;
        screenH = Screen.height;
    }

    //Moves camera.
    void Update()
    {
        if(freeMove == true)
        {
            //Move on +X axis.
            if (Input.mousePosition.x > screenW - boundry)
            {
                mainCam.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
            }

            //Move on -X axis.
            if (Input.mousePosition.x < 0 + boundry)
            {
                mainCam.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.World);
            }

            //Move on +Z axis.
            if (Input.mousePosition.y > screenH - boundry)
            {
                mainCam.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.World);
            }

            //Move on -Z axis.
            if (Input.mousePosition.y < 0 + boundry)
            {
                mainCam.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime), Space.World);
            }

            //Zooms camera.
            float _scroll = Input.GetAxis("Mouse ScrollWheel");
            mainCam.transform.Translate(0, 0, _scroll * camSpeed, Space.Self);
        }
    }

    void FixedUpdate()
    {
        if(freeMove == false)
        {
            this.transform.position = new Vector3(target.transform.position.x + camXOffset, target.transform.position.y + camYOffset, target.transform.position.z + camZOffset);
        }
    }

    public void SetFreeMove(bool _state)
    {
        freeMove = _state;
    }
}
