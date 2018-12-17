using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour {

    public ShopPanel panel;
    public GameObject ShopPanelVisual;
    public GameObject PlayerPanelVisual;

    public void OpenShop()
    {
        ShopPanelVisual.SetActive(true);
    }

    public void OpenPlayerInventory()
    {
        PlayerPanelVisual.SetActive(true);
    }
}
