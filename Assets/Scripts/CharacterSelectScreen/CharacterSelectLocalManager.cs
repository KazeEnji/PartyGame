using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Rewired;

public partial class CharacterSelectLocalManager : MonoBehaviour
{
    //These variables are for holding onto the posisions to make the character selects work.
    [Header("Current model viewed")]
    [SerializeField] private GameObject p1ActiveModel;
    [SerializeField] private GameObject p2ActiveModel;
    [SerializeField] private GameObject p3ActiveModel;
    [SerializeField] private GameObject p4ActiveModel;
    [SerializeField] private GameObject universalGM;

    [Header("Ready Status")]
    [SerializeField] private bool p1Ready = true;
    [SerializeField] private bool p2Ready = true;
    [SerializeField] private bool p3Ready = true;
    [SerializeField] private bool p4Ready = true;

    [Header("Points In List")]
    [SerializeField] private int p1PointInList = 0;
    [SerializeField] private int p2PointInList = 0;
    [SerializeField] private int p3PointInList = 0;
    [SerializeField] private int p4PointInList = 0;

    [Header("Misc")]
    [SerializeField] private int indexesForPlayerCharacters;
    [SerializeField] private int numberOfPlayers;

    //Calls the pooler for grabbing the models.
    private void Awake()
    {
        Debug.Log("Loading Start");

        universalGM = GameObject.FindGameObjectWithTag("UGM");

        ReInput.ControllerConnectedEvent += OnControllerConnected;
        ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
        ReInput.ControllerPreDisconnectEvent += OnControllerPreDisconnect;

        Pooler();

        //Gets the indexes of the instantiated list for characeter switching later.
        indexesForPlayerCharacters = player1Characters.Count - 1;
        Debug.Log("Loading Done");
    }
    
    public void ShowPCChoices(int _playerID, GameObject _destinationCharacterSpot)
    {
        switch (_playerID)
        {
            case 0:
                {
                    //Checks to see if there's already a model loaded
                    if (p1ActiveModel != null)
                    {
                        //If there is, disable it and move it back to the pooler location
                        p1ActiveModel.SetActive(false);
                        p1ActiveModel.transform.position = poolerLocation.transform.position;
                        p1ActiveModel.transform.rotation = poolerLocation.transform.rotation;
                    }

                    //If there isn't a model loaded, grab one, move it into position, and turn it on.
                    p1ActiveModel = player1Characters[p1PointInList];
                    p1ActiveModel.transform.position = _destinationCharacterSpot.transform.position;
                    p1ActiveModel.transform.rotation = _destinationCharacterSpot.transform.rotation;
                    p1ActiveModel.SetActive(true);
                    break;
                }
            case 1:
                {

                    //Checks to see if there's already a model loaded
                    if (p2ActiveModel != null)
                    {
                        //If there is, disable it and move it back to the pooler location
                        p2ActiveModel.SetActive(false);
                        p2ActiveModel.transform.position = poolerLocation.transform.position;
                        p2ActiveModel.transform.rotation = poolerLocation.transform.rotation;
                    }

                    //If there isn't a model loaded, grab one, move it into position, and turn it on.
                    p2ActiveModel = player2Characters[p1PointInList];
                    p2ActiveModel.transform.position = _destinationCharacterSpot.transform.position;
                    p2ActiveModel.transform.rotation = _destinationCharacterSpot.transform.rotation;
                    p2ActiveModel.SetActive(true);
                    break;
                }
            case 2:
                {

                    //Checks to see if there's already a model loaded
                    if (p3ActiveModel != null)
                    {
                        //If there is, disable it and move it back to the pooler location
                        p3ActiveModel.SetActive(false);
                        p3ActiveModel.transform.position = poolerLocation.transform.position;
                        p3ActiveModel.transform.rotation = poolerLocation.transform.rotation;
                    }

                    //If there isn't a model loaded, grab one, move it into position, and turn it on.
                    p3ActiveModel = player3Characters[p1PointInList];
                    p3ActiveModel.transform.position = _destinationCharacterSpot.transform.position;
                    p3ActiveModel.transform.rotation = _destinationCharacterSpot.transform.rotation;
                    p3ActiveModel.SetActive(true);
                    break;
                }
            case 3:
                {

                    //Checks to see if there's already a model loaded
                    if (p4ActiveModel != null)
                    {
                        //If there is, disable it and move it back to the pooler location
                        p4ActiveModel.SetActive(false);
                        p4ActiveModel.transform.position = poolerLocation.transform.position;
                        p4ActiveModel.transform.rotation = poolerLocation.transform.rotation;
                    }

                    //If there isn't a model loaded, grab one, move it into position, and turn it on.
                    p4ActiveModel = player4Characters[p1PointInList];
                    p4ActiveModel.transform.position = _destinationCharacterSpot.transform.position;
                    p4ActiveModel.transform.rotation = _destinationCharacterSpot.transform.rotation;
                    p4ActiveModel.SetActive(true);
                    break;
                }
        }
    }

    public void HidePCChoices(int _playerID)
    {
        switch (_playerID)
        {
            case 0:
                {
                    p1ActiveModel.SetActive(false);
                    break;
                }
            case 1:
                {
                    p2ActiveModel.SetActive(false);
                    break;
                }
            case 2:
                {
                    p3ActiveModel.SetActive(false);
                    break;
                }
            case 3:
                {
                    p4ActiveModel.SetActive(false);
                    break;
                }
        }
    }

