using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMoveBoardGame : MonoBehaviour 
{
    /*
    This script will need to do the following:
    1. Place the player at the beginning
    2. Allow the first player to move
    3. advance to the second player

    This will control the phases of the player. The phases are:
    1. PreMove - Manage inventory, spells, powerups, etc
    2. Rolling Dice
    3. Choosing space to move and moving there
    4. Engaging in the space event - battle, shop, random NPC event, story event, etc.
    */

    [SerializeField] private GameObject startingWP;

    [SerializeField] private GameObject currentWP;
    [SerializeField] private GameObject currentStagingSpot;

    [SerializeField] private GameObject mainCamera;

    [SerializeField] private string playerTag;

    [SerializeField] private Transform focusedWaypoint; 

    private void Awake()
    {
        InitializeOthers();
        AssignPlayerStagingSpot();
        RotatePlayerToDefault();
    }

    private void NavigateSpaces()
    {
        //Insert code to navigate through the board with a controller
    }

    #region Phase 1: PreMove

    //Test

    #endregion

    #region Player Organization and Management

    private void AssignPlayerStagingSpot()
    {
        switch (playerTag)
        {
            case "Player1":
                {
                    currentStagingSpot = currentWP.GetComponent<Waypoints>().GetP1StagingSpot();
                    break;
                }
            case "Player2":
                {
                    currentStagingSpot = currentWP.GetComponent<Waypoints>().GetP2StagingSpot();
                    break;
                }
            case "Player3":
                {
                    currentStagingSpot = currentWP.GetComponent<Waypoints>().GetP3StagingSpot();
                    break;
                }
            case "Player4":
                {
                    currentStagingSpot = currentWP.GetComponent<Waypoints>().GetP4StagingSpot();
                    break;
                }
        }
    }

    private void RotatePlayerToDefault()
    {
        this.transform.position = currentStagingSpot.transform.position;
        this.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    #endregion

    #region Initialization Methods

    private void InitializeOthers()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        playerTag = this.gameObject.tag;

        startingWP = GameObject.FindGameObjectWithTag("LGM").GetComponent<MainBoardLocalManager>().GetStartingWP();

        currentWP = startingWP;
    }

    #endregion
}
