using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour {

    public GameObject ShopPanelVisual;
    public GameObject PlayerPanelVisual;

    public GameObject ItemVisualPrefab;
    public Transform ShopItemsHub;
    public Transform PlayerItemsHub;

    public GameObject InShopBalance;
    public GameObject InInventoryBalance;

    private Dictionary<Item, GameObject> ShopItemsGameObjects = new Dictionary<Item, GameObject>();
    private Dictionary<Item, GameObject> PlayerItemsGameObjects = new Dictionary<Item, GameObject>();

    public void CloseButtonClick() //Shop
    {
        ShopPanelVisual.SetActive(false);
        Control.PlanetObjectsAction("activate");

    }

    public void OpenShop() //Shop
    {
        InShopBalance.GetComponent<Text>().text = Control.playerMoney.ToString() + " UNC";
        if (PlayerPanelVisual.activeInHierarchy)
            PlayerPanelVisual.SetActive(false);
        ShopPanelVisual.SetActive(true);
    }

    public void PlayerCloseButtonClick()
    {
        PlayerPanelVisual.SetActive(false);
        Control.PlanetObjectsAction("activate");

    }

    public void OpenPlayerInventory() //Shop
    {
        InInventoryBalance.GetComponent<Text>().text = Control.playerMoney.ToString() + " UNC";
        if (ShopPanelVisual.activeInHierarchy)
            ShopPanelVisual.SetActive(false);
        PlayerPanelVisual.SetActive(true);
    }

    internal void AddItemToShop(Item item)
    {
        if (ShopItemsGameObjects.ContainsKey(item))
        {
            ShopItemsGameObjects[item].SetActive(true);
        }
        else
        {
            GameObject newItem = Instantiate(ItemVisualPrefab, Vector3.zero, Quaternion.identity, ShopItemsHub);
            newItem.GetComponent<ItemVisual>().Init(item);
            ShopItemsGameObjects.Add(item, newItem);
        }
    }

    internal void DelItemFromShop(Item item)
    {
        ShopItemsGameObjects[item].SetActive(false);
    }

    internal void AddItemToPlayer(Item item)
    {
        if (PlayerItemsGameObjects.ContainsKey(item))
        {
            PlayerItemsGameObjects[item].SetActive(true);
        }
        else
        {
            GameObject newItem = Instantiate(ItemVisualPrefab, Vector3.zero, Quaternion.identity, PlayerItemsHub);
            newItem.GetComponent<ItemVisual>().Init(item);
            PlayerItemsGameObjects.Add(item, newItem);
        }
    }

    internal void DelItemFromPlayer(Item item)
    {
        PlayerItemsGameObjects[item].SetActive(false);
    }

    public void BuySell(Item item)
    {
        if (ShopPanelVisual.activeInHierarchy)      //Покупка
        {
            if (item.price <= Control.playerMoney)
            {
                InShopBalance.GetComponent<Text>().color = Color.white;
                Control.playerMoney -= item.price;
                InShopBalance.GetComponent<Text>().text = Control.playerMoney.ToString() + " UNC";
                DelItemFromShop(item);
                AddItemToPlayer(item);
            }
            else
                InShopBalance.GetComponent<Text>().color = Color.red;
        }
        else                                       //Продажа
        {
            Control.playerMoney += item.price;
            InInventoryBalance.GetComponent<Text>().text = Control.playerMoney.ToString() + " UNC";
            DelItemFromPlayer(item);
            AddItemToShop(item);
        }


    }

}
