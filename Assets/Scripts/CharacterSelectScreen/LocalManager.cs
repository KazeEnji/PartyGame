using UnityEngine;
using System.Collections;

public partial class LocalManager : MonoBehaviour
{
    [SerializeField] private GameObject destinationSpot;
    [SerializeField] private GameObject activeModel;
    [SerializeField] private int pointInList = 0;
    [SerializeField] private int indexesForPlayerCharacters;

    private void Awake()
    {
        Debug.Log("Loading Start");
        Pooler();
        indexesForPlayerCharacters = playerCharacters.Count - 1;
        Debug.Log("Loading Done");
        ShowPCChoices();
    }

    private void Update()
    {
        NextPC();
        PreviousPC();
    }
    
    private void ShowPCChoices()
    {
        if(activeModel != null)
        {
            activeModel.SetActive(false);
            activeModel.transform.position = poolerLocation.transform.position;
            activeModel.transform.rotation = poolerLocation.transform.rotation;
        }

        activeModel = playerCharacters[pointInList];
        activeModel.transform.position = destinationSpot.transform.position;
        activeModel.transform.rotation = destinationSpot.transform.rotation;
        activeModel.SetActive(true);
    }

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
