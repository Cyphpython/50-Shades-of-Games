using UnityEngine;
using UnityEditor;
using static InventoryItem;

[CustomEditor(typeof(InventoryItem))]
public class InventoryItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InventoryItem item = (InventoryItem)target;

        //Champs standarts
        item.name = EditorGUILayout.TextField("Item Name", item.name);
        item.itemIcon = (Sprite)EditorGUILayout.ObjectField("Item Icon", item.itemIcon, typeof(Sprite), false);
        item.itemDescription = EditorGUILayout.TextField ("Description", item.itemDescription);

        item.ItemClass = (ItemGategory)EditorGUILayout.EnumPopup("Category", item.ItemClass);

        EditorGUILayout.Space();

        //Champs avec logique exclusive
        EditorGUI.BeginDisabledGroup(item.IsKeyItem);
        item.IsUsable = EditorGUILayout.Toggle("Is Usable", item.IsUsable);
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(item.IsUsable);
        item.IsKeyItem = EditorGUILayout.Toggle("Is Key Item", item.IsKeyItem);
        EditorGUI.EndDisabledGroup();
    }
}
