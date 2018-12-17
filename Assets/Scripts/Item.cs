using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public enum ItemType {
        Корпус,
        Оружие,
        Oбшивка,
        Генератор,
        Артефакт
    }

    //public string type; // Тип товара
    public ItemType type; // Тип товара
    public string itemName; // Имя товара
    public string description; // Описание эффектов товара
    public int price; // Цена товара в "Валюте объединённых наций" (united nations currency (UNC))
    //public string spriteName; // Имя спрайта для значка товара?????????????
    public Sprite sprite; // спрайт для значка товара?????????????

    public Item(ItemType type, string name, string description, int price)
    {
        this.type = type;
        this.itemName = name;
        this.description = description;
        this.price = price;
    }
}