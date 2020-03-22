using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] Inventory inventory;
    [SerializeField] SelectedPanel selectPanel;
    [SerializeField] Image draggableItem;
    [SerializeField] ItemTooltip itemTooltip;

    private ItemSlot draggedSlot;
    private CanvasGroup canvasGroup;
    

    private void OnValidate()
    {
        if (itemTooltip == null)
        {
            itemTooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    private void Awake()
    {

        canvasGroup = GetComponentInChildren<CanvasGroup>();
        //Setting up the events
        //Pointer Enter
        inventory.OnPointerEnterEvent += ShowTooltip;
        //Pointer Exit
        inventory.OnPointerExitEvent += HideTooltip;
        //Begin Drag
        inventory.OnBeginDragEvent += BeginDrag;
        //End Drag
        inventory.OnEndDragEvent += EndDrag;
        //Drag
        inventory.OnDragEvent += Drag;
        //Drop
        inventory.OnDropEvent += Drop;
        inventory.OnLeftClickEvent += Select;

        //Disables Tooltip 
        itemTooltip.HideTooltip();
    }


    public void Select(Item item)
    {
        selectPanel.SelectItem(item);
        
    }

    private void ShowTooltip(ItemSlot itemSlot)
    {
        if(itemSlot.Item != null)
        {
            Item item = itemSlot.Item;
            itemTooltip.ShowTooltip(item);
        }
            
    }

    private void HideTooltip(ItemSlot itemSlot)
    {
        itemTooltip.HideTooltip();
    }
    private void BeginDrag(ItemSlot itemSlot)
    { 
        canvasGroup.blocksRaycasts = false;

        if (itemSlot.Item != null)
        {
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }

        Select(itemSlot.Item);
        itemTooltip.HideTooltip();
    }
    private void EndDrag(ItemSlot itemSlot)
    {
        canvasGroup.blocksRaycasts = true;
        draggedSlot = null;
        draggableItem.enabled = false;
    }
    private void Drag(ItemSlot itemSlot)
    {
        if (draggableItem.enabled)
            draggableItem.transform.position = Input.mousePosition;       
    }
    private void Drop(ItemSlot dropItemSlot)
    {
        if (dropItemSlot.Item != null)
        {
            Item draggedItem = draggedSlot.Item;
            draggedSlot.Item = dropItemSlot.Item;
            dropItemSlot.Item = draggedItem;
        }

        
    }

   

}
