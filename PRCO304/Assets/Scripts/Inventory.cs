using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;


    public GameObject inventoryPanel;
    private bool inventoryEnabled;
    

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
        inventoryPanel.SetActive(false);

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

        RefreshUI();
    }


   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            
            inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled == true)
            {   
                inventoryPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } 
            else
            {
                inventoryPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && inventoryEnabled == true)
        {
            inventoryEnabled = !inventoryEnabled;
            inventoryPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        RefreshUI();
    }

    private void RefreshUI()
    {
        

        
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
