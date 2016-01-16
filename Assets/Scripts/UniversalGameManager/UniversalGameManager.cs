using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class UniversalGameManager : MonoBehaviour
{
    [SerializeField] private int p1PointInList;
    [SerializeField] private int p2PointInList;
    [SerializeField] private int p3PointInList;
    [SerializeField] private int p4PointInList;

    [SerializeField] private GameObject p1Holder;
    [SerializeField] private GameObject p2Holder;
    [SerializeField] private GameObject p3Holder;
    [SerializeField] private GameObject p4Holder;

    [SerializeField] private List<GameObject> characterPrefabs = new List<GameObject>();

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
