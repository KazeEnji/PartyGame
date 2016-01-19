using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Rewired;

public partial class CharacterSelectLocalManager : MonoBehaviour
{
    //These variables are for holding onto the posisions to make the character selects work.
    //[SerializeField] private GameObject destinationSpot;
    [SerializeField] private GameObject p1ActiveModel;
    [SerializeField] private GameObject p2ActiveModel;
    [SerializeField] private GameObject p3ActiveModel;
    [SerializeField] private GameObject p4ActiveModel;
    [SerializeField] private GameObject universalGM;

    [SerializeField] private bool p1Ready = true;
    [SerializeField] private bool p2Ready = true;
    [SerializeField] private bool p3Ready = true;
    [SerializeField] private bool p4Ready = true;

    [SerializeField] private int pointInList = 0;
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
                    p1ActiveModel = player1Characters[pointInList];
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
                    p2ActiveModel = player2Characters[pointInList];
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
                    p3ActiveModel = player3Characters[pointInList];
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
                    p4ActiveModel = player4Characters[pointInList];
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
        if (pointInList < indexesForPlayerCharacters)
        {
            pointInList += 1;
        }
        else
        {
            pointInList = 0;
        }
        ShowPCChoices(_playerID, _destinationPlatform);
    }

    //Advance to the previous model in the list on keypress or joystick
    public void PreviousPC(int _playerID, GameObject _destinationPlatform)
    {
        if (pointInList > 0)
        {
            pointInList -= 1;
        }
        else
        {
            pointInList = indexesForPlayerCharacters;
        }
        ShowPCChoices(_playerID, _destinationPlatform);
    }

    public void SelectChar(int _playerID)
    {
        universalGM.GetComponent<UniversalGameManager>().SetPlayerHolders(_playerID, pointInList);
        Debug.Log("Player 1 has chosen number: " + pointInList);
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

    private void OnControllerConnected(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is connected
        // You can get information about the controller that was connected via the args parameter
        Debug.Log("A controller was connected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);

        SetPlayerReady(args.controllerId, false);
        numberOfPlayers++;
    }

    private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is fully disconnected
        // You can get information about the controller that was disconnected via the args parameter
        Debug.Log("A controller was disconnected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);

        SetPlayerReady(args.controllerId, true);
        numberOfPlayers--;
    }

    private void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is about to be disconnected
        // You can get information about the controller that is being disconnected via the args parameter
        // You can use this event to save the controller's maps before it's disconnected
        Debug.Log("A controller is being disconnected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);
    }
}
