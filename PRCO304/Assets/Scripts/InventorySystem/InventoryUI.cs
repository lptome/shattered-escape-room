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
        inventory = Inventory.instance;
        inventory.onItemAddedCallback += UpdateUI;
        selectedItem = selectedPanel.GetComponentInChildren<Image>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

   
 

    void UpdateUI()
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
}
