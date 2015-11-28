using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class LocalManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> poolerList = new List<GameObject>();
    [SerializeField] private List<GameObject> playerCharacters = new List<GameObject>();
    [SerializeField] private GameObject poolerLocation;

    private void Pooler()
    {
        if(poolerList.Count > 0)
        {
            foreach(GameObject _pc in poolerList)
            {
                GameObject _tempPC;
                //Debug.Log("I'm about to start instantiating objects. " + _pc.name);
                _tempPC = (GameObject)Instantiate(_pc, poolerLocation.transform.position, poolerLocation.transform.rotation);
                //Debug.Log("I've instantiated an object." + _pc.name);
                _tempPC.SetActive(false);
                //Debug.Log("I've disabled the object." + _pc.name);
                playerCharacters.Add(_tempPC);
                //Debug.Log("I've added the object to the playerCharacters List);
            }
        }
        else
        {
            Debug.Log("There are no objects in List.");
        }
    }
}
