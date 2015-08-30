using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    /// <summary>
    /// This is the local game manager. 
    /// Local managers are not held over after
    /// a level load.
    /// </summary>

    //Declare current player waypoints.
    public GameObject p1CurrentWP;

    //Declare current player rolls.
    private int p1Roll;

    //Declare path to follow.
    private List<GameObject> pathList = new List<GameObject>();

	//Allows for the player to quit the game when built.
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.LoadLevel(2);
        }
	}

    //Sets the move distance and begins the calculations for where the player can move.
    public void StartP1Move()
    {
        p1CurrentWP.GetComponent<Waypoints>().SetMoveDistance(p1Roll);
        p1CurrentWP.GetComponent<Waypoints>().SetActiveWP();
        p1CurrentWP.GetComponent<Waypoints>().CalcDist(p1Roll, p1CurrentWP, pathList);
    }

    //Allows the spinner to pass the roll to the player.
    public void SetP1Roll(int _passedRoll)
    {
        p1Roll = _passedRoll;
    }
}
