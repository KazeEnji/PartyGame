using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class CharacterSelectLocalManager : MonoBehaviour
{
    //List for prefabs.
    [SerializeField] private List<GameObject> poolerList = new List<GameObject>();

    //List for instantiated objects.
    [SerializeField] private List<GameObject> player1Characters = new List<GameObject>();
    [SerializeField] private List<GameObject> player2Characters = new List<GameObject>();
    [SerializeField] private List<GameObject> player3Characters = new List<GameObject>();
    [SerializeField] private List<GameObject> player4Characters = new List<GameObject>();

    //Holds onto the pooler's location.
    [SerializeField] private GameObject poolerLocation;

    private void Pooler()
    {
        //Checks to make sure there are objects in the list.
        if(poolerList.Count > 0)
        {
            for(int i = 0; i <= 3; i++)
            {
                //Loops through the prefab list.
                foreach (GameObject _pc in poolerList)
                {
                    GameObject _tempPC;

                    //Instantiates the prefab and assigns it to a variable.
                    _tempPC = (GameObject)Instantiate(_pc, poolerLocation.transform.position, poolerLocation.transform.rotation);

                    //Activates the instantiated object.
                    _tempPC.SetActive(false);
                    _tempPC.name = _tempPC.name + i.ToString();

                    switch (i)
                    {
                        case 0:
                            {
                                player1Characters.Add(_tempPC);
                                break;
                            }
                        case 1:
                            {
                                player2Characters.Add(_tempPC);
                                break;
                            }
                        case 2:
                            {
                                player3Characters.Add(_tempPC);
                                break;
                            }
                        case 3:
                            {
                                player4Characters.Add(_tempPC);
                                break;
                            }
                    }
                }
            }

            GameObject.FindGameObjectWithTag("UGM").GetComponent<UniversalGameManager>().SetCharacterPrefabs(poolerList);
        }

        //If not, debug the error.
        else
        {
            Debug.Log("There are no objects in List.");
        }
    }

    public List<GameObject> GetCharacterList(int _playerID)
    {
        switch (_playerID)
        {
            case 0:
                {
                    return player1Characters;
                }
            case 1:
                {
                    return player2Characters;
                }
            case 2:
                {
                    return player3Characters;
                }
            case 3:
                {
                    return player4Characters;
                }
        }

        return null;
    }
}
