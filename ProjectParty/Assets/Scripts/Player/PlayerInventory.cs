using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour 
{
    private int invSize = 6;
    private int money;
    private int inventorySpace;
    private GameObject[] inventoryArray;

    private void Awake()
    {
        inventoryArray = new GameObject[invSize];
    }

    public int GetMoney()
    {
        return money;
    }

    public GameObject[] GetInventoryArray()
    {
        return inventoryArray;
    }
}
