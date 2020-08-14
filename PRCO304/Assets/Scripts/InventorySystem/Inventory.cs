using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;

    public int slots = 12;

    public List<Item> items = new List<Item>(); //Held items
    public List<Item> comboItems = new List<Item>(); //Combination items


    public bool Add(Item item)
    {
        if (items.Count >= slots)
        {
            return false;
        }
        items.Add(item);

        //If a callback function exists, then it will be invoked.
        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }
        items.Remove(item);
    }



}
