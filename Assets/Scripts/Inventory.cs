using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> inventory;

    public Inventory()
    {
        this.inventory = new List<Item>();
    }

    public List<Item> getItems()
    {
        return inventory;
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
