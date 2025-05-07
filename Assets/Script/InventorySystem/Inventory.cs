using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List <InventoryItem> items = new List <InventoryItem> ();
    public int inventorySize = 10;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
   
    public bool AddItem(InventoryItem item)
    {
        if (items.Count >= inventorySize)
        {
            Debug.Log("inventaire plein");
            return false;
        }
        items.Add(item);
        if (UIInventory.UiInstance != null)
        {
            UIInventory.UiInstance.RefreshInventory();
        }
        return true;
    }

    public void RemoveItem(InventoryItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            UIInventory.UiInstance?.RefreshInventory();
        }
    }

    public bool HasItem(InventoryItem item)
    {
        if (items.Contains(item)) { return true; }
        else return false;
    }
}
