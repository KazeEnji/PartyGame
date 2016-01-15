using UnityEngine;
using System.Collections;

public partial class UniversalGameManager : MonoBehaviour
{
    public void SetP1Holder(int _P1Character)
    {
        p1PointInList = _P1Character;
    }

    public void SetP2Holder(int _P2Character)
    {
        p2PointInList = _P2Character;
    }

    public void SetP3Holder(int _P3Character)
    {
        p3PointInList = _P3Character;
    }

    public void SetP4Holder(int _P4Character)
    {
        p4PointInList = _P4Character;
    }

    public int GetP1PointInList()
    {
        return p1PointInList;
    }

    public int GetP2PointInList()
    {
        return p2PointInList;
    }

    public int GetP3PointInList()
    {
        return p3PointInList;
    }

    public int GetP4PointInList()
    {
        return p4PointInList;
    }

    public void SetNumberOfPlayers(int _value)
    {
        numberOfPlayers = _value;
    }

    public int GetNumberOfPlayers()
    {
        return numberOfPlayers;
    }
}
