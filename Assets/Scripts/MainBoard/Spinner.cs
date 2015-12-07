using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spinner : MonoBehaviour 
{
    //Variables to communicate with other scripts.
    public GameObject gameManager;
    public GameObject mainCam;
    public GameObject movementCanvas;

    //Variable necessary to output roll to screen.
    public Text numOutput;

    //Clamps random roll between 1 - 6. Does not include ending number.
    private int minRoll = 1;
    private int maxRoll = 7;
    private int roll;

    //Performs the roll and sets it to the GameManager.
    public void Spin()
    {
        roll = Random.Range(minRoll, maxRoll);
        numOutput.text = roll.ToString();
        gameManager.GetComponent<MainBoardLocalManager>().SetP1Roll(roll);
    }

    //Begins player 1's turn.
    public void StartP1Turn()
    {
        mainCam.GetComponent<CameraMoveBoardGame>().enabled = true;
        movementCanvas.SetActive(false);
        gameManager.GetComponent<MainBoardLocalManager>().StartP1Move();
    }
}
