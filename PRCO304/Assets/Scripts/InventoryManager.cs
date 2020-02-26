using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] Inventory inventory;
    [SerializeField] SelectedPanel selectPanel;
    [SerializeField] Image draggableItem;

    private ItemSlot draggedSlot;
    private CanvasGroup canvasGroup;

    private void Awake()
    {

        canvasGroup = GetComponentInChildren<CanvasGroup>();
        //Setting up the events
        //Left Click
        //inventory.OnLeftClickEvent += SelectItem;
        //Pointer Enter
        //inventory.OnPointerEnterEvent += ShowTooltip;
        //Pointer Exit
        //inventory.OnPointerExitEvent += HideToolTip;
        //Begin Drag
        inventory.OnBeginDragEvent += BeginDrag;
        //End Drag
        inventory.OnEndDragEvent += EndDrag;
        //Drag
        inventory.OnDragEvent += Drag;
        //Drop
        inventory.OnDropEvent += Drop;
        inventory.OnLeftClickEvent += Select;
    }


    public void Select(Item item)
    {
        selectPanel.SelectItem(item);
        
    }

    private void BeginDrag(ItemSlot itemSlot)
    {
        Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;

        if (itemSlot.Item != null)
        {
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }
    private void EndDrag(ItemSlot itemSlot)
    {
        Debug.Log("EndDrag");
        canvasGroup.blocksRaycasts = true;
        draggedSlot = null;
        draggableItem.enabled = false;
    }
    private void Drag(ItemSlot itemSlot)
    {
        Debug.Log("Drag");
        if (draggableItem.enabled)
            draggableItem.transform.position = Input.mousePosition;
        
    }
    private void Drop(ItemSlot dropItemSlot)
    {
        Debug.Log("Drop");
        Item draggedItem = draggedSlot.Item;
        draggedSlot.Item = dropItemSlot.Item;
        dropItemSlot.Item = draggedItem;
        
    }

}
