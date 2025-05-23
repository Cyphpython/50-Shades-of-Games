using UnityEngine;
using UnityEditor;
using static InventoryItem;

[CustomEditor(typeof(InventoryItem))]
public class InventoryItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        InventoryItem item = (InventoryItem)target;

        #region StandardField
        item.itemName = EditorGUILayout.TextField("Item Name", item.itemName);
        item.itemIcon = (Sprite)EditorGUILayout.ObjectField("Item Icon", item.itemIcon, typeof(Sprite), false);
        item.itemDescription = EditorGUILayout.TextField ("Description", item.itemDescription);
        item.ItemClass = (ItemGategory)EditorGUILayout.EnumPopup("Category", item.ItemClass);

        EditorGUILayout.Space();
        #endregion

        #region Note Field
        SerializedProperty IsANote = serializedObject.FindProperty("_IsANote");
        SerializedProperty Usable = serializedObject.FindProperty("_IsUsable");
        SerializedProperty KeyItem = serializedObject.FindProperty("_IsKeyItem");

        EditorGUILayout.PropertyField(IsANote, new GUIContent("Is a Note"));

        if (IsANote.boolValue)
        {
            Usable.boolValue = true;
            KeyItem.boolValue = false;
            EditorGUILayout.HelpBox("A Note is always usable no matter what", MessageType.Info);
        }

        EditorGUILayout.Space();
        #endregion

        #region ExlusiveLogicField
        if (!item.IsANote)
        {
            
            EditorGUI.BeginDisabledGroup(item.IsKeyItem);
            EditorGUILayout.PropertyField(Usable, new GUIContent("Is Usable"));
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(item.IsUsable);
            EditorGUILayout.PropertyField(KeyItem, new GUIContent("Is Key Item"));
            EditorGUI.EndDisabledGroup();

        }
        EditorGUILayout.Space();
        #endregion

        #region Block Fungus
        if (item.IsUsable)
        {
            SerializedProperty useBlock = serializedObject.FindProperty("useBlock");
            EditorGUILayout.PropertyField(useBlock);
        }
        if (item.IsKeyItem)
        {
            item.condition = EditorGUILayout.TextField(
                new GUIContent("BooleanVariable Name", "Name of the BooleanVariable that will be set to true when pickup in a scene"), 
                item.condition
                );
        }
        #endregion
        serializedObject.ApplyModifiedProperties();
    }
}
