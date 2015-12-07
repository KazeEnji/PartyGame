using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainBoardLocalManager : MonoBehaviour
{
    /// <summary>
    /// This is the local game manager. 
    /// Local managers are not held over after
    /// a level load.
    /// </summary>

    //Declare current player waypoints.
    [SerializeField] private GameObject p1CurrentWP;
    [SerializeField] private GameObject poolerLocation;
    [SerializeField] private GameObject player1Model;

    //Declare current player rolls.
    [SerializeField] private int p1Roll;

    //Declare path to follow.
    [SerializeField] private List<GameObject> pathList = new List<GameObject>();

    void Awake()
    {
        GameObject _tempPlayer1Model;

        _tempPlayer1Model = GameObject.FindGameObjectWithTag("UGM").GetComponent<UniversalGameManager>().GetP1Holder();

        player1Model = (GameObject)Instantiate(_tempPlayer1Model, poolerLocation.transform.position, poolerLocation.transform.rotation);
        player1Model.AddComponent<PlayerStatSystem>();
        player1Model.AddComponent<PlayerInventory>();
        player1Model.AddComponent<PlayerMoveBoardGame>();
        player1Model.name = "Player1";
        player1Model.tag = "Player1";
        player1Model.SetActive(true);
    }

	//Allows for the player to quit the game when built.
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.LoadLevel(3);
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
