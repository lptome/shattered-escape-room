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
    public List<Item> comboItems = new List<Item>();

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

    public Item Combine(Item item1, Item item2)
    {
        List<Item> comboItems = Inventory.instance.comboItems;

        for (int i = 0; i < comboItems.Count; i++)
        {
            if (item1.finalItem.Equals(comboItems[i].itemName))
            {
                return comboItems[i];
            }
        }
        return null;
    }

}
