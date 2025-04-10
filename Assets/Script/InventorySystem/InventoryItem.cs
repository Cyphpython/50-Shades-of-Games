using Fungus;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public enum ItemGategory { Common, Rare, Epic, Lengendary };
    public ItemGategory ItemClass;
    public string itemName;
    public Sprite itemIcon;
    public string itemDescription;
    public bool IsUsable;
    public bool IsKeyItem;
    public string useBlock;
}
