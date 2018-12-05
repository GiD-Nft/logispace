using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string type; // Тип товара
    public string name; // Имя товара
    public string description; // Описание эффектов товара
    public int price; // Цена товара в "Валюте объединённых наций" (united nations currency (UNC))
    public string spriteName; // Имя спрайта для значка товара?????????????

    public Item(string type, string name, string description, int price)
    {
        this.type = type;
        this.name = name;
        this.description = description;
        this.price = price;
    }
}