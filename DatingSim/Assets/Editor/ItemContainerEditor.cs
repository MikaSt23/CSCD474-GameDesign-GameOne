using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemContainer))]
public class ItemContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Button to clear container
        if (GUILayout.Button("Clear container"))
        {
            ItemContainer container = target as ItemContainer;
            // Clear all items in the container
            for (int i = 0; i < container.slots.Count; i++)
            {
                container.slots[i].item = null;
                container.slots[i].count = 0;
            }
        }

        // Draw the default inspector
        DrawDefaultInspector();
    }
}
