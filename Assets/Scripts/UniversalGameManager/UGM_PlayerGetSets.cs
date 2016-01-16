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
                    p1PointInList = _characterPointInList;
                    break;
                }
            case 1:
                {
                    p2PointInList = _characterPointInList;
                    break;
                }
            case 2:
                {
                    p3PointInList = _characterPointInList;
                    break;
                }
            case 3:
                {
                    p4PointInList = _characterPointInList;
                    break;
                }
        }
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
