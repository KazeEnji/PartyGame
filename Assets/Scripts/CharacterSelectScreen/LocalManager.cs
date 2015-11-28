using UnityEngine;
using System.Collections;

public partial class LocalManager : MonoBehaviour
{
    [SerializeField] private GameObject destinationSpot;
    [SerializeField] private GameObject activeModel;
    [SerializeField] private int pointInList = 0;

    private void Awake()
    {
        Debug.Log("Loading Start");
        Pooler();
        Debug.Log("Loading Done");
        ShowPCChoices();
    }
    
    private void ShowPCChoices()
    {
        //Debug.Log("I'm about to start manipulating the objects.");
        //Debug.Log("The point in the list we're working with is: " + pointInList);
        activeModel = playerCharacters[pointInList];
        //Debug.Log("The active model is now asigned this object: " + activeModel.name);
        //Debug.Log("The active model's position is: " + activeModel.transform.position);
        //Debug.Log("The destination spot's position is: " + destinationSpot.transform.position);
        activeModel.transform.position = destinationSpot.transform.position;
        //Debug.Log("The active model's position is: " + activeModel.transform.position);
        //Debug.Log("The active model's position should be: " + destinationSpot.transform.position);
        activeModel.transform.rotation = destinationSpot.transform.rotation;
        activeModel.SetActive(true);
    }
}
