using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public Inventory initialItems;
    public ShopPanel PlayerVisual;

    private List<Item> playerItems = new List<Item>();

    private void Start()
    {
        foreach (Item item in initialItems.inventory)
            AddItem(item);
    }

    public void AddItem(Item item)
    {
        playerItems.Add(item);
        PlayerVisual.AddItemToPlayer(item);
    }

    public void DeleteItem(Item item)
    {
        playerItems.Remove(item);
        PlayerVisual.DelItemFromPlayer(item);
    }
}
