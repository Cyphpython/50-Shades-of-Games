using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;
    public InventoryItem currentItem;

    public void SetItem(InventoryItem item)
    {
        currentItem = item;
        icon.sprite = item?.itemIcon;
        icon.enabled = item != null;
    }

    public void Clear()
    {
        currentItem = null;
        icon.sprite = null;
    }
}
