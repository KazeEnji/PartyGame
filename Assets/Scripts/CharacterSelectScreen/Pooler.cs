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
                _tempPC = (GameObject)Instantiate(_pc, poolerLocation.transform.position, poolerLocation.transform.rotation);
                _tempPC.SetActive(false);
                playerCharacters.Add(_tempPC);
            }
        }
        else
        {
            Debug.Log("There are no objects in List.");
        }
    }
}
