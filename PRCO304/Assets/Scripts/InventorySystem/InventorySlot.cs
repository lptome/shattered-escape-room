using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public Item item;
    public Button button;
    public InventoryUI inventoryUI;
    public ItemTooltip tooltip;


    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        button.interactable = true;
    }

    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    public void OnItemClick()
    {
        inventoryUI.SelectItem(item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Showing Tooltip.");
        tooltip.ShowTooltip(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }



}
