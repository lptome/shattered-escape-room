using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] GameObject itemObject;
    [SerializeField] Inventory inventory;
    [SerializeField] Item item;

    void Click()
    {
        Destroy(itemObject);
        inventory.AddItem(item);
    }
}
