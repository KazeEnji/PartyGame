using UnityEngine;
using System.Collections;

public partial class CameraMoveBoardGame : MonoBehaviour
{
    private void PanCamWithArrows()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mainCam.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mainCam.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mainCam.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mainCam.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime), Space.World);
        }
    }

    //Flips the flag to allow the player to press the button again for input.
    private void ResetInputFlags()
    {
        if(Input.GetAxis(p1DPH) == 0)
        {
            p1DPHInUseFlag = false;
        }
        if(Input.GetAxis(p1DPV) == 0)
        {
            p1DPVInUseFlag = false;
        }
    }

    private void GrabSurroundingWP()
    {
        forwardWP = currentWP.GetComponent<Waypoints>().GetForwardWP();
        backWP = currentWP.GetComponent<Waypoints>().GetBackWP();
        leftWP = currentWP.GetComponent<Waypoints>().GetLeftWP();
        rightWP = currentWP.GetComponent<Waypoints>().GetRightWP();
    }
    
    private void NavigateWaypointsWithController()
    {
        if (Input.GetAxis(p1DPH) == 1 && p1DPHInUseFlag == false && rightWP != null)
        {
            p1DPHInUseFlag = true;

            //Move to the right waypoint if there is one
            target = rightWP;
            currentWP = target;
            ReFocusTarget();
        }
        else if (Input.GetAxis(p1DPH) == 1 && p1DPHInUseFlag == false && rightWP == null)
        {
            Debug.Log("There's no waypoint that way. Play sound here.");
        }

        if (Input.GetAxis(p1DPH) == -1 && p1DPHInUseFlag == false && leftWP != null)
        {
            p1DPHInUseFlag = true;

            //Move to the left waypoint if there is one
            target = leftWP;
            currentWP = target;
            ReFocusTarget();
        }
        else if (Input.GetAxis(p1DPH) == 1 && p1DPHInUseFlag == false && leftWP == null)
        {
            Debug.Log("There's no waypoint that way. Play sound here.");
        }

        if (Input.GetAxis(p1DPV) == 1 && p1DPVInUseFlag == false && forwardWP != null)
        {
            p1DPVInUseFlag = true;

            //Move to the forward waypoint if there is one
            target = forwardWP;
            currentWP = target;
            ReFocusTarget();
        }
        else if (Input.GetAxis(p1DPV) == 1 && p1DPVInUseFlag == false && forwardWP == null)
        {
            Debug.Log("There's no waypoint that way. Play sound here.");
        }

        if (Input.GetAxis(p1DPV) == -1 && p1DPVInUseFlag == false && backWP != null)
        {
            p1DPVInUseFlag = true;

            //Move to the back waypoint if there is one
            target = backWP;
            currentWP = target;
            ReFocusTarget();
        }
        else if (Input.GetAxis(p1DPV) == -1 && p1DPVInUseFlag == false && backWP == null)
        {
            Debug.Log("There's no waypoint that way. Play sound here.");
        }
    }
}