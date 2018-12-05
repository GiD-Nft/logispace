using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> inventory;

    public Inventory()
    {
        this.inventory = new List<Item>();
    }

    public void AddItem(Item item)
    {
        this.inventory.Add(item);
    }

    public void DeleteItem(Item item)
    {
        this.inventory.Remove(item);
    }
}
