using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject selectedPanel;
    private Image selectedItem;
    public Item currentItem;
    Inventory inventory;
    InventorySlot[] slots;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.onInventoryChangedCallback += UpdateUI;
        selectedItem = selectedPanel.GetComponentInChildren<Image>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

   
 

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].RemoveItem();
            }
        }
    }

    public void SelectItem(Item item)
    {
        currentItem = item;
        selectedPanel.SetActive(true);
        selectedItem.sprite = item.icon;
    }

    public void Combine(InventorySlot draggedSlot, InventorySlot dropSlot, Item item1, Item item2)
    {
        List<Item> itemList = inventory.comboItems;

        if (item1.finalItem.Equals(item2.finalItem))
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (item1.finalItem.Equals(itemList[i].itemName))
                {
                    draggedSlot.RemoveItem();
                    dropSlot.RemoveItem();
                    dropSlot.AddItem(itemList[i]);
                    itemList.Clear();
                    inventory.Remove(item1);
                    inventory.Remove(item2);
                }
            }
        }
        itemList.Clear();
    }
}
