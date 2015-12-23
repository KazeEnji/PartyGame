using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UniversalGameManager : MonoBehaviour
{
    [SerializeField] private int p1PointInList;

    [SerializeField] private GameObject p1Holder;

    [SerializeField] private List<GameObject> characterPrefabs = new List<GameObject>();

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int GetP1PointInList()
    {
        return p1PointInList;
    }

    public void SetP1Holder(int _P1Character)
    {
        p1PointInList = _P1Character;
    }

    public GameObject GetP1Holder()
    {
        p1Holder = characterPrefabs[p1PointInList];
        return p1Holder;
    }

    public void SetCharacterPrefabs(List<GameObject> _incomingList)
    {
        foreach(GameObject _character in _incomingList)
        {
            characterPrefabs.Add(_character);
        }
    }
}
