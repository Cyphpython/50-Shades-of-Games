using Fungus;
using UnityEngine;

[CommandInfo("Inventory", "Check Item", "check if the player possess the item in the inventory")]
public class CheckItemInInventory : Command
{
    public InventoryItem item;
    public BooleanVariable hasitem;

    public override void OnEnter()
    {
        if (item != null)
        {
            if (hasitem != null)
            {
                hasitem.Value = Inventory.Instance.HasItem(item);
            }
            else
            {
                Debug.LogError("No Boolean Variable set for comparaison");
            }
        }
        else
        {
            Debug.LogError("No Item Defined");
        }
        Continue();
    }
}
