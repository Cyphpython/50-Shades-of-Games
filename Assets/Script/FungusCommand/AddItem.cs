using Fungus;
using UnityEngine;

[CommandInfo("Inventory", "Add Item", "add item to player inventory")]
public class AddItem : Command
{
    public InventoryItem item;

    public override void OnEnter()
    {
        if (item != null)
        {
            Inventory.Instance?.AddItem(item);
            
        }
        else
        {
            Debug.LogWarning("No Item Defined");
        }
        Continue();
    }
}
