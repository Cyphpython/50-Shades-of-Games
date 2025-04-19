
using UnityEngine;

public interface IInventoryItem
{
    string Name { get;}
    Sprite Icon { get;}
    string Description { get;}
    bool IsUsable { get;}
    bool IsKeyItem { get;}
    bool IsANote { get;}

    void OnUse();
}
