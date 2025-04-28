using Fungus;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject, IInventoryItem
{
    public enum ItemGategory { Common, Rare, Epic, Lengendary };
    public ItemGategory ItemClass;

    public string itemName;
    public Sprite itemIcon;
    public string itemDescription;
    [SerializeField]private bool _IsUsable;
    [SerializeField]private bool _IsKeyItem;
    [SerializeField]private bool _IsANote;

    //Fungus
    public string condition;
    public string useBlock;

    //Implementation de l'interface
    public string Name => itemName;
    public Sprite Icon => itemIcon;
    public string Description => itemDescription;

    public bool IsUsable => _IsUsable;
    public bool IsKeyItem => _IsKeyItem;
    public bool IsANote => _IsANote;


    public void OnPickup()
    {
        if (IsKeyItem && !string.IsNullOrEmpty(condition)) FlowchartManager.SetBoolVar(condition);
    }


    public void OnUse()
    {
        if (IsKeyItem)
        {
            return;
        }
        
        if (IsUsable)
        {

            //Fungus
            if (!string.IsNullOrEmpty(useBlock))
            {
                FlowchartManager.UseItemBlock(useBlock);

            }
        }
    }
}
