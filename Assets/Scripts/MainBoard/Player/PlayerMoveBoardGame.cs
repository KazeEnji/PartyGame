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
    [SerializeField] private GameObject mainCamera;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        startingWP = GameObject.FindGameObjectWithTag("LGM").GetComponent<MainBoardLocalManager>().GetStartingWP();

        this.transform.position = startingWP.transform.position;
        this.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void NavigateSpaces()
    {
        //Insert code to navigate through the board with a controller

    }
}
