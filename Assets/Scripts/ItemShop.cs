using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour 
{
    public GameObject itemList;
    public GameObject shopCanvas;

    private void Awake()
    {
        itemList.SetActive(false);
    }

    public void ShowShopCanvas()
    {
        shopCanvas.SetActive(true);
    }

    public void ShowItemList()
    {
        itemList.SetActive(true);
    }

    public void ExitShop()
    {
        shopCanvas.SetActive(false);
    }
}
