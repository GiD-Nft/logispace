using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour {

    public Inventory initialItems;
    public ShopPanel ShopVisual;

    private List<Item> shopItems = new List<Item>();

    private void Start()
    {
        foreach (Item item in initialItems.inventory)
            AddItem(item);
    }

    public void AddItem(Item item)
    {
        shopItems.Add(item);
        ShopVisual.AddItemToShop(item);
    }

    public void DeleteItem(Item item)
    {
        shopItems.Remove(item);
        ShopVisual.DelItemFromShop(item);
    }
}
