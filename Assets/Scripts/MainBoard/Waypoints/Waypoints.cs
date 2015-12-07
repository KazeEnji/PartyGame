using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class Waypoints : MonoBehaviour 
{
    //Delcare surrounding waypoints.
    [SerializeField] private GameObject forwardWP;
    [SerializeField] private GameObject backWP;
    [SerializeField] private GameObject leftWP;
    [SerializeField] private GameObject rightWP;

    //Delcare surrounding buildings.
    [SerializeField] private GameObject connectedBuilding;

    //Allows user to toggle Debug.DrawLine statements
    [SerializeField] private bool rayFlag = false;

    //Declare private variable.
    [SerializeField] private int rayLength = 50;
    [SerializeField] private int waypointLayerMask = 1 << 8;

    //Declares the hit info variables for the raycasts.
    [SerializeField] private RaycastHit hitForward;
    [SerializeField] private RaycastHit hitBack;
    [SerializeField] private RaycastHit hitLeft;
    [SerializeField] private RaycastHit hitRight;

    //Direction of the raycasts.
    [SerializeField] private Vector3 dirForward;
    [SerializeField] private Vector3 dirBack;
    [SerializeField] private Vector3 dirLeft;
    [SerializeField] private Vector3 dirRight;

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
}
