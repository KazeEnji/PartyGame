using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class LocalManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playerCharacter = new List<GameObject>();
    [SerializeField] GameObject poolerLocation;

    private void Pooler()
    {
        if(playerCharacter.Count > 0)
        {
            foreach(GameObject PC in playerCharacter)
            {
                Instantiate(PC, poolerLocation.transform.position, poolerLocation.transform.rotation);
                PC.SetActive(false);
            }
        }
    }
}
