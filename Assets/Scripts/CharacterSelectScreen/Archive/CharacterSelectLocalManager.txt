using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public partial class CharacterSelectLocalManager : MonoBehaviour
{
    //These variables are for holding onto the posisions to make the character selects work.
    [SerializeField] private GameObject destinationSpot;
    [SerializeField] private GameObject activeModel;
    [SerializeField] private GameObject universalGM;
    [SerializeField] private GameObject p1Char, p2Char, p3Char, p4Char;

    [SerializeField] private int pointInList = 0;
    [SerializeField] private int indexesForPlayerCharacters;
    [SerializeField] private int currentPlayerNumber = 1;
    [SerializeField] private int totalPlayerCount;

    [SerializeField] private bool p1DPHInUseFlag = false;
    [SerializeField] private bool p2DPHInUseFlag = false;
    [SerializeField] private bool p3DPHInUseFlag = false;
    [SerializeField] private bool p4DPHInUseFlag = false;
    [SerializeField] private bool p1ReadyFlag = false;
    [SerializeField] private bool p2ReadyFlag = false;
    [SerializeField] private bool p3ReadyFlag = false;
    [SerializeField] private bool p4ReadyFlag = false;

    [SerializeField] private string p1DPH = "P1DPadHorizontal";
    [SerializeField] private string p2DPH = "P2DPadHorizontal";
    [SerializeField] private string p3DPH = "P3DPadHorizontal";
    [SerializeField] private string p4DPH = "P4DPadHorizontal";

    //Calls the pooler for grabbing the models.
    private void Awake()
    {
        Debug.Log("Loading Start");

        universalGM = GameObject.FindGameObjectWithTag("UGM");
        totalPlayerCount = universalGM.GetComponent<UniversalGameManager>().GetNumberOfPlayers();

        Pooler();

        //Gets the indexes of the instantiated list for characeter switching later.
        indexesForPlayerCharacters = playerCharacters.Count - 1;
        Debug.Log("Loading Done");

        //Displays the character models.
        ShowPCChoices();
    }

    private void Update()
    {
        /*
        resetInputFlags();

        //Waits for keypress to switch characters on screen.
        NextPC();
        PreviousPC();
        */
    }
    
    private void ShowPCChoices()
    {
        //Checks to see if there's already a model loaded
        if(activeModel != null)
        {
            //If there is, disable it and move it back to the pooler location
            activeModel.SetActive(false);
            activeModel.transform.position = poolerLocation.transform.position;
            activeModel.transform.rotation = poolerLocation.transform.rotation;
        }

        //If there isn't a model loaded, grab one, move it into position, and turn it on.
        activeModel = playerCharacters[pointInList];
        activeModel.transform.position = destinationSpot.transform.position;
        activeModel.transform.rotation = destinationSpot.transform.rotation;
        activeModel.SetActive(true);
    }

    //Flips the flag to allow the player to press the button again for input.
    private void resetInputFlags()
    {
        if(Input.GetAxis(p1DPH) == 0)
        {
            p1DPHInUseFlag = false;
        }
        if (Input.GetAxis(p2DPH) == 0)
        {
            p2DPHInUseFlag = false;
        }
        if (Input.GetAxis(p3DPH) == 0)
        {
            p3DPHInUseFlag = false;
        }
        if (Input.GetAxis(p4DPH) == 0)
        {
            p4DPHInUseFlag = false;
        }
    }

    //Advance to the next model in the list on keypress or joystick
    private void NextPC()
    {
        if(Input.GetKeyDown(KeyCode.C) || (Input.GetAxis(p1DPH) == 1 && p1DPHInUseFlag == false))
        {
            p1DPHInUseFlag = true;

            if(pointInList < indexesForPlayerCharacters)
            {
                pointInList += 1;
            }
            else
            {
                pointInList = 0;
            }
            ShowPCChoices();
        }
    }

    //Advance to the previous model in the list on keypress or joystick
    private void PreviousPC()
    {
        if (Input.GetKeyDown(KeyCode.Z) || (Input.GetAxis(p1DPH) == -1 && p1DPHInUseFlag == false))
        {
            p1DPHInUseFlag = true;

            if (pointInList > 0)
            {
                pointInList -= 1;
            }
            else
            {
                pointInList = indexesForPlayerCharacters;
            }
            ShowPCChoices();
        }
    }

    public void SelectChar()
    {
        if(currentPlayerNumber < totalPlayerCount)
        {
            universalGM.GetComponent<UniversalGameManager>().SetP1Holder(pointInList);
            p1ReadyFlag = true;
            Debug.Log("Player 1 has chosen number: " + pointInList);
        }
    }

    public void StartGame()
    {
        if (p1ReadyFlag == true)
        {
            Debug.Log("Loading...");
            SceneManager.LoadScene("MainBoard");
        }
    }
}
