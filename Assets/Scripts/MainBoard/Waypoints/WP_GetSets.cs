﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class Waypoints : MonoBehaviour
{
    //Raw List for the player to follow through the waypoints.
    [SerializeField] private List<GameObject> pathList = new List<GameObject>();

    //Allows notification that this is the final waypoint in the line.
    [SerializeField] private bool finalWP;
    [SerializeField] private bool activeWP;

    //Declare the player variables
    [SerializeField] private GameObject player1;

    //Do all the things
    public void BeginWaypointCalculations(int _roll, GameObject _currentWP, List<GameObject> _pathList)
    {
        SetMoveDistance(_roll);
        SetActiveWP();
        CalcDist(_roll, _currentWP, _pathList);
    }

    public GameObject GetForwardWP()
    {
        return forwardWP;
    }

    public GameObject GetBackWP()
    {
        return backWP;
    }

    public GameObject GetRightWP()
    {
        return rightWP;
    }

    public GameObject GetLeftWP()
    {
        return leftWP;
    }

    public GameObject GetP1StagingSpot()
    {
        return p1StagingSpot;
    }

    public GameObject GetP2StagingSpot()
    {
        return p2StagingSpot;
    }

    public GameObject GetP3StagingSpot()
    {
        return p3StagingSpot;
    }

    public GameObject GetP4StagingSpot()
    {
        return p4StagingSpot;
    }

    //This method is simply to set the total movement rolled.
    public void SetMoveDistance(int _moveDistance)
    {
        distanceToMove = _moveDistance;
    }

    /* This whole method determines if the waypoint clicked is the final waypoint.
     * If it is, it's purpose is to trim the waypoint list down to just one single
     * movement path. In some instances, if you have a branching path, the list
     * will contain all the possible paths. By looping through the list only equal
     * to the movement roll, we cut out the unnecessary path.
     */

    public void OnMouseDown()
    {
        if (activeWP == true)
        {
            //Check if this is the final waypoint.
            if (finalWP == true)
            {
                //Make sure the loop starts at zero.
                int _count = 0;

                List<GameObject> _editedPathList = new List<GameObject>();

                //Begin to loop through the list to find where to trim it.
                foreach (GameObject _item in pathList)
                {
                    _count++;

                    /* Controls how far we loop through the list to trim it.
                     * This will capture all waypoints prior to the final
                     * waypoint.
                     */
                    if (_count <= distanceToMove)
                    {
                        _editedPathList.Add(_item);
                    }
                    else
                    {
                        break;
                    }
                }

                //Add the final waypoint to the end of the list so the player can actually move here.
                _editedPathList.Add(this.gameObject);

                //Returns the edited list back to the player to move through.
             //   player1.GetComponent<PlayerMoveBoardGame>().SetPathList(_editedPathList);

                //Tells the player to move.
             //   player1.GetComponent<PlayerMoveBoardGame>().MovePlayer1();

                activeWP = false;
            }
        }
    }

    //Returns the connected building if any.
    public GameObject GetConnectedBuilding()
    {
        return connectedBuilding;
    }

    public void SetActiveWP()
    {
        activeWP = true;
    }
}