    //Advance to the next model in the list on keypress or joystick
    public void NextPC(int _playerID, GameObject _destinationPlatform)
    {
        switch (_playerID)
        {
            case 0:
                {
                    if (p1PointInList < indexesForPlayerCharacters)
                    {
                        p1PointInList += 1;
                    }
                    else
                    {
                        p1PointInList = 0;
                    }
                    ShowPCChoices(_playerID, _destinationPlatform);
                    break;
                }
            case 1:
                {
                    if (p2PointInList < indexesForPlayerCharacters)
                    {
                        p2PointInList += 1;
                    }
                    else
                    {
                        p2PointInList = 0;
                    }
                    ShowPCChoices(_playerID, _destinationPlatform);
                    break;
                }
            case 2:
                {
                    if (p3PointInList < indexesForPlayerCharacters)
                    {
                        p3PointInList += 1;
                    }
                    else
                    {
                        p3PointInList = 0;
                    }
                    ShowPCChoices(_playerID, _destinationPlatform);
                    break;
                }
            case 3:
                {
                    if (p4PointInList < indexesForPlayerCharacters)
                    {
                        p4PointInList += 1;
                    }
                    else
                    {
                        p4PointInList = 0;
                    }
                    ShowPCChoices(_playerID, _destinationPlatform);
                    break;
                }
        }
    }

    //Advance to the previous model in the list on keypress or joystick
    public void PreviousPC(int _playerID, GameObject _destinationPlatform)
    {
        switch (_playerID)
        {
            case 0:
                {
                    if (p1PointInList > 0)
                    {
                        p1PointInList -= 1;
                    }
                    else
                    {
                        p1PointInList = indexesForPlayerCharacters;
                    }
                    ShowPCChoices(_playerID, _destinationPlatform);
                    break;
                }
            case 1:
                {
                    if (p2PointInList > 0)
                    {
                        p2PointInList -= 1;
                    }
                    else
                    {
                        p2PointInList = indexesForPlayerCharacters;
                    }
                    ShowPCChoices(_playerID, _destinationPlatform);
                    break;
                }
            case 2:
                {
                    if (p3PointInList > 0)
                    {
                        p3PointInList -= 1;
                    }
                    else
                    {
                        p3PointInList = indexesForPlayerCharacters;
                    }
                    ShowPCChoices(_playerID, _destinationPlatform);
                    break;
                }
            case 3:
                {
                    if (p4PointInList > 0)
                    {
                        p4PointInList -= 1;
                    }
                    else
                    {
                        p4PointInList = indexesForPlayerCharacters;
                    }
                    ShowPCChoices(_playerID, _destinationPlatform);
                    break;
                }
        }
    }

    public void SelectChar(int _playerID)
    {
        switch (_playerID)
        {
            case 0:
                {
                    universalGM.GetComponent<UniversalGameManager>().SetPlayerHolders(_playerID, p1PointInList);
                    break;
                }
            case 1:
                {
                    universalGM.GetComponent<UniversalGameManager>().SetPlayerHolders(_playerID, p2PointInList);
                    break;
                }
            case 2:
                {
                    universalGM.GetComponent<UniversalGameManager>().SetPlayerHolders(_playerID, p3PointInList);
                    break;
                }
            case 3:
                {
                    universalGM.GetComponent<UniversalGameManager>().SetPlayerHolders(_playerID, p4PointInList);
                    break;
                }
        }
    }

    public void SetPlayerReady(int _playerID, bool _ready)
    {
        switch (_playerID)
        {
            case 0:
                {
                    p1Ready = _ready;
                    break;
                }
            case 1:
                {
                    p2Ready = _ready;
                    break;
                }
            case 2:
                {
                    p3Ready = _ready;
                    break;
                }
            case 3:
                {
                    p4Ready = _ready;
                    break;
                }
        }
    }

    public void StartGame()
    {
        Debug.Log("Loading...");
        universalGM.GetComponent<UniversalGameManager>().SetNumberOfPlayers(numberOfPlayers);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public bool CheckReady()
    {
        switch (numberOfPlayers)
        {
            case 1:
                {
                    if(p1Ready)
                    {
                        return true;
                    }
                    break;
                }
            case 2:
                {
                    if(p1Ready && p2Ready)
                    {
                        return true;
                    }
                    break;
                }
            case 3:
                {
                    if(p1Ready && p2Ready && p3Ready)
                    {
                        return true;
                    }
                    break;
                }
            case 4:
                {
                    if(p1Ready && p2Ready && p3Ready && p4Ready)
                    {
                        return true;
                    }
                    break;
                }
        }

        return false;
    }

    public void IncrementPlayerCount()
    {
        numberOfPlayers++;
    }

    public void DecrementPlayerCount()
    {
        numberOfPlayers--;
    }

    private void OnControllerConnected(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is connected
        // You can get information about the controller that was connected via the args parameter
        Debug.Log("A controller was connected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);

        SetPlayerReady(args.controllerId, false);
    }

    private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is fully disconnected
        // You can get information about the controller that was disconnected via the args parameter
        Debug.Log("A controller was disconnected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);

        SetPlayerReady(args.controllerId, true);

        if(numberOfPlayers > 0)
        {
            DecrementPlayerCount();
        }
    }

    private void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is about to be disconnected
        // You can get information about the controller that is being disconnected via the args parameter
        // You can use this event to save the controller's maps before it's disconnected
        Debug.Log("A controller is being disconnected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);
    }
}
