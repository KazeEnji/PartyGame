using UnityEngine;
using System.Collections;

public partial class LocalManager : MonoBehaviour
{
    //These variables are for holding onto the posisions to make the character selects work.
    [SerializeField] private GameObject destinationSpot;
    [SerializeField] private GameObject activeModel;
    [SerializeField] private int pointInList = 0;
    [SerializeField] private int indexesForPlayerCharacters;

    //Calls the pooler for grabbing the models.
    private void Awake()
    {
        Debug.Log("Loading Start");
        Pooler();

        //Gets the indexes of the instantiated list for characeter switching later.
        indexesForPlayerCharacters = playerCharacters.Count - 1;
        Debug.Log("Loading Done");

        //Displays the character models.
        ShowPCChoices();
    }

    private void Update()
    {
        //Waits for keypress to switch characters on screen.
        NextPC();
        PreviousPC();
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

    //Advance to the next model in the list on keypress.
    //This will eventually be changed for joystick input.
    private void NextPC()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
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

    //Advance to the previous model in the list on keypress.
    //This will eventually be changed for joystick input.
    private void PreviousPC()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
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
}
