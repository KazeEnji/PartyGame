using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour 
{
    [SerializeField] private string shopType;

    private void Awake()
    {
        shopType = this.gameObject.name;
    }

    public string GetShopType()
    {
        return shopType;
    }
}
