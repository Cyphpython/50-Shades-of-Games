using UnityEngine;
using Fungus;

[CommandInfo("Inventory", "Remove Item", "Remove an item from the player inventory")]
public class RemoveItem : Command
{
    [Tooltip("the item to remove")]
    public InventoryItem item;

    public override void OnEnter()
    {
        if (item == null)
        {
            Debug.LogError("No item specified");
            Continue();
            return;
        }
        Inventory.Instance?.RemoveItem(item);
        Continue();
    }

    public override string GetSummary()
    {
        return item != null ? item.name : "No item selected";
    }
}
