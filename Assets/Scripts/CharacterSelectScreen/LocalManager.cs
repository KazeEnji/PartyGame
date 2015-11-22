using UnityEngine;
using System.Collections;

public partial class LocalManager : MonoBehaviour
{
    [SerializeField] GameObject destinationSpot;

    private void Awake()
    {
        Pooler();
    }
}
