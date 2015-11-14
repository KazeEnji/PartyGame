using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour 
{
    ///<summary>
    /// This whole script controls the behaviour of the waypoints.
    ///</summary>

    //Delcare surrounding waypoints.
    public GameObject forwardWP;
    public GameObject backWP;
    public GameObject leftWP;
    public GameObject rightWP;

    //Delcare surrounding buildings.
    private GameObject connectedBuilding;

    //Allows user to toggle Debug.DrawLine statements
    public bool rayFlag = false;

    //Declare private variable.
    private int waypointCount = 0;
    private int distanceToMove;
    private int rayLength = 50;
    private int waypointLayerMask = 1 << 8;

    //Raw List for the player to follow through the waypoints.
    private List<GameObject> pathList = new List<GameObject>();

    //Allows notification that this is the final waypoint in the line.
    private bool finalWP;

    private bool activeWP;

    //Declare the player variables
    private GameObject player1;

    //Declares the hit info variables for the raycasts.
    private RaycastHit hitForward;
    private RaycastHit hitBack;
    private RaycastHit hitLeft;
    private RaycastHit hitRight;

    //Direction of the raycasts.
    private Vector3 dirForward;
    private Vector3 dirBack;
    private Vector3 dirLeft;
    private Vector3 dirRight;

    void Awake()
    {
        //Grabs the angle to project the raycast along.
        dirForward = transform.TransformDirection(Vector3.forward);
        dirBack = transform.TransformDirection(-Vector3.forward);
        dirLeft = transform.TransformDirection(Vector3.left);
        dirRight = transform.TransformDirection(-Vector3.left);

        //Executes the discovery of the surrounding waypoints.
        Discovery();

        activeWP = true;
    }

	// Use this for initialization.
	void Start () 
    {
        //Sets player variable.
        player1 = GameObject.FindGameObjectWithTag("Player1");

        //Determine how many waypoints are connected to this one.
        if (forwardWP != null)
        {
            waypointCount++;
        }
        if (backWP != null)
        {
            waypointCount++;
        }
        if (leftWP != null)
        {
            waypointCount++;
        }
        if (rightWP != null)
        {
            waypointCount++;
        }
	}
	
	// Update is called once per frame.
	void Update () 
    {
        /* Draws lines in the editor to see distance of rays.
         * The rayFlag check allows for the lines to be turned
         * on and off.
         */
        if(rayFlag == true)
        {
            Debug.DrawRay(transform.position, dirForward * rayLength, Color.blue);
            Debug.DrawRay(transform.position, dirBack * rayLength, Color.red);
            Debug.DrawRay(transform.position, dirLeft * rayLength, Color.yellow);
            Debug.DrawRay(transform.position, dirRight * rayLength, Color.green);
        }

        //Draw lines in the editor to visually see connections.
        if (forwardWP != null)
        {
            Debug.DrawLine(transform.position, forwardWP.transform.position);
        }
        if (backWP != null)
        {
            Debug.DrawLine(transform.position, backWP.transform.position);
        }
        if (leftWP != null)
        {
            Debug.DrawLine(transform.position, leftWP.transform.position);
        }
        if (rightWP != null)
        {
            Debug.DrawLine(transform.position, rightWP.transform.position);
        }
	}

    private void Discovery()
    {
        //These 4 if statements discover if there are any surounding waypoints.
        if (Physics.Raycast(transform.position, dirForward, out hitForward, rayLength, waypointLayerMask))
        {
            if(hitForward.collider.gameObject.tag == "Waypoint")
            {
                forwardWP = hitForward.collider.gameObject;
            }
            else if(hitForward.collider.gameObject.tag == "ItemShop")
            {
                connectedBuilding = hitForward.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, dirBack, out hitBack, rayLength, waypointLayerMask))
        {
            if (hitBack.collider.gameObject.tag == "Waypoint")
            {
                backWP = hitBack.collider.gameObject;
            }
            else if (hitBack.collider.gameObject.tag == "ItemShop")
            {
                connectedBuilding = hitBack.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, dirLeft, out hitLeft, rayLength, waypointLayerMask))
        {
            if (hitLeft.collider.gameObject.tag == "Waypoint")
            {
                leftWP = hitLeft.collider.gameObject;
            }
            else if (hitLeft.collider.gameObject.tag == "ItemShop")
            {
                connectedBuilding = hitLeft.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, dirRight, out hitRight, rayLength, waypointLayerMask))
        {
            if (hitRight.collider.gameObject.tag == "Waypoint")
            {
                rightWP = hitRight.collider.gameObject;
            }
            else if (hitRight.collider.gameObject.tag == "ItemShop")
            {
                connectedBuilding = hitRight.collider.gameObject;
            }
        }
    }

    /* Method for calculating the distance around the map without a pathfinding
     * game object. The _dist variable is the remaining movement. The _source
     * variable is the waypoint that invoked this method. So when this waypoint
     * invokes this method in the surrounding waypoints, it will pass in itself.
     * This is to prevent the pathfinder from going between the same two
     * waypoints repeatedly and giving false movement data.
     */
    public void CalcDist(int _dist, GameObject _source, List<GameObject> _path)
    {
        /* Adds this gameobject to the list of waypointsto calculate the
         * proper path when the user clicks on it.
         */
        _path.Add(this.gameObject);

        //This prevents the player from clicking on this if it isn't an ending waypoint.
        finalWP = false;

        /* If this is the first waypoint in the chain, you need to add one
         * to the move distance. This must be executed BEFORE the if statement
         * looking for how many connected waypoints there are. If this doesn't
         * occur first, you'll be adding 1 to the distance every time you run
         * into a dead end. The other option is to add one to the original value
         * of the distance that's passed into this method prior to the method
         * being invoked but this seemed more logical.
         */
        if (_source == this.gameObject)
        {
            _dist++;
        }

        /* Determine if this is the last waypoing in the chain.
         * If it is, then switch the source game object so that
         * the pathfinding can continue back the way it came in
         * case there are more moves available.
         */
        if(waypointCount <= 1)
        {
            _source = this.gameObject;
        }

        //Determine if this is the final stop.
        if(_dist <= 1)
        {
            //Saves the current path list to the waypoint.
            pathList = _path;

            //This is the final waypoint in the chain.
            finalWP = true;

            //Blue signifies viable moves for the player.
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        //If this isn't the final stop, continue pathfinding.
        else
        {
            //Yellow signifies a registered move but not the end.
            this.GetComponent<Renderer>().material.color = Color.yellow;

            _dist -= 1;

            //Invoke this same method on the surrounding waypoints.
            if (forwardWP != null && _source != forwardWP)
            {
                forwardWP.GetComponent<Waypoints>().SetMoveDistance(distanceToMove);
                forwardWP.GetComponent<Waypoints>().CalcDist(_dist, this.gameObject, _path);
            }
            if (backWP != null && _source != backWP)
            {
                backWP.GetComponent<Waypoints>().SetMoveDistance(distanceToMove);
                backWP.GetComponent<Waypoints>().CalcDist(_dist, this.gameObject, _path);
            }
            if (leftWP != null && _source != leftWP)
            {
                leftWP.GetComponent<Waypoints>().SetMoveDistance(distanceToMove);
                leftWP.GetComponent<Waypoints>().CalcDist(_dist, this.gameObject, _path);
            }
            if (rightWP != null && _source != rightWP)
            {
                rightWP.GetComponent<Waypoints>().SetMoveDistance(distanceToMove);
                rightWP.GetComponent<Waypoints>().CalcDist(_dist, this.gameObject, _path);
            }
        }
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
        if(activeWP == true)
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
                player1.GetComponent<PlayerMoveBoardGame>().SetPathList(_editedPathList);

                //Tells the player to move.
                player1.GetComponent<PlayerMoveBoardGame>().MovePlayer1();

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
