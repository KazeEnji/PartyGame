using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class LocalManager : MonoBehaviour
{
    //List for prefabs.
    [SerializeField] private List<GameObject> poolerList = new List<GameObject>();

    //List for instantiated objects.
    [SerializeField] private List<GameObject> playerCharacters = new List<GameObject>();

    //Holds onto the pooler's location.
    [SerializeField] private GameObject poolerLocation;

    private void Pooler()
    {
        //Checks to make sure there are objects in the list.
        if(poolerList.Count > 0)
        {
            //Loops through the prefab list.
            foreach(GameObject _pc in poolerList)
            {
                GameObject _tempPC;

                //Instantiates the prefab and assigns it to a variable.
                _tempPC = (GameObject)Instantiate(_pc, poolerLocation.transform.position, poolerLocation.transform.rotation);
                
                //Activates the instantiated object.
                _tempPC.SetActive(false);
                
                //Adds the instantiated object to a different list.
                playerCharacters.Add(_tempPC);
            }
        }
        //If not, debug the error.
        else
        {
            Debug.Log("There are no objects in List.");
        }
    }
}
