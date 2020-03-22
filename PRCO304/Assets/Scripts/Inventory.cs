using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;
    [SerializeField] SelectedPanel selectedPanel;

    
    
    private int currentItem = 0; //Index for the currently selected item.
    
    public event Action<Item> OnLeftClickEvent;
    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;
    public event Action<ItemSlot> OnScrollEvent;

    private void Start()
    {


        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnLeftClickEvent += OnLeftClickEvent;
            itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;
        }

    }


   
    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            int slotsFilled = CheckSlots();
            if (currentItem > slotsFilled)
            {
                currentItem = 0;
            }
            else
            {
                currentItem += 1;
            }
            
            if (itemSlots[currentItem].Item != null)
                selectedPanel.SelectItem(itemSlots[currentItem].Item);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            int slotsFilled = CheckSlots();
            if (currentItem < 1)
            {
                currentItem = slotsFilled;
            }
            else
            {
                currentItem -= 1;
            }
            
            if (itemSlots[currentItem].Item != null)
                selectedPanel.SelectItem(itemSlots[currentItem].Item);
        }
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        
    }

  

    private int CheckSlots()
    {
        int slotsFilled = 0;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item != null)
                slotsFilled += 1;
        }
        return slotsFilled;
    }
    
    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public bool HasItem(string name)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item != null)
            {
                if (itemSlots[i].Item.itemName == name)
                    return true;
            }
        }
        return false;
    }

    
   
}
