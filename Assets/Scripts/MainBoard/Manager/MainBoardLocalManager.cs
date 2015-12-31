using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private GameObject startingWP;
    [SerializeField] private GameObject dicePrefab, dice1, dice2;
    [SerializeField] private GameObject preMoveCanvas;

    //Declare current player rolls.
    [SerializeField] private int totalRolled;
    [SerializeField] private int numberOfReadyDice = 0;

    //Declare path to follow.
    [SerializeField] private List<GameObject> pathList = new List<GameObject>();
    [SerializeField] private List<int> diceValues = new List<int>();

    void Awake()
    {
        preMoveCanvas = GameObject.FindGameObjectWithTag("PreMoveCanvas");

        GameObject _tempPlayer1Model;

        _tempPlayer1Model = GameObject.FindGameObjectWithTag("UGM").GetComponent<UniversalGameManager>().GetP1Holder();

        player1Model = (GameObject)Instantiate(_tempPlayer1Model, poolerLocation.transform.position, poolerLocation.transform.rotation);
        player1Model.AddComponent<PlayerStatSystem>();
        player1Model.AddComponent<PlayerInventory>();
        player1Model.AddComponent<PlayerMoveBoardGame>();
        player1Model.name = "Player1";
        player1Model.tag = "Player1";
        player1Model.SetActive(true);

        dice1 = (GameObject)Instantiate(dicePrefab, poolerLocation.transform.position, poolerLocation.transform.rotation);
        dice1.name = "Dice1";
        dice1.SetActive(false);

        dice2 = (GameObject)Instantiate(dicePrefab, poolerLocation.transform.position, poolerLocation.transform.rotation);
        dice2.name = "Dice2";
        dice2.SetActive(false);
    }

	//Allows for the player to quit the game when built.
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(3);
        }
	}

    public void RollDice()
    {
        preMoveCanvas.SetActive(false);
        dice1.GetComponent<DiceStatus>().Roll();
        dice2.GetComponent<DiceStatus>().Roll();
    }

    public void SetDiceValueToList(int _value)
    {
        diceValues.Add(_value);

        numberOfReadyDice++;

        if(numberOfReadyDice == 2)
        {
            foreach (int _number in diceValues)
            {
                totalRolled += _number;
            }

            numberOfReadyDice = 0;

            StartMove();
        }
    }

    //Sets the move distance and begins the calculations for where the player can move.
    public void StartMove()
    {
        p1CurrentWP.GetComponent<Waypoints>().BeginWaypointCalculations(totalRolled, p1CurrentWP, pathList);
    }

    //Allows the spinner to pass the roll to the player.
    public void SetP1Roll(int _passedRoll)
    {
        totalRolled = _passedRoll;
    }

    public GameObject GetStartingWP()
    {
        return startingWP;
    }
}
