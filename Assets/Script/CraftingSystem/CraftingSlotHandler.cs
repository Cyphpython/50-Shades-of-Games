using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlotHandler : MonoBehaviour,IDropHandler
{
    private Slot craftingSlot;

    private void Awake()
    {
        craftingSlot = GetComponent<Slot>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedslot = eventData.pointerDrag?.GetComponent<InventorySlotHandler>();
        if (draggedslot != null && draggedslot.linkedItem != null)
        {
            Inventory.Instance?.RemoveItem(draggedslot.linkedItem);
            UIInventory.UiInstance?.RefreshInventory();
            craftingSlot.SetItem(draggedslot.linkedItem);
        }
    }
}
