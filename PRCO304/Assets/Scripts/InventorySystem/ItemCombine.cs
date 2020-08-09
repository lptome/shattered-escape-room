using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCombine : MonoBehaviour
{

    void Combine(InventorySlot slot, Item item1, Item item2)
    {
        List<Item> itemList = Inventory.instance.items;

        for(int i = 0; i < itemList.Count; i++)
        {
            if (item1.finalItem.Equals(itemList[i].itemName))
            {
                slot.AddItem(itemList[i]);
            }
        }
    }
}
