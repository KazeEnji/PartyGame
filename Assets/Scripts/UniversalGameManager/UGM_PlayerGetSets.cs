using UnityEngine;
using System.Collections;

public partial class UniversalGameManager : MonoBehaviour
{
    public void SetPlayerHolders(int _playerNumber, int _characterPointInList)
    {
        switch (_playerNumber)
        {
            case 0:
                {
                    p1Holder = characterPrefabs[_characterPointInList];
                    break;
                }
            case 1:
                {
                    p2Holder = characterPrefabs[_characterPointInList];
                    break;
                }
            case 2:
                {
                    p3Holder = characterPrefabs[_characterPointInList];
                    break;
                }
            case 3:
                {
                    p4Holder = characterPrefabs[_characterPointInList];
                    break;
                }
        }
    }

    public GameObject GetP1Holder()
    {
        return p1Holder;
    }
    
    public GameObject GetP2Holder()
    {
        return p2Holder;
    }

    public GameObject GetP3Holder()
    {
        return p3Holder;
    }

    public GameObject GetP4Holder()
    {
        return p4Holder;
    }

    public void SetNumberOfPlayers(int _value)
    {
        totalNumberOfPlayers = _value;
    }

    public int GetNumberOfPlayers()
    {
        return totalNumberOfPlayers;
    }

    public int GetPointsInList(int _playerNumber)
    {
        switch (_playerNumber)
        {
            case 0:
                {
                    return p1PointInList;
                }
            case 1:
                {
                    return p2PointInList;
                }
            case 2:
                {
                    return p3PointInList;
                }
            case 3:
                {
                    return p4PointInList;
                }
        }

        return -1;
    }
}
