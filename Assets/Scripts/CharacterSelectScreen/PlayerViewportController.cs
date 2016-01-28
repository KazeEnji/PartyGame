using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rewired;

public class PlayerViewportController : MonoBehaviour
{
    [SerializeField] private int playerID;
    [SerializeField] private int currentState;

    [SerializeField] private bool p1AllPlayersReady;

    [Header("Canvas Variables")]
    [SerializeField] private GameObject startStateCanvas;
    [SerializeField] private GameObject characterChosenCanvas;
    [SerializeField] private GameObject finalCanvas;
    [SerializeField] private GameObject p1NotReadyNotificationCanvas;

    [Header("Platform and Spawn Point")]
    [SerializeField] private GameObject destinationPlatform;
    [SerializeField] private GameObject destinationCharacterSpot;

    [SerializeField] private List<GameObject> characterPool = new List<GameObject>();

    [SerializeField] private CharacterSelectLocalManager localGameManagerScript;

    [SerializeField] private Player player;

    private void Awake()
    {
        localGameManagerScript = GameObject.FindGameObjectWithTag("LGM").GetComponent<CharacterSelectLocalManager>();
    }

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        characterPool = localGameManagerScript.GetCharacterList(playerID);
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
            case 3:
                {
                    FinalState();
                    break;
                }
            case 4:
                {
                    NotAllReady();
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
            localGameManagerScript.IncrementPlayerCount();
            localGameManagerScript.SetPlayerReady(playerID, false);
            startStateCanvas.SetActive(false);
            destinationPlatform.SetActive(true);
            localGameManagerScript.ShowPCChoices(playerID, destinationCharacterSpot);
            currentState++;
        }
    }

    private void ChoosePlayerCharacterState()
    {
        Debug.Log("Choose player character");
        
        if(player.GetButtonDown("R1"))
        {
            localGameManagerScript.NextPC(playerID, destinationCharacterSpot);
        }
        
        if(player.GetButtonDown("L1"))
        {
            localGameManagerScript.PreviousPC(playerID, destinationCharacterSpot);
        }

        if (player.GetButtonDown("Cross"))
        {
            Debug.Log("Player has chosen a character.");
            characterChosenCanvas.SetActive(true);
            localGameManagerScript.SelectChar(playerID);
            destinationPlatform.SetActive(false);
            localGameManagerScript.HidePCChoices(playerID);
            currentState++;
        }

        if (player.GetButtonDown("Circle"))
        {
            Debug.Log("Player as gone back one state.");
            localGameManagerScript.DecrementPlayerCount();
            localGameManagerScript.SetPlayerReady(playerID, true);
            characterChosenCanvas.SetActive(false);
            startStateCanvas.SetActive(true);
            destinationPlatform.SetActive(false);
            localGameManagerScript.HidePCChoices(playerID);
            currentState--;
        }
    }

    private void ReadyState()
    {
        Debug.Log("Player: " + playerID + " is ready");

        localGameManagerScript.SetPlayerReady(playerID, true);

        if(player.GetButtonDown("Cross"))
        {
            characterChosenCanvas.SetActive(false);
            currentState++;
        }

        if (player.GetButtonDown("Circle"))
        {
            Debug.Log("Player as gone back one state.");
            characterChosenCanvas.SetActive(false);
            destinationPlatform.SetActive(true);
            localGameManagerScript.ShowPCChoices(playerID, destinationCharacterSpot);
            localGameManagerScript.SetPlayerReady(playerID, false);
            currentState--;
        }
    }

    private void FinalState()
    {
        Debug.Log("Player: " + playerID + "is in final state.");

        finalCanvas.SetActive(true);

        if(player.GetButtonDown("Start") && playerID == 0)
        {
            CheckAllReadyStates();

            if(p1AllPlayersReady)
            {
                localGameManagerScript.StartGame();
            }
            else
            {
                finalCanvas.SetActive(false);
                currentState++;
            }
        }
    }

    private void NotAllReady()
    {
        Debug.Log("Not all players are ready.");

        p1NotReadyNotificationCanvas.SetActive(true);

        if(player.GetButtonDown("Circle"))
        {
            p1NotReadyNotificationCanvas.SetActive(false);
            currentState--;
        }
    }

    private void CheckAllReadyStates()
    {
        p1AllPlayersReady = localGameManagerScript.CheckReady();
    }
}
