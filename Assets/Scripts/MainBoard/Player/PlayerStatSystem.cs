using UnityEngine;
using System.Collections;

public class PlayerStatSystem : MonoBehaviour 
{
    [SerializeField] private int strength;
    [SerializeField] private int intelligence;
    [SerializeField] private int faith;

    private void Awake()
    {
        strength = 5;
        intelligence = 2;
        faith = 2;
    }

    public int GetStrength()
    {
        return strength;
    }

    public int GetIntelligence()
    {
        return intelligence;
    }

    public int GetFaith()
    {
        return faith;
    }
}
