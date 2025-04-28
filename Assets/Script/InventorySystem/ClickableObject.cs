using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public InventoryItem itemToGive;

    public void Pickup()
    {
        if (Inventory.Instance.AddItem(itemToGive))
        {
            itemToGive.OnPickup();
            Destroy(gameObject);
        }
    }
}
