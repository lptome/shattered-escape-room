using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDrop : MonoBehaviour, IDropHandler
{
   
    private InventoryUI inventoryUI;
    void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        Item itemInSlot = gameObject.GetComponent<InventorySlot>().GetItem();
        InventorySlot droppedSlot = gameObject.GetComponent<InventorySlot>();
        InventorySlot draggedSlot = eventData.pointerDrag.GetComponent<InventorySlot>();
        Item droppedItem = draggedSlot.GetItem();
        inventoryUI.Combine(draggedSlot, droppedSlot, droppedItem, itemInSlot);
        droppedSlot.tooltip.HideTooltip();
        
    }

 
}
