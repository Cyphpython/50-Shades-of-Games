using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIInventory : MonoBehaviour
{
    public static UIInventory UiInstance;

    public Transform slotContainer;
    public GameObject slotPrefab;
    public GameObject inventoryPanel;

    private int MaxSlots;

    private void Awake()
    {
        if (UiInstance == null) UiInstance = this; else Destroy(gameObject);
    }

    void Start()
    {
        MaxSlots = Inventory.Instance.inventorySize; // Gestion Dynamique de taille
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < MaxSlots; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotContainer);
            Image icon = slot.transform.Find("Background/Icon").GetComponent<Image>();
            if (i < Inventory.Instance.items.Count)
            {
                InventoryItem item = Inventory.Instance.items[i];
                if (item.itemIcon != null)
                {
                    icon.sprite = item.itemIcon;
                    icon.enabled = true;
                }
                else
                {
                    icon.enabled = false;
                }
            }
            else
            {
                icon.enabled = false;
            }
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

}
