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

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.onInventoryChangedCallback += UpdateUI;
        selectedItem = selectedPanel.GetComponentInChildren<Image>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

   
 

    public void UpdateUI()
    {
        for (int i = 0; i < inventory.slots; i++)
        {
            slots[i].ClearSlot();
        }

        for (int i = 0; i < inventory.items.Count; i++)
        {
            slots[i].AddItem(inventory.items[i]);
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
                    inventory.Remove(item1);
                    inventory.Remove(item2);
                    inventory.Add(itemList[i]);
                    draggedSlot.ClearSlot();
                    dropSlot.ClearSlot();
                    dropSlot.AddItem(itemList[i]);
                    UpdateUI();
                }
            }
        }
    }
}
