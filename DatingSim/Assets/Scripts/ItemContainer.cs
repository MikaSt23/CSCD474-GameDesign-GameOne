using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;
}

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        if (slots == null)
        {
            Debug.LogWarning("ItemContainer: slots list is not initialized!");
            return;
        }
        if (item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            // add non stackable items to our item container
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
                itemSlot.count = 1;
            }
        }
    }

    public void Initialize(int slotCount)
    {
        if (slots == null)
            slots = new List<ItemSlot>();

        while (slots.Count < slotCount)
        {
            slots.Add(new ItemSlot());
        }
    }

}
