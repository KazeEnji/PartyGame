using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public partial class CharacterSelectLocalManager : MonoBehaviour
{
    //These variables are for holding onto the posisions to make the character selects work.
    //[SerializeField] private GameObject destinationSpot;
    [SerializeField] private GameObject p1ActiveModel;
    [SerializeField] private GameObject p2ActiveModel;
    [SerializeField] private GameObject p3ActiveModel;
    [SerializeField] private GameObject p4ActiveModel;
    [SerializeField] private GameObject universalGM;

    [SerializeField] private int pointInList = 0;
    [SerializeField] private int indexesForPlayerCharacters;

    //Calls the pooler for grabbing the models.
    private void Awake()
    {
        Debug.Log("Loading Start");

        universalGM = GameObject.FindGameObjectWithTag("UGM");

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

    public void StartGame()
    {
        Debug.Log("Loading...");
        SceneManager.LoadScene("MainBoard");
    }
}
