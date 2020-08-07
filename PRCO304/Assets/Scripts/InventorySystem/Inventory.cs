using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Journal found.");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemAdded();
    public OnItemAdded onItemAddedCallback;

    public int slots = 12;

    public List<Item> items = new List<Item>();

    [SerializeField] InventorySlot[] inventorySlots;
  
   

 
    public bool Add(Item item)
    {
        if (items.Count >= slots)
        {
            return false;
        }
        items.Add(item);

        if (onItemAddedCallback != null)
        {
            onItemAddedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

}
