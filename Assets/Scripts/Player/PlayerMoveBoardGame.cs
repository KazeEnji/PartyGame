using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMoveBoardGame : MonoBehaviour 
{
    //Variable to set the beginning waypoint of players.
    public GameObject startingWP;

    public GameObject movementCanvas;

    public GameObject mainCam;

    //Speed that the player moves.
    public float moveSpeed;

    //Path the player moves on.
    private List<GameObject> pathToMove = new List<GameObject>();

    //Current waypoint of the player.
    private GameObject currentWP;
    private GameObject currentBuilding;

    private GameObject localGameManager;

    void Awake()
    {
        localGameManager = GameObject.FindGameObjectWithTag("LocalGameManager");
    }

	//Sets original starting position of the player.
	void Start () 
    {
        transform.position = startingWP.transform.position;
        transform.rotation = Quaternion.Euler(0, 180, 0);
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            movementCanvas.SetActive(true);
        }
    }
	
    /* Begins the looping coroutine of moving
     * the player through the set of waypoints.
     */
	public void MovePlayer1()
    {
        mainCam.GetComponent<CameraMoveBoardGame>().SetFreeMove(false);
        StartCoroutine(MovePlayer1Coroutine());
    }

    //Allows for the player to grab the list needed to travel.
    public void SetPathList(List<GameObject> _path)
    {
        pathToMove = _path;
    }

    private void LookAround()
    {
        currentBuilding = currentWP.GetComponent<Waypoints>().GetConnectedBuilding();

        if(currentBuilding != null)
        {
            if(currentBuilding.gameObject.tag == "ItemShop")
            {
                localGameManager.GetComponent<ItemShop>().ShowShopCanvas();
            }
        }

        EndTurn();
    }

    private void EndTurn()
    {
        Debug.Log("Ending Player 1's turn.");
    }

    //Movement coroutine.
    IEnumerator MovePlayer1Coroutine()
    {
        //Loops through movement for each waypoint in the list.
        foreach(GameObject _item in pathToMove)
        {
            Vector3 _itemPos = _item.transform.position;

            while(Vector3.Distance(transform.position, _itemPos) > .0001)
            {
                //Looks at and moves towards the next waypoint in line.
                transform.LookAt(_itemPos);
                transform.position = Vector3.MoveTowards(transform.position, _itemPos, moveSpeed * Time.deltaTime);
                yield return null;
            }

            //Saves waypoint information as current waypoint.
            currentWP = _item;
        }
        //Ends the movement by looking back in the starting direction.
        transform.rotation = Quaternion.Euler(0, 180, 0);
        LookAround();
    }
}
