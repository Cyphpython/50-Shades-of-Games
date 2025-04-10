using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class InventorySlotHandler : MonoBehaviour, IPointerClickHandler
{
    public InventoryItem linkedItem;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (linkedItem == null) return;
        if (eventData.button == PointerEventData.InputButton.Right)
            InventoryContextMenu.Instance.Show(linkedItem, Input.mousePosition);
    }
}
