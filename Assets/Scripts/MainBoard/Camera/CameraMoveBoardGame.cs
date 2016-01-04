using UnityEngine;
using System.Collections;

public partial class CameraMoveBoardGame : MonoBehaviour
{
    //Variables for moving and targetting.
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject currentWP;
    [SerializeField] private GameObject forwardWP, backWP, leftWP, rightWP;

    //Calculating screen size and when to start moving camera.
    [SerializeField] private float screenW;
    [SerializeField] private float screenH;
    [SerializeField] private float boundry = 50.0f;
    [SerializeField] private float speed = 25.0f;
    [SerializeField] private float camXOffset = 0.0f;
    [SerializeField] private float camYOffset = 15.0f;
    [SerializeField] private float camZOffset = -10.0f;

    //Variables for zooming the camera.
    [SerializeField] private float camSpeed = 10.0f;
    [SerializeField] private float camSmoothing = 1000.0f;

    [SerializeField] private Vector3 camTargetLocation;
    [SerializeField] private Vector3 camVelocity = Vector3.zero;

    //Changes between free movement and target tracking mode.
    [SerializeField] private bool freeMove = false;
    [SerializeField] private bool p1DPHInUseFlag = false;
    [SerializeField] private bool p1DPVInUseFlag = false;

    [SerializeField] private string p1DPH = "P1DPadHorizontal";
    [SerializeField] private string p1DPV = "P1DPadVertical";

    //Grabs current screen size.
    void Awake()
    {
        screenW = Screen.width;
        screenH = Screen.height;

        currentWP = GameObject.Find("Waypoint");
        target = currentWP;
        ReFocusTarget();
    }

    void FixedUpdate()
    {
        MoveCamScreenEdge();
        PanCamWithArrows();
        NavigateWaypointsWithController();
        ResetInputFlags();
    }

    private void MoveCamScreenEdge()
    {
        if (freeMove == true)
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

    private void ReFocusTarget()
    {
        if (freeMove == false)
        {
            this.transform.position = new Vector3(target.transform.position.x + camXOffset, target.transform.position.y + camYOffset, target.transform.position.z + camZOffset);

            GrabSurroundingWP();
        }
    }

    public void SetFreeMove(bool _state)
    {
        freeMove = _state;
    }
}
