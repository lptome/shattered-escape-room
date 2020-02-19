using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;
    public GameObject inventory;
    private bool inventoryEnabled;

  


    void Start()
    {
        inventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled == true)
            {   
                inventory.SetActive(true);
            } 
            else
            {
                inventory.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && inventoryEnabled == true)
        {
            inventoryEnabled = !inventoryEnabled;
            inventory.SetActive(false);
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
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }
        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }
}
