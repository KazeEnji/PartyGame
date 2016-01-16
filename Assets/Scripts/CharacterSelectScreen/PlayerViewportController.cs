using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerViewportController : MonoBehaviour
{
    [SerializeField] private int playerID;
    [SerializeField] private int currentState;

    [SerializeField] private GameObject startStateCanvas;

    [SerializeField] private CharacterSelectLocalManager localGameManagerScript;

    [SerializeField] private Player player;

    private void Awake()
    {
        localGameManagerScript = GameObject.FindGameObjectWithTag("LGM").GetComponent<CharacterSelectLocalManager>();
    }

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        currentState = 0;
    }

    private void Update()
    {
        AdvanceStates();
    }

    private void AdvanceStates()
    {
        switch (currentState)
        {
            case 0:
                {
                    StartState();
                    break;
                }

            case 1:
                {
                    ChoosePlayerCharacterState();
                    break;
                }
            case 2:
                {
                    ReadyState();
                    break;
                }
        }
    }

    private void StartState()
    {
        Debug.Log("Press Start");

        if(startStateCanvas.activeSelf == false)
        {
            startStateCanvas.SetActive(true);
        }

        if (player.GetButtonDown("Start"))
        {
            Debug.Log("Player " + playerID + " hit start");
            startStateCanvas.SetActive(false);
            currentState++;
        }
    }

    private void ChoosePlayerCharacterState()
    {
        Debug.Log("Choose player character");
        
        if(player.GetButtonDown("R1"))
        {
            localGameManagerScript.NextPC();
        }
        
        if(player.GetButtonDown("L1"))
        {
            localGameManagerScript.PreviousPC();
        }

        if (player.GetButtonDown("Cross"))
        {
            Debug.Log("Player has chosen a character.");
            localGameManagerScript.SelectChar(playerID);
            currentState++;
        }

        if (player.GetButtonDown("Circle"))
        {
            Debug.Log("Player as gone back one state.");
            currentState--;
        }
    }

    private void ReadyState()
    {
        Debug.Log("Player: " + playerID + " is ready");

        if (player.GetButtonDown("Circle"))
        {
            Debug.Log("Player as gone back one state.");
            currentState--;
        }
    }
}
