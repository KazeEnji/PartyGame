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
    [SerializeField] private GameObject startingWP;
    [SerializeField] private GameObject dicePrefab, dice1, dice2;
    [SerializeField] private GameObject preMoveCanvas;
    [SerializeField] private GameObject universalGM;

    [Header("Player Models")]
    [SerializeField] private GameObject player1Model;
    [SerializeField] private GameObject player2Model;
    [SerializeField] private GameObject player3Model;
    [SerializeField] private GameObject player4Model;

    //Declare current player rolls.
    [SerializeField] private int totalRolled;
    [SerializeField] private int numberOfReadyDice = 0;
    [SerializeField] private int totalNumberOfPlayers = 0;

    //Declare path to follow.
    [SerializeField] private List<GameObject> pathList = new List<GameObject>();
    [SerializeField] private List<int> diceValues = new List<int>();

    void Awake()
    {
        preMoveCanvas = GameObject.FindGameObjectWithTag("PreMoveCanvas");
        universalGM = GameObject.FindGameObjectWithTag("UGM");

        totalNumberOfPlayers = universalGM.GetComponent<UniversalGameManager>().GetNumberOfPlayers();

        switch (totalNumberOfPlayers)
        {
            case 0:
                {
                    Debug.Log("Error: No players present");
                    break;
                }
            case 1:
                {
                    GameObject _tempPlayerModel;

                    //Alter loading of assest for multiple players
                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP1Holder();

                    player1Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player1Model.AddComponent<PlayerStatSystem>();
                    player1Model.AddComponent<PlayerInventory>();
                    player1Model.AddComponent<PlayerMoveBoardGame>();
                    player1Model.name = "Player1";
                    player1Model.tag = "Player1";
                    player1Model.SetActive(true);
                    break;
                }
            case 2:
                {
                    GameObject _tempPlayerModel;

                    //Alter loading of assest for multiple players
                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP1Holder();

                    player1Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player1Model.AddComponent<PlayerStatSystem>();
                    player1Model.AddComponent<PlayerInventory>();
                    player1Model.AddComponent<PlayerMoveBoardGame>();
                    player1Model.name = "Player1";
                    player1Model.tag = "Player1";
                    player1Model.SetActive(true);

                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP2Holder();

                    player2Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player2Model.AddComponent<PlayerStatSystem>();
                    player2Model.AddComponent<PlayerInventory>();
                    player2Model.AddComponent<PlayerMoveBoardGame>();
                    player2Model.name = "Player2";
                    player2Model.tag = "Player2";
                    player2Model.SetActive(true);
                    break;
                }
            case 3:
                {
                    GameObject _tempPlayerModel;

                    //Alter loading of assest for multiple players
                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP1Holder();

                    player1Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player1Model.AddComponent<PlayerStatSystem>();
                    player1Model.AddComponent<PlayerInventory>();
                    player1Model.AddComponent<PlayerMoveBoardGame>();
                    player1Model.name = "Player1";
                    player1Model.tag = "Player1";
                    player1Model.SetActive(true);

                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP2Holder();

                    player2Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player2Model.AddComponent<PlayerStatSystem>();
                    player2Model.AddComponent<PlayerInventory>();
                    player2Model.AddComponent<PlayerMoveBoardGame>();
                    player2Model.name = "Player2";
                    player2Model.tag = "Player2";
                    player2Model.SetActive(true);

                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP3Holder();

                    player3Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player3Model.AddComponent<PlayerStatSystem>();
                    player3Model.AddComponent<PlayerInventory>();
                    player3Model.AddComponent<PlayerMoveBoardGame>();
                    player3Model.name = "Player3";
                    player3Model.tag = "Player3";
                    player3Model.SetActive(true);
                    break;
                }
            case 4:
                {
                    GameObject _tempPlayerModel;

                    //Alter loading of assest for multiple players
                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP1Holder();

                    player1Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player1Model.AddComponent<PlayerStatSystem>();
                    player1Model.AddComponent<PlayerInventory>();
                    player1Model.AddComponent<PlayerMoveBoardGame>();
                    player1Model.name = "Player1";
                    player1Model.tag = "Player1";
                    player1Model.SetActive(true);

                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP2Holder();

                    player2Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player2Model.AddComponent<PlayerStatSystem>();
                    player2Model.AddComponent<PlayerInventory>();
                    player2Model.AddComponent<PlayerMoveBoardGame>();
                    player2Model.name = "Player2";
                    player2Model.tag = "Player2";
                    player2Model.SetActive(true);

                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP3Holder();

                    player3Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player3Model.AddComponent<PlayerStatSystem>();
                    player3Model.AddComponent<PlayerInventory>();
                    player3Model.AddComponent<PlayerMoveBoardGame>();
                    player3Model.name = "Player3";
                    player3Model.tag = "Player3";
                    player3Model.SetActive(true);

                    _tempPlayerModel = universalGM.GetComponent<UniversalGameManager>().GetP4Holder();

                    player4Model = (GameObject)Instantiate(_tempPlayerModel, poolerLocation.transform.position, poolerLocation.transform.rotation);
                    player4Model.AddComponent<PlayerStatSystem>();
                    player4Model.AddComponent<PlayerInventory>();
                    player4Model.AddComponent<PlayerMoveBoardGame>();
                    player4Model.name = "Player4";
                    player4Model.tag = "Player4";
                    player4Model.SetActive(true);
                    break;
                }
        }

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
