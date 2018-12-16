using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemVisual : MonoBehaviour, IPointerClickHandler {

    public GameObject ItemName;
    public GameObject ItemType;
    public GameObject ItemDescr;
    public GameObject ItemPrice;

    private Item itemAsset;

    public void Init(Item item)
    {
        ItemName.GetComponent<Text>().text = item.itemName;
        ItemType.GetComponent<Text>().text = item.type.ToString();
        ItemDescr.GetComponent<Text>().text = item.description;
        ItemPrice.GetComponent<Text>().text = item.price.ToString()+ "unc";
        itemAsset = item;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(itemAsset.itemName);
        GetComponentInParent<ShopPanel>().BuySell(itemAsset);
    }
}